using UnityEngine;
using UnityEngine.InputSystem;

namespace Santum
{
    [RequireComponent(typeof(FPController))]
    public class Player : MonoBehaviour
    {
        public static Player Instance { get; private set; }

        [Header("Components")]
        [SerializeField] FPController FPController;

        // Number of UI panels currently requesting "menu mode".
        private int uiOpenCount = 0;

        #region Input Handling
        void OnMove(InputValue value)
        {
            FPController.MoveInput = value.Get<Vector2>();
        }

        void OnLook(InputValue value)
        {
            FPController.LookInput = value.Get<Vector2>();
        }

        void OnSprint(InputValue value)
        {
            FPController.SprintInput = value.isPressed;
        }

        void OnJump(InputValue value)
        {
            if (value.isPressed)
            {
                FPController.TryJump();
            }
        }

        #endregion

        #region UI Mode

        /// <summary>Call when a UI panel opens — freezes the player and frees the cursor.</summary>
        public void PushUI()
        {
            uiOpenCount++;
            ApplyMode();
        }

        /// <summary>Call when a UI panel closes.</summary>
        public void PopUI()
        {
            uiOpenCount = Mathf.Max(0, uiOpenCount - 1);
            ApplyMode();
        }

        private void ApplyMode()
        {
            bool uiOpen = uiOpenCount > 0;

            FPController.InputEnabled = !uiOpen;
            Cursor.visible = uiOpen;
            Cursor.lockState = uiOpen ? CursorLockMode.None : CursorLockMode.Locked;
        }

        #endregion

        #region Unity Methods

        private void OnValidate()
        {
            if (FPController == null)
            {
                FPController = GetComponent<FPController>();
            }
        }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // Start in gameplay mode (cursor locked, input enabled)
            ApplyMode();
        }

        #endregion
    }
}
