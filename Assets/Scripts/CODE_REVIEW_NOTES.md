# Santum — Scripts Review Notes

Last updated: 2026-09-02 · Unity 6 project

Running list of code issues found during review. The big cleanup pass is done — what
remains below is either an **editor/config action you must take**, a **design choice to
confirm**, or a **feature that isn't built yet (WIP)**.

---

## Action required (not code — do these in the editor)

- [ ] **Set Active Input Handling to "Input System Package (New)".**
      Project Settings > Player > Active Input Handling. All legacy `Input.` calls are
      gone; the project is ready for it. Editor restart required.
- [ ] **Define an "Enemy" layer** in Tags & Layers, and put enemy prefabs on it.
      `TheTower` now logs a warning at startup if the layer is missing, but it still
      won't detect anything until the layer exists and prefabs use it.
- [ ] **Keep `TheTower` only in the bootstrap scene.** Its `Start()` force-loads "Menu";
      a second copy elsewhere would re-trigger that. The `Awake` duplicate-guard covers
      it, but don't add it to other scenes.

## Confirm these are intentional

- [ ] `LoadLocal()` clamps every `0` stat up to `1` (a floor). Fine if intended; a bug
      if any stat can legitimately be 0.
- [ ] `MenuManager` fade-out is slower than fade-in (`fadeSmoothing` only scales the out
      direction). Left as-is with a comment — change if the feel is wrong.
- [ ] `EnemyType.Thought` — odd name next to `Tiny` / `Fast`. Rename if it was a typo.
- [ ] `TheTower` consumes its attack cooldown before checking for a target, so an
      idle+ready tower can wait up to `attackInterval` (<=1s) before hitting a new
      enemy. Standard for tower defense; revisit only if instant reaction is wanted.

## Not built yet (WIP — no action now)

- [ ] `Enemy`: reaching the tower just stops the enemy (`// TODO` marker in `Update`).
      No tower damage, no attack loop — `damage`, `attackPerSecond`, `hitpoint` unused.
- [ ] `TheTower.ShootEnemy(Transform)` is an empty stub — no projectile / damage /
      crit logic yet. `Stat.Damage` and the crit stats are unused.
- [ ] `Enemy` has no death/hit reaction — only `RemoveEnemy()` (called by the tower).

---

## Done

### This pass (2026-09-02) — full cleanup + `Santum` namespace on all 8 files

**Namespaces:** every script is now in `namespace Santum` (was global).

**TheTower**
- `Update()` guard hardened: `if (!isInGame || TowerStats == null) return;`.
- `Physics.OverlapSphere` -> `OverlapSphereNonAlloc` with a reusable `enemyBuffer[64]`
  (no per-attack allocation).
- Warns at startup if the "Enemy" layer mask resolves to 0.
- `LoadLocal` / `SaveLocal` reordered to match the `Stat` enum.
- Added `Upgrade(Stat, int)` — clamps to a floor of 1 and calls `SaveLocal()`.
- Removed a duplicate `lastAttack = Time.time;` assignment.

**Enemy**
- Direction is now `(startPosition - towerCenter)` using the tower's actual position,
  not `startPosition.normalized` (which assumed the tower at world origin). Falls back
  to `transform.forward` if spawned on top of the tower.
- `transition += Time.deltaTime / timeToTower` — `timeToTower` (7.5s) is now respected
  instead of the enemy always crossing in 1 second.
- `RemoveEnemy()` resets `transition` to 0 so a pooled/reused enemy doesn't teleport.
- Arrival (`transition >= 1`) stops the enemy and leaves a `// TODO` for tower attack.

**SpawnManager**
- Bounds + null check on `enemyPrefabs[prefabIndex]` (was `IndexOutOfRangeException`).
- `Instantiate<GameObject>(...)` + `TryGetComponent(out Enemy)` instead of
  `(... as GameObject).GetComponent<Enemy>()` (was a potential NRE).
