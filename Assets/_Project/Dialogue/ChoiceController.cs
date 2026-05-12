using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

        private readonly List<Button> spawnedButtons = new List<Button>();

        public event Action<ChoiceOption> ChoiceSelected;

        private void Awake()
        {
            if (rootCanvasGroup == null)
            {
                rootCanvasGroup = GetComponent<CanvasGroup>();
            }

            Hide();
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
                Button button = Instantiate(optionButtonPrefab, buttonContainer);
                button.gameObject.SetActive(true);

                TMP_Text label = button.GetComponentInChildren<TMP_Text>(true);
                if (label != null)
                {
                    label.text = option.label;
                }

                button.onClick.AddListener(() => HandleSelection(option));
                spawnedButtons.Add(button);
            }

            SetVisibility(true);
        }

        public void Hide()
        {
            ClearButtons();
            SetVisibility(false);
        }

        private void HandleSelection(ChoiceOption option)
        {
            ChoiceSelected?.Invoke(option);
            Hide();
        }

        private void ClearButtons()
        {
            for (int i = 0; i < spawnedButtons.Count; i++)
            {
                if (spawnedButtons[i] != null)
                {
                    Destroy(spawnedButtons[i].gameObject);
                }
            }

            spawnedButtons.Clear();
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
    }
}
