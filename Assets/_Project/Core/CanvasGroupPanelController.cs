using UnityEngine;

namespace EntreTuSilencio.Core
{
    [DisallowMultipleComponent]
    public class CanvasGroupPanelController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup targetCanvasGroup;
        [SerializeField] private bool hideOnAwake;

        private void Awake()
        {
            if (targetCanvasGroup == null)
            {
                targetCanvasGroup = GetComponent<CanvasGroup>();
            }

            if (hideOnAwake)
            {
                Hide();
            }
        }

        public void Show()
        {
            SetVisibility(true);
        }

        public void Hide()
        {
            SetVisibility(false);
        }

        public void Toggle()
        {
            if (targetCanvasGroup == null)
            {
                return;
            }

            SetVisibility(targetCanvasGroup.alpha <= 0.01f);
        }

        private void SetVisibility(bool visible)
        {
            if (targetCanvasGroup == null)
            {
                gameObject.SetActive(visible);
                return;
            }

            targetCanvasGroup.alpha = visible ? 1f : 0f;
            targetCanvasGroup.interactable = visible;
            targetCanvasGroup.blocksRaycasts = visible;
        }
    }
}
