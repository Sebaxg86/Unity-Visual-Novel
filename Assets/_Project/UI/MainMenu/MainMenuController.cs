using EntreTuSilencio.Core;
using UnityEngine;

namespace EntreTuSilencio.UI.MainMenu
{
    [DisallowMultipleComponent]
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup pressStartGroup;
        [SerializeField] private CanvasGroup mainOptionsGroup;
        [SerializeField] private CanvasGroup settingsPlaceholderGroup;
        [SerializeField] private CanvasGroup quitModalGroup;
        [SerializeField] private SceneFlowController sceneFlowController;
        [SerializeField] private bool startWithOnlyPressStart = true;

        [Header("Audio")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioClip backgroundMusic;
        [SerializeField] private bool loopBackgroundMusic = true;

        private void Awake()
        {
            PlayBackgroundMusicIfNeeded();

            if (startWithOnlyPressStart)
            {
                ShowPressStartOnly();
                return;
            }

            OpenMainOptions();
        }

        public void OnPressStart()
        {
            OpenMainOptions();
        }

        public void StartNewGame()
        {
            CloseSettings();
            CloseQuitModal();

            if (sceneFlowController != null)
            {
                sceneFlowController.LoadChapter01();
            }
        }

        public void ContinueGame()
        {
            Debug.Log("ContinueGame todavía no está implementado.");
        }

        public void OpenSettings()
        {
            SetCanvasGroup(settingsPlaceholderGroup, true);
            SetCanvasGroup(quitModalGroup, false);
        }

        public void CloseSettings()
        {
            SetCanvasGroup(settingsPlaceholderGroup, false);
        }

        public void OpenQuitModal()
        {
            SetCanvasGroup(quitModalGroup, true);
            SetCanvasGroup(settingsPlaceholderGroup, false);
        }

        public void CloseQuitModal()
        {
            SetCanvasGroup(quitModalGroup, false);
        }

        public void ConfirmQuit()
        {
            if (sceneFlowController != null)
            {
                sceneFlowController.QuitGame();
            }
        }

        public void OpenMainOptions()
        {
            SetCanvasGroup(pressStartGroup, false);
            SetCanvasGroup(mainOptionsGroup, true);
            SetCanvasGroup(settingsPlaceholderGroup, false);
            SetCanvasGroup(quitModalGroup, false);
        }

        public void ShowPressStartOnly()
        {
            SetCanvasGroup(pressStartGroup, true);
            SetCanvasGroup(mainOptionsGroup, false);
            SetCanvasGroup(settingsPlaceholderGroup, false);
            SetCanvasGroup(quitModalGroup, false);
        }

        private void SetCanvasGroup(CanvasGroup canvasGroup, bool visible)
        {
            if (canvasGroup == null)
            {
                return;
            }

            canvasGroup.alpha = visible ? 1f : 0f;
            canvasGroup.interactable = visible;
            canvasGroup.blocksRaycasts = visible;
        }

        private void PlayBackgroundMusicIfNeeded()
        {
            if (musicSource == null || backgroundMusic == null)
            {
                return;
            }

            if (musicSource.isPlaying && musicSource.clip == backgroundMusic)
            {
                return;
            }

            musicSource.clip = backgroundMusic;
            musicSource.loop = loopBackgroundMusic;
            musicSource.Play();
        }
    }
}
