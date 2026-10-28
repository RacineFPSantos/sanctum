using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Santum
{
    public class MenuManager : MonoBehaviour
    {
        [Header("Scenes")]
        [SerializeField] private string gameSceneName = "Game";

        [Header("Panels")]
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private GameObject settingsPanel;

        [Header("Buttons")]
        [SerializeField] private Button continueButton;

        private const string SaveFlagKey = "HasSave";

        private void Start()
        {
            // The menu always uses a free cursor; gameplay re-locks it via Player.
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            if (continueButton != null)
            {
                continueButton.gameObject.SetActive(HasSave());
            }

            ShowMainPanel();
        }

        private static bool HasSave()
        {
            return PlayerPrefs.GetInt(SaveFlagKey, 0) == 1;
        }

        // Wired to the "New Game" button.
        public void NewGame()
        {
            // Hard reset: drop all meta-progression.
            foreach (Stat stat in System.Enum.GetValues(typeof(Stat)))
            {
                PlayerPrefs.DeleteKey("Stat" + stat);
            }

            PlayerPrefs.SetInt(SaveFlagKey, 1);
            PlayerPrefs.Save();

            SceneManager.LoadScene(gameSceneName);
        }

        // Wired to the "Continue" button.
        public void Continue()
        {
            if (!HasSave())
            {
                return;
            }

            SceneManager.LoadScene(gameSceneName);
        }

        public void OpenSettings()
        {
            if (mainPanel != null) mainPanel.SetActive(false);
            if (settingsPanel != null) settingsPanel.SetActive(true);
        }

        public void CloseSettings()
        {
            ShowMainPanel();
        }

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void ShowMainPanel()
        {
            if (settingsPanel != null) settingsPanel.SetActive(false);
            if (mainPanel != null) mainPanel.SetActive(true);
        }
    }
}
