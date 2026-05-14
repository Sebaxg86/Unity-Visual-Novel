using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace EntreTuSilencio.Dialogue
{
    [DisallowMultipleComponent]
    public class ChoiceController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup rootCanvasGroup;
        [SerializeField] private TMP_Text promptText;
        [SerializeField] private Transform buttonContainer;
        [SerializeField] private Button optionButtonPrefab;
        [SerializeField] private float showFadeDuration = 0.18f;

        private readonly List<Button> buttonPool = new List<Button>();
        private readonly List<Button> activeButtons = new List<Button>();
        private Coroutine visibilityRoutine;

        public event Action<ChoiceOption> ChoiceSelected;
        public event Action<ChoiceOption> ChoicePressed;

        private void Awake()
        {
            if (rootCanvasGroup == null)
            {
                rootCanvasGroup = GetComponent<CanvasGroup>();
            }

            if (optionButtonPrefab != null)
            {
                optionButtonPrefab.gameObject.SetActive(false);
            }

            HideInstant();
        }

        public void ShowChoice(string prompt, IList<ChoiceOption> options)
        {
            ClearButtons();

            if (promptText != null)
            {
                promptText.text = prompt ?? string.Empty;
            }

            if (optionButtonPrefab == null || buttonContainer == null || options == null || options.Count == 0)
            {
                Debug.LogWarning("ChoiceController needs a prefab, a container, and at least one option.", this);
                SetVisibility(false);
                return;
            }

            for (int i = 0; i < options.Count; i++)
            {
                ChoiceOption option = options[i];
                Button button = GetOrCreateButton();
                button.gameObject.SetActive(true);

                TMP_Text label = button.GetComponentInChildren<TMP_Text>(true);
                if (label != null)
                {
                    label.text = option.label;
                }

                button.onClick.RemoveAllListeners();
                ConfigurePointerDownTrigger(button, option);
                button.onClick.AddListener(() => HandleSelection(option));
                activeButtons.Add(button);
            }

            ShowSmooth();
        }

        public void Hide()
        {
            ClearButtons();
            StopVisibilityRoutine();
            SetVisibility(false);
        }

        public void HideInstant()
        {
            ClearButtons();
            StopVisibilityRoutine();
            SetVisibility(false);
        }

        private void HandleSelection(ChoiceOption option)
        {
            ChoiceSelected?.Invoke(option);
            Hide();
        }

        private void ConfigurePointerDownTrigger(Button button, ChoiceOption option)
        {
            if (button == null)
            {
                return;
            }

            EventTrigger trigger = button.GetComponent<EventTrigger>();
            if (trigger == null)
            {
                trigger = button.gameObject.AddComponent<EventTrigger>();
            }

            if (trigger.triggers == null)
            {
                trigger.triggers = new List<EventTrigger.Entry>();
            }

            EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerDown
            };

            pointerDownEntry.callback.AddListener(_ => ChoicePressed?.Invoke(option));
            trigger.triggers.Add(pointerDownEntry);
        }

        private void ClearButtons()
        {
            for (int i = 0; i < activeButtons.Count; i++)
            {
                Button button = activeButtons[i];
                if (button == null)
                {
                    continue;
                }

                button.onClick.RemoveAllListeners();

                EventTrigger trigger = button.GetComponent<EventTrigger>();
                if (trigger != null && trigger.triggers != null)
                {
                    trigger.triggers.Clear();
                }

                button.gameObject.SetActive(false);
            }

            activeButtons.Clear();
        }

        private Button GetOrCreateButton()
        {
            for (int i = 0; i < buttonPool.Count; i++)
            {
                Button pooledButton = buttonPool[i];
                if (pooledButton != null && !pooledButton.gameObject.activeSelf)
                {
                    pooledButton.transform.SetParent(buttonContainer, false);
                    pooledButton.transform.SetAsLastSibling();
                    return pooledButton;
                }
            }

            Button newButton = Instantiate(optionButtonPrefab, buttonContainer);
            buttonPool.Add(newButton);
            return newButton;
        }

        private void SetVisibility(bool visible)
        {
            if (rootCanvasGroup == null)
            {
                gameObject.SetActive(visible);
                return;
            }

            rootCanvasGroup.alpha = visible ? 1f : 0f;
            rootCanvasGroup.blocksRaycasts = visible;
            rootCanvasGroup.interactable = visible;
        }

        private void ShowSmooth()
        {
            if (rootCanvasGroup == null)
            {
                SetVisibility(true);
                return;
            }

            StopVisibilityRoutine();
            rootCanvasGroup.alpha = 0f;
            rootCanvasGroup.blocksRaycasts = false;
            rootCanvasGroup.interactable = false;
            visibilityRoutine = StartCoroutine(FadeCanvasGroupRoutine(1f, showFadeDuration, true));
        }

        private IEnumerator FadeCanvasGroupRoutine(float targetAlpha, float duration, bool enableInteractionAtEnd)
        {
            if (rootCanvasGroup == null)
            {
                yield break;
            }

            float startAlpha = rootCanvasGroup.alpha;
            float safeDuration = duration > 0f ? duration : 0.01f;
            float elapsed = 0f;

            while (elapsed < safeDuration)
            {
                elapsed += Time.unscaledDeltaTime;
                float t = Mathf.Clamp01(elapsed / safeDuration);
                float eased = Mathf.SmoothStep(0f, 1f, t);
                rootCanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, eased);
                yield return null;
            }

            rootCanvasGroup.alpha = targetAlpha;
            bool visible = targetAlpha > 0.001f;
            rootCanvasGroup.blocksRaycasts = visible && enableInteractionAtEnd;
            rootCanvasGroup.interactable = visible && enableInteractionAtEnd;
            visibilityRoutine = null;
        }

        private void StopVisibilityRoutine()
        {
            if (visibilityRoutine == null)
            {
                return;
            }

            StopCoroutine(visibilityRoutine);
            visibilityRoutine = null;
        }
    }
}
