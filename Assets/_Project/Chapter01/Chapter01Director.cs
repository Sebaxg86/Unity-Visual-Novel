using System;
using System.Collections;
using EntreTuSilencio.Core;
using EntreTuSilencio.Dialogue;
using EntreTuSilencio.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace EntreTuSilencio.Chapter01
{
    [Serializable]
    public class ChapterChoiceBeat
    {
        [TextArea(2, 4)]
        public string prompt;

        public ChoiceOption[] options;
    }

    public enum Chapter01Beat
    {
        None,
        Intro,
        WaitingForPhoneClose,
        Room,
        Friends,
        FirstChoice,
        Hallway,
        SecondChoice,
        Cafeteria,
        ThirdChoice,
        Ending,
        Completed
    }

    [DisallowMultipleComponent]
    public class Chapter01Director : MonoBehaviour
    {
        [Header("Boot")]
        [SerializeField] private bool playOnStart = true;
        [SerializeField] private float openingFadeDuration = 0.45f;
        [SerializeField] private float endingFadeDuration = 0.75f;

        [Header("Scene References")]
        [SerializeField] private Image backgroundImage;
        [SerializeField] private FadeOverlayController fadeOverlayController;
        [SerializeField] private SceneFlowController sceneFlowController;
        [SerializeField] private DialogueController dialogueController;
        [SerializeField] private ChoiceController choiceController;
        [SerializeField] private PhoneOverlayController phoneOverlayController;
        [SerializeField] private TrustController trustController;

        [Header("Backgrounds")]
        [SerializeField] private Sprite introBackground;
        [SerializeField] private Sprite roomBackground;
        [SerializeField] private Sprite friendsBackground;
        [SerializeField] private Sprite hallwayBackground;
        [SerializeField] private Sprite cafeteriaBackground;

        [Header("Phone")]
        [SerializeField] private Sprite firstPhoneMessage;

        [Header("Dialogue")]
        [SerializeField] private DialogueLine[] introLines;
        [SerializeField] private DialogueLine[] roomLines;
        [SerializeField] private DialogueLine[] friendsLines;
        [SerializeField] private DialogueLine[] hallwayLines;
        [SerializeField] private DialogueLine[] cafeteriaLines;
        [SerializeField] private DialogueLine[] endingLines;

        [Header("Choices")]
        [SerializeField] private ChapterChoiceBeat firstChoice;
        [SerializeField] private ChapterChoiceBeat secondChoice;
        [SerializeField] private ChapterChoiceBeat thirdChoice;

        public Chapter01Beat CurrentBeat { get; private set; }

        private void OnEnable()
        {
            if (dialogueController != null)
            {
                dialogueController.SequenceFinished += HandleDialogueFinished;
            }

            if (choiceController != null)
            {
                choiceController.ChoiceSelected += HandleChoiceSelected;
            }

            if (phoneOverlayController != null)
            {
                phoneOverlayController.Closed += HandlePhoneClosed;
            }
        }

        private void OnDisable()
        {
            if (dialogueController != null)
            {
                dialogueController.SequenceFinished -= HandleDialogueFinished;
            }

            if (choiceController != null)
            {
                choiceController.ChoiceSelected -= HandleChoiceSelected;
            }

            if (phoneOverlayController != null)
            {
                phoneOverlayController.Closed -= HandlePhoneClosed;
            }
        }

        private void Start()
        {
            if (playOnStart)
            {
                BeginChapter();
            }
        }

        public void BeginChapter()
        {
            StopAllCoroutines();
            CurrentBeat = Chapter01Beat.None;

            if (choiceController != null)
            {
                choiceController.Hide();
            }

            if (phoneOverlayController != null)
            {
                phoneOverlayController.Hide();
            }

            if (trustController != null)
            {
                trustController.ResetTrust();
                trustController.HideTutorial();
            }

            StartCoroutine(BeginChapterRoutine());
        }

        public void ReturnToMainMenu()
        {
            if (sceneFlowController != null)
            {
                sceneFlowController.LoadMainMenu();
            }
        }

        private IEnumerator BeginChapterRoutine()
        {
            SetBackground(introBackground);

            if (fadeOverlayController != null)
            {
                fadeOverlayController.ShowInstant();
                yield return fadeOverlayController.PlayFadeFromBlack(openingFadeDuration);
            }

            BeginIntro();
        }

        private void BeginIntro()
        {
            CurrentBeat = Chapter01Beat.Intro;
            PlayDialogueOrContinue(introLines, BeginPhoneBeat);
        }

        private void BeginPhoneBeat()
        {
            SetBackground(roomBackground);
            CurrentBeat = Chapter01Beat.WaitingForPhoneClose;

            if (phoneOverlayController != null && firstPhoneMessage != null)
            {
                phoneOverlayController.Show(firstPhoneMessage);
                return;
            }

            BeginRoomDialogue();
        }

        private void HandlePhoneClosed()
        {
            if (CurrentBeat == Chapter01Beat.WaitingForPhoneClose)
            {
                BeginRoomDialogue();
            }
        }

        private void BeginRoomDialogue()
        {
            CurrentBeat = Chapter01Beat.Room;
            PlayDialogueOrContinue(roomLines, BeginFriendsDialogue);
        }

        private void BeginFriendsDialogue()
        {
            SetBackground(friendsBackground);
            CurrentBeat = Chapter01Beat.Friends;
            PlayDialogueOrContinue(friendsLines, BeginFirstChoice);
        }

        private void BeginFirstChoice()
        {
            CurrentBeat = Chapter01Beat.FirstChoice;

            if (trustController != null)
            {
                trustController.ShowTutorial();
            }

            ShowChoiceOrContinue(firstChoice, BeginHallwayDialogue);
        }

        private void BeginHallwayDialogue()
        {
            if (trustController != null)
            {
                trustController.HideTutorial();
            }

            SetBackground(hallwayBackground);
            CurrentBeat = Chapter01Beat.Hallway;
            PlayDialogueOrContinue(hallwayLines, BeginSecondChoice);
        }

        private void BeginSecondChoice()
        {
            CurrentBeat = Chapter01Beat.SecondChoice;
            ShowChoiceOrContinue(secondChoice, BeginCafeteriaDialogue);
        }

        private void BeginCafeteriaDialogue()
        {
            SetBackground(cafeteriaBackground);
            CurrentBeat = Chapter01Beat.Cafeteria;
            PlayDialogueOrContinue(cafeteriaLines, BeginThirdChoice);
        }

        private void BeginThirdChoice()
        {
            CurrentBeat = Chapter01Beat.ThirdChoice;
            ShowChoiceOrContinue(thirdChoice, BeginEndingDialogue);
        }

        private void BeginEndingDialogue()
        {
            CurrentBeat = Chapter01Beat.Ending;
            PlayDialogueOrContinue(endingLines, CompleteChapter);
        }

        private void CompleteChapter()
        {
            if (CurrentBeat == Chapter01Beat.Completed)
            {
                return;
            }

            CurrentBeat = Chapter01Beat.Completed;
            StartCoroutine(CompleteChapterRoutine());
        }

        private IEnumerator CompleteChapterRoutine()
        {
            if (fadeOverlayController != null)
            {
                yield return fadeOverlayController.PlayFadeToBlack(endingFadeDuration);
            }
        }

        private void HandleDialogueFinished()
        {
            switch (CurrentBeat)
            {
                case Chapter01Beat.Intro:
                    BeginPhoneBeat();
                    break;
                case Chapter01Beat.Room:
                    BeginFriendsDialogue();
                    break;
                case Chapter01Beat.Friends:
                    BeginFirstChoice();
                    break;
                case Chapter01Beat.Hallway:
                    BeginSecondChoice();
                    break;
                case Chapter01Beat.Cafeteria:
                    BeginThirdChoice();
                    break;
                case Chapter01Beat.Ending:
                    CompleteChapter();
                    break;
            }
        }

        private void HandleChoiceSelected(ChoiceOption selectedOption)
        {
            if (selectedOption != null && trustController != null)
            {
                trustController.ApplyDeltas(selectedOption.seongsuTrustDelta, selectedOption.jeonghoTrustDelta);
            }

            switch (CurrentBeat)
            {
                case Chapter01Beat.FirstChoice:
                    BeginHallwayDialogue();
                    break;
                case Chapter01Beat.SecondChoice:
                    BeginCafeteriaDialogue();
                    break;
                case Chapter01Beat.ThirdChoice:
                    BeginEndingDialogue();
                    break;
            }
        }

        private void PlayDialogueOrContinue(DialogueLine[] lines, Action onEmpty)
        {
            if (dialogueController == null)
            {
                onEmpty?.Invoke();
                return;
            }

            if (lines == null || lines.Length == 0)
            {
                onEmpty?.Invoke();
                return;
            }

            dialogueController.PlayLines(lines);
        }

        private void ShowChoiceOrContinue(ChapterChoiceBeat beat, Action onEmpty)
        {
            if (choiceController == null || beat == null || beat.options == null || beat.options.Length == 0)
            {
                onEmpty?.Invoke();
                return;
            }

            choiceController.ShowChoice(beat.prompt, beat.options);
        }

        private void SetBackground(Sprite backgroundSprite)
        {
            if (backgroundImage == null || backgroundSprite == null)
            {
                return;
            }

            backgroundImage.sprite = backgroundSprite;
        }
    }
}