- Spawn ring is centered on `TheTower.Instance.transform.position` (falls back to
  origin), not hard-coded world origin.
- `AMN_ZONES` -> `ZONE_COUNT`.

**HubManager**
- Cached `Camera.main` and the UI layer mask in `Start` (were per-frame lookups).
- `MoveCamera` uses frame-rate-independent smoothing:
  `t = 1 - Mathf.Exp(-cameraSmoothing * Time.deltaTime)`, plus `Quaternion.Slerp`.
- Skips the world raycast when the pointer is over UI
  (`EventSystem.current.IsPointerOverGameObject()`).
- Null-guards `backButton`, a missing MainCamera (disables the component + logs), and
  `SetDesiredWaypoint(null)`.

**MenuManager**
- Cached `Camera.main` once (was two separate lookups).
- `transition %= 360f` in `MoveCamera` so the orbit accumulator can't grow unbounded.
- Null-guards a missing MainCamera and a missing `uiRoot` CanvasGroup (disable + log).

**HubObject**
- Guarded the `menu` / `CanvasGroup` fetch (`TryGetComponent`, disable + log on fail).
- `FadeMenu` now also toggles `canvasGroup.blocksRaycasts` — a faded-out menu no
  longer eats clicks.
- Fade `transition` snaps cleanly to exactly 0 or 1 instead of overshooting.

**FPController**
- `fpCamera` is auto-wired in `OnValidate` (`GetComponentInChildren`) and null-guarded
  in `LookUpdate` / `CameraUpdate`.
- Rewrote `TryJump()` — `maxJumps = CanDoubleJump ? 2 : 1`, single guard. Walking off a
  ledge now consumes the grounded jump (no more free double jump off ledges).
- Moved `[Header("Movement Parameters")]` onto a real serialized field; `MaxSpeed`
  property relocated below the fields.
- Removed the `Debug.Log("Hit Something above!")` that fired every frame on a ceiling.

**Player** — namespace only (was already clean).

### Earlier passes
- Typos: `jumpHeigh`, `fadeInTrasition`, `menuPoping`, `iddleTimeToFade`,
  `upAndDownMotionSmoothess`, `offSet`, `isPoping`, `towerDistanceOffSet`, `Contants`,
  `rangeRadiusOffSet`, `Stat.CritChange`. Removed unused `using System.Security;`.
- Input System migration: `MenuManager`, `HubManager`, `SpawnManager` moved off legacy
  `Input.` to `Pointer.current` / `Keyboard.current` (with `using UnityEngine.InputSystem;`
  and device null-guards).
- Singletons: `TheTower` -> `Instance` in `Awake` + `OnDestroy` cleanup;
  `HubManager` / `SpawnManager` dropped their unused statics (scene-scoped, not singletons).
- `TheTower.GetTowerHeight()` / `GetTowerWidth()` — base constants un-swapped, now match
  `RescaleTower()`.
- `OnLevelWasLoaded` (deprecated in Unity 6) -> `SceneManager.sceneLoaded` subscription.
- `TheTower` attack interval was inverted -> `1f / Mathf.Max(1, TowerStats[Speed])`.
- `lastAttack` was never set -> cooldown consumed before the scan (no per-frame
  `OverlapSphere`).
- `SaveLocal()` -> null guard + `PlayerPrefs.Save()`; added `OnApplicationPause(true)`
  save for mobile.
- `HubManager` raycast: `hit.collider.GetComponentInParent<HubObject>()` + null check,
  restored the missing `currentHubObject = hubObject;`, fade the previous menu out on
  switch.

### Verified correct (no change needed)
- `TheTower.CreateTowerMesh()` — triangle winding checked on all 5 faces; all normals
  face outward. No bottom face, intentional.

---

## Not verified here

Compilation was **not** checked (no Unity build in this environment). Let the editor
recompile and confirm no errors — the `Santum` namespace was added to all 8 scripts at
once, and scene/prefab references are by GUID so they should be unaffected, but the
first recompile is the real test.
