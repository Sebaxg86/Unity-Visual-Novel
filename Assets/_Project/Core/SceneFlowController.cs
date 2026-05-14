using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EntreTuSilencio.Core
{
    [DisallowMultipleComponent]
    public class SceneFlowController : MonoBehaviour
    {
        [SerializeField] private string mainMenuSceneName = "MainMenu";
        [SerializeField] private string chapter01SceneName = "Chapter01";
        [SerializeField] private float transitionDuration = 0.35f;
        [SerializeField] private bool useUnscaledTime = true;
        [SerializeField] private FadeOverlayController fadeOverlay;

        private bool isLoading;

        public void LoadMainMenu()
        {
            LoadSceneByName(mainMenuSceneName);
        }

        public void LoadChapter01()
        {
            LoadSceneByName(chapter01SceneName);
        }

        public void ReloadCurrentScene()
        {
            LoadSceneByName(SceneManager.GetActiveScene().name);
        }

        public void LoadSceneByName(string sceneName)
        {
            if (isLoading || string.IsNullOrWhiteSpace(sceneName))
            {
                return;
            }

            if (!Application.CanStreamedLevelBeLoaded(sceneName))
            {
                Debug.LogWarning($"Scene '{sceneName}' is not available in Build Settings.", this);
                return;
            }

            StartCoroutine(LoadSceneRoutine(sceneName));
        }

        public void QuitGame()
        {
            Application.Quit();
            Debug.Log("QuitGame requested.");
        }

        private IEnumerator LoadSceneRoutine(string sceneName)
        {
            isLoading = true;

            if (fadeOverlay != null)
            {
                yield return fadeOverlay.PlayFadeToBlack(transitionDuration, useUnscaledTime);
            }

            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            while (!loadOperation.isDone)
            {
                yield return null;
            }
        }
    }
}
