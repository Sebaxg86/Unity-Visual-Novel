using System;
using System.Collections;
using EntreTuSilencio.Core;
using EntreTuSilencio.Dialogue;
using EntreTuSilencio.Systems;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
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

    public enum CharacterExpression
    {
        Neutral,
        Talking,
        Confused,
        Happy,
        Tenderness,
        Upset,
        Sad,
        Angry,
        Shocked,
        Malicious
    }

    [Serializable]
    public class CharacterPortraitLibrary
    {
        public Sprite neutral;
        public Sprite talking;
        public Sprite confused;
        public Sprite happy;
        public Sprite tenderness;
        public Sprite upset;
        public Sprite sad;
        public Sprite angry;
        public Sprite shocked;
        public Sprite malicious;
    }

    public enum Chapter01Beat
    {
        None,
        Intro,
        WaitingForPhoneNotification,
        RoomFirstThought,
        RoomSecondThought,
        WaitingForPhoneClose,
        Room,
        RoomExploration,
        RoomInspectingBonsai,
        RoomInspectingProteinBar,
        Friends,
        FirstChoice,
        StreetWalk,
        Hallway,
        SecondChoice,
        DayTransition,
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
        [SerializeField] private bool useFallbackDataWhenEmpty = true;

        [Header("Canonical Intro")]
        [SerializeField] private bool useCanonicalIntroSequence = true;
        [SerializeField] private CanvasGroup introSavingCanvasGroup;
        [SerializeField] private CanvasGroup introChapterTitleCanvasGroup;
        [SerializeField] private CanvasGroup introMonologueCanvasGroup;
        [SerializeField] private TMP_Text introSavingText;
        [SerializeField] private TMP_Text introChapterNumberText;
        [SerializeField] private TMP_Text introChapterNameText;
        [SerializeField] private TMP_Text introMonologueText;
        [SerializeField] private float introBlackHoldDuration = 2f;
        [SerializeField] private float introSavingDuration = 4f;
        [SerializeField] private float introChapterTitleDuration = 4.5f;
        [SerializeField] private float introMonologuePauseDuration = 1.35f;
        [SerializeField] private float introWakeRevealDuration = 0.7f;
        [SerializeField] private float introMonologueCharactersPerSecond = 34f;

        [TextArea(1, 2)]
        [SerializeField] private string introSavingLabel = "Guardando...";

        [TextArea(1, 2)]
        [SerializeField] private string introChapterNumberLabel = "Capitulo 1";

        [TextArea(1, 2)]
        [SerializeField] private string introChapterNameLabel = "UN NUEVO COMIENZO";

        [TextArea(2, 5)]
        [SerializeField] private string introMonologueLine1 = "Uno pensaria que con los anos la vida se haria mas sencilla, que con cada dia el peso seria mas liviano, y vivir seria menos una carga.";

        [TextArea(2, 3)]
        [SerializeField] private string introMonologueLine2 = "Pero al parecer no.";

        [Header("Scene References")]
        [SerializeField] private Image backgroundImage;
        [SerializeField] private FadeOverlayController fadeOverlayController;
        [SerializeField] private SceneFlowController sceneFlowController;
        [SerializeField] private DialogueController dialogueController;
        [SerializeField] private ChoiceController choiceController;
        [SerializeField] private PhoneNotificationOverlayController phoneNotificationController;
        [SerializeField] private PhoneOverlayController phoneOverlayController;
        [SerializeField] private TrustController trustController;
        [SerializeField] private CanvasGroup roomExitCanvasGroup;
        [SerializeField] private Button roomExitButton;
        [SerializeField] private Button roomBonsaiButton;
        [SerializeField] private Button roomProteinBarButton;

        [Header("Backgrounds")]
        [SerializeField] private Sprite introBackground;
        [SerializeField] private Sprite roomBackground;
        [SerializeField] private Sprite friendsBackground;
        [SerializeField] private Sprite streetBackground;
        [SerializeField] private Sprite hallwayBackground;
        [SerializeField] private Sprite cafeteriaBackground;

        [Header("Character Portrait Libraries")]
        [SerializeField] private CharacterPortraitLibrary seongsuPortraits;
        [SerializeField] private CharacterPortraitLibrary jeonghoPortraits;

        [Header("Phone")]
        [TextArea(1, 2)]
        [SerializeField] private string firstPhoneNotificationSender = "Seongsu <3";

        [TextArea(2, 3)]
        [SerializeField] private string firstPhoneNotificationBody = "Andale baja, no dejare que tires tu vida a la borda.";

        [SerializeField] private Sprite firstPhoneMessage;
        [SerializeField] private Sprite secondPhoneMessage;

        [Header("Sign Animations")]
        [SerializeField] private Sprite[] jeonghoMentirosaSequence;
        [SerializeField] private float jeonghoMentirosaFrameDuration = 0.13f;

        [Header("Audio")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioClip introMusic;
        [SerializeField] private AudioClip roomMusic;
        [SerializeField] private AudioClip hallwayMusic;
        [SerializeField] private AudioClip cafeteriaMusic;
        [SerializeField] private AudioClip phoneNotificationSfx;
        [SerializeField] private AudioClip roomExitSfx;
        [SerializeField] private AudioClip choiceSelectedSfx;
        [SerializeField] private AudioClip chapterCompleteSfx;

        [Header("Canon Transitions")]
        [SerializeField] private float backgroundTransitionFadeDuration = 0.24f;
        [SerializeField] private float dayTimelapseFadeDuration = 0.5f;
        [SerializeField] private float dayTimelapseBlackHoldDuration = 0.75f;
        [SerializeField] private float finalPassiveEndingHoldDuration = 1.4f;

        [Header("Dialogue")]
        [SerializeField] private DialogueLine[] introLines;
        [SerializeField] private DialogueLine[] roomLines;
        [SerializeField] private DialogueLine[] roomAfterFirstMessageLines;
        [SerializeField] private DialogueLine[] roomAfterSecondMessageLines;
        [SerializeField] private DialogueLine[] roomBonsaiLines;
        [SerializeField] private DialogueLine[] roomProteinBarLines;
        [SerializeField] private DialogueLine[] friendsLines;
        [SerializeField] private DialogueLine[] streetWalkLines;
        [SerializeField] private DialogueLine[] hallwayLines;
        [SerializeField] private DialogueLine[] dayTransitionLines;
        [SerializeField] private DialogueLine[] cafeteriaLines;
        [SerializeField] private DialogueLine[] endingLines;

        [Header("Choices")]
        [SerializeField] private ChapterChoiceBeat firstChoice;
        [SerializeField] private ChapterChoiceBeat secondChoice;
        [SerializeField] private ChapterChoiceBeat thirdChoice;

        public Chapter01Beat CurrentBeat { get; private set; }

        private Action pendingDialogueCompletion;
        private Action pendingPhonePreviewAdvance;
        private Action pendingTrustTutorialContinuation;
        private bool hasShownTrustTutorial;
        private bool waitingForTrustTutorialClose;
        private float phonePreviewAdvanceInputUnlockTime;

        private void OnEnable()
        {
            if (dialogueController != null)
            {
                dialogueController.SequenceFinished += HandleDialogueFinished;
                dialogueController.LineShown += HandleDialogueLineShown;
            }

            if (choiceController != null)
            {
                choiceController.ChoiceSelected += HandleChoiceSelected;
            }

            if (phoneOverlayController != null)
            {
                phoneOverlayController.Closed += HandlePhoneClosed;
            }

            if (phoneNotificationController != null)
            {
                phoneNotificationController.Clicked += HandlePhoneNotificationClicked;
            }

            if (trustController != null)
            {
                trustController.TutorialClosed += HandleTrustTutorialClosed;
            }

            if (roomExitButton != null)
            {
                roomExitButton.onClick.AddListener(HandleRoomExitClicked);
            }

            if (roomBonsaiButton != null)
            {
                roomBonsaiButton.onClick.AddListener(HandleRoomBonsaiClicked);
            }

            if (roomProteinBarButton != null)
            {
                roomProteinBarButton.onClick.AddListener(HandleRoomProteinBarClicked);
            }
        }

        private void OnDisable()
        {
            if (dialogueController != null)
            {
                dialogueController.SequenceFinished -= HandleDialogueFinished;
                dialogueController.LineShown -= HandleDialogueLineShown;
            }

            if (choiceController != null)
            {
                choiceController.ChoiceSelected -= HandleChoiceSelected;
            }

            if (phoneOverlayController != null)
            {
                phoneOverlayController.Closed -= HandlePhoneClosed;
            }

            if (phoneNotificationController != null)
            {
                phoneNotificationController.Clicked -= HandlePhoneNotificationClicked;
            }

            if (trustController != null)
            {
                trustController.TutorialClosed -= HandleTrustTutorialClosed;
            }

            if (roomExitButton != null)
            {
                roomExitButton.onClick.RemoveListener(HandleRoomExitClicked);
            }

            if (roomBonsaiButton != null)
            {
                roomBonsaiButton.onClick.RemoveListener(HandleRoomBonsaiClicked);
            }

            if (roomProteinBarButton != null)
            {
                roomProteinBarButton.onClick.RemoveListener(HandleRoomProteinBarClicked);
            }
        }

        private void Start()
        {
            if (playOnStart)
            {
                BeginChapter();
            }
        }

        private void Update()
        {
            if (pendingPhonePreviewAdvance == null)
            {
                return;
            }

            if (Time.unscaledTime < phonePreviewAdvanceInputUnlockTime)
            {
                return;
            }

            if (!WasPhonePreviewAdvancePressed())
            {
                return;
            }

            ConsumePhonePreviewAdvance();
        }

        public void BeginChapter()
        {
            StopAllCoroutines();
            CurrentBeat = Chapter01Beat.None;
            pendingDialogueCompletion = null;
            pendingPhonePreviewAdvance = null;
            pendingTrustTutorialContinuation = null;
            hasShownTrustTutorial = false;
            waitingForTrustTutorialClose = false;

            if (dialogueController != null)
            {
                dialogueController.Hide();
            }

            if (choiceController != null)
            {
                choiceController.Hide();
            }

            if (phoneOverlayController != null)
            {
                phoneOverlayController.HideInstant();
                phoneOverlayController.SetCloseButtonVisible(true);
            }

            if (phoneNotificationController != null)
            {
                phoneNotificationController.Hide();
            }

            if (trustController != null)
            {
                trustController.ResetTrust();
                trustController.HideTutorial();
            }

            HideCanonicalIntroVisuals();
            SetCanvasGroupState(roomExitCanvasGroup, false);

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
            CurrentBeat = Chapter01Beat.Intro;
            PlayMusicIfNeeded(introMusic);

            if (ShouldUseCanonicalIntroSequence())
            {
                yield return PlayCanonicalIntroSequence();
                yield break;
            }

            SetBackground(introBackground);

            if (fadeOverlayController != null)
            {
                fadeOverlayController.ShowInstant();
                yield return fadeOverlayController.PlayFadeFromBlack(openingFadeDuration);
            }

            BeginIntro();
        }

        private bool ShouldUseCanonicalIntroSequence()
        {
            return useCanonicalIntroSequence
                && introSavingCanvasGroup != null
                && introChapterTitleCanvasGroup != null
                && introMonologueCanvasGroup != null
                && introSavingText != null
                && introChapterNumberText != null
                && introChapterNameText != null
                && introMonologueText != null
                && fadeOverlayController != null;
        }

        private IEnumerator PlayCanonicalIntroSequence()
        {
            ConfigureCanonicalIntroTexts();
            SetBackground(introBackground);
            fadeOverlayController.ShowInstant();

            if (introBlackHoldDuration > 0f)
            {
                yield return new WaitForSecondsRealtime(introBlackHoldDuration);
            }

            yield return ShowIntroGroupRoutine(introSavingCanvasGroup, introSavingDuration);
            yield return ShowIntroGroupRoutine(introChapterTitleCanvasGroup, introChapterTitleDuration);
            yield return ShowIntroMonologueRoutine();
            yield return BeginWakeIntoPhoneRoutine();
        }

        private IEnumerator ShowIntroGroupRoutine(CanvasGroup targetGroup, float visibleDuration)
        {
            SetCanvasGroupState(targetGroup, true);
            yield return fadeOverlayController.PlayFadeFromBlack(openingFadeDuration);

            if (visibleDuration > 0f)
            {
                yield return new WaitForSecondsRealtime(visibleDuration);
            }

            yield return fadeOverlayController.PlayFadeToBlack(openingFadeDuration);
            SetCanvasGroupState(targetGroup, false);
        }

        private IEnumerator ShowIntroMonologueRoutine()
        {
            SetCanvasGroupState(introMonologueCanvasGroup, true);
            introMonologueText.text = string.Empty;

            yield return fadeOverlayController.PlayFadeFromBlack(openingFadeDuration);
            yield return TypeTextRoutine(introMonologueText, introMonologueLine1, introMonologueCharactersPerSecond);

            if (introMonologuePauseDuration > 0f)
            {
                yield return new WaitForSecondsRealtime(introMonologuePauseDuration);
            }

            introMonologueText.text += "\n\n";
            yield return TypeTextRoutine(introMonologueText, introMonologueLine2, introMonologueCharactersPerSecond);
            yield return new WaitForSecondsRealtime(0.4f);
            yield return fadeOverlayController.PlayFadeToBlack(openingFadeDuration);
            SetCanvasGroupState(introMonologueCanvasGroup, false);
            introMonologueText.text = string.Empty;
        }

        private IEnumerator BeginWakeIntoPhoneRoutine()
        {
            SetBackground(roomBackground);
            PlayMusicIfNeeded(roomMusic);
            yield return fadeOverlayController.PlayFadeFromBlack(introWakeRevealDuration);
            BeginPhoneNotificationBeat();
        }

        private IEnumerator TypeTextRoutine(TMP_Text targetText, string content, float charactersPerSecond)
        {
            if (targetText == null || string.IsNullOrEmpty(content))
            {
                yield break;
            }

            if (charactersPerSecond <= 0f)
            {
                targetText.text += content;
                yield break;
            }

            float delay = 1f / charactersPerSecond;
            for (int i = 0; i < content.Length; i++)
            {
                targetText.text += content[i];
                yield return new WaitForSecondsRealtime(delay);
            }
        }

        private void ConfigureCanonicalIntroTexts()
        {
            if (introSavingText != null)
            {
                introSavingText.text = introSavingLabel;
            }

            if (introChapterNumberText != null)
            {
                introChapterNumberText.text = introChapterNumberLabel;
            }

            if (introChapterNameText != null)
            {
                introChapterNameText.text = introChapterNameLabel;
            }

            if (introMonologueText != null)
            {
                introMonologueText.text = string.Empty;
            }
        }

        private void HideCanonicalIntroVisuals()
        {
            SetCanvasGroupState(introSavingCanvasGroup, false);
            SetCanvasGroupState(introChapterTitleCanvasGroup, false);
            SetCanvasGroupState(introMonologueCanvasGroup, false);

            if (introMonologueText != null)
            {
                introMonologueText.text = string.Empty;
            }
        }

        private void BeginIntro()
        {
            CurrentBeat = Chapter01Beat.Intro;
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.Intro), BeginPhoneNotificationBeat);
        }

        private void BeginPhoneNotificationBeat()
        {
            SetBackground(roomBackground);
            CurrentBeat = Chapter01Beat.WaitingForPhoneNotification;
            PlayMusicIfNeeded(roomMusic);

            if (dialogueController != null)
            {
                dialogueController.Hide();
            }

            if (trustController != null)
            {
                trustController.HideHud();
            }

            if (phoneOverlayController != null)
            {
                phoneOverlayController.HideInstant();
            }

            if (phoneNotificationController != null)
            {
                PlaySfx(phoneNotificationSfx);
                phoneNotificationController.Show(firstPhoneNotificationSender, firstPhoneNotificationBody);
                return;
            }

            BeginFirstPhoneMessageBeat();
        }

        private void HandlePhoneNotificationClicked()
        {
            if (CurrentBeat != Chapter01Beat.WaitingForPhoneNotification)
            {
                return;
            }

            BeginFirstPhoneMessageBeat();
        }

        private void BeginFirstPhoneMessageBeat()
        {
            CurrentBeat = Chapter01Beat.RoomFirstThought;

            if (phoneOverlayController != null)
            {
                phoneOverlayController.SetCloseButtonVisible(false);

                if (firstPhoneMessage != null)
                {
                    phoneOverlayController.Show(firstPhoneMessage);
                }
            }

            WaitForPhonePreviewAdvance(BeginFirstRoomThoughtSequence);
        }

        private void BeginSecondPhoneMessageBeat()
        {
            CurrentBeat = Chapter01Beat.RoomSecondThought;

            PlaySfx(phoneNotificationSfx);

            if (phoneOverlayController != null)
            {
                phoneOverlayController.SetCloseButtonVisible(false);

                if (secondPhoneMessage != null)
                {
                    phoneOverlayController.Show(secondPhoneMessage);
                }
            }

            WaitForPhonePreviewAdvance(BeginSecondRoomThoughtSequence);
        }

        private void WaitForPhoneClose()
        {
            CurrentBeat = Chapter01Beat.WaitingForPhoneClose;

            if (dialogueController != null)
            {
                dialogueController.Hide();
            }

            if (phoneOverlayController != null)
            {
                if (secondPhoneMessage != null)
                {
                    phoneOverlayController.Show(secondPhoneMessage);
                }

                phoneOverlayController.SetCloseButtonVisible(true);

                if (!phoneOverlayController.IsVisible)
                {
                    BeginRoomExploration();
                }
            }
            else
            {
                BeginRoomExploration();
            }
        }

        private void BeginFirstRoomThoughtSequence()
        {
            PlayDialogueSequenceOrContinue(GetRoomFirstThoughtLines(), BeginSecondPhoneMessageBeat);
        }

        private void BeginSecondRoomThoughtSequence()
        {
            PlayDialogueSequenceOrContinue(GetRoomSecondThoughtLines(), WaitForPhoneClose);
        }

        private void WaitForPhonePreviewAdvance(Action nextStep)
        {
            if (nextStep == null)
            {
                return;
            }

            if (phoneOverlayController == null || !phoneOverlayController.IsVisible)
            {
                nextStep.Invoke();
                return;
            }

            pendingPhonePreviewAdvance = nextStep;
            phonePreviewAdvanceInputUnlockTime = Time.unscaledTime + 0.12f;
        }

        private void ConsumePhonePreviewAdvance()
        {
            if (pendingPhonePreviewAdvance == null)
            {
                return;
            }

            Action nextStep = pendingPhonePreviewAdvance;
            pendingPhonePreviewAdvance = null;

            if (phoneOverlayController != null && phoneOverlayController.IsVisible)
            {
                phoneOverlayController.HideAfterAnimation(nextStep);
                return;
            }

            nextStep.Invoke();
        }

        private bool WasPhonePreviewAdvancePressed()
        {
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                return true;
            }

            if (Touchscreen.current == null)
            {
                return false;
            }

            return Touchscreen.current.primaryTouch.press.wasPressedThisFrame;
        }

        private void HandlePhoneClosed()
        {
            if (CurrentBeat == Chapter01Beat.WaitingForPhoneClose)
            {
                BeginRoomExploration();
            }
        }

        private void BeginRoomDialogue()
        {
            CurrentBeat = Chapter01Beat.Room;

            if (trustController != null)
            {
                trustController.HideHud();
            }

            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.Room), BeginRoomExploration);
        }

        private void BeginRoomExploration()
        {
            if (roomExitCanvasGroup == null && roomExitButton == null)
            {
                BeginFriendsDialogue();
                return;
            }

            CurrentBeat = Chapter01Beat.RoomExploration;
            SetCanvasGroupState(roomExitCanvasGroup, true);

            if (dialogueController != null)
            {
                dialogueController.Hide();
            }

            if (trustController != null)
            {
                trustController.HideHud();
            }
        }

        private void BeginFriendsDialogue()
        {
            StartCoroutine(BeginFriendsDialogueRoutine());
        }

        private IEnumerator BeginFriendsDialogueRoutine()
        {
            yield return PlayBackgroundTransitionRoutine(friendsBackground);
            CurrentBeat = Chapter01Beat.Friends;
            PlayMusicIfNeeded(roomMusic);
            PlayFriendsDialogueOrContinue();
        }

        private void BeginFirstChoice()
        {
            CurrentBeat = Chapter01Beat.FirstChoice;
            ShowChoiceOrContinue(GetChoiceBeatFor(Chapter01Beat.FirstChoice), BeginStreetWalkDialogue);
        }

        private void BeginStreetWalkDialogue()
        {
            if (trustController != null)
            {
                trustController.HideTutorial();
            }

            StartCoroutine(BeginStreetWalkDialogueRoutine());
        }

        private IEnumerator BeginStreetWalkDialogueRoutine()
        {
            yield return PlayBackgroundTransitionRoutine(streetBackground != null ? streetBackground : friendsBackground);
            CurrentBeat = Chapter01Beat.StreetWalk;
            PlayMusicIfNeeded(hallwayMusic);
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.StreetWalk), BeginHallwayDialogue);
        }

        private void BeginHallwayDialogue()
        {
            StartCoroutine(BeginHallwayDialogueRoutine());
        }

        private IEnumerator BeginHallwayDialogueRoutine()
        {
            if (dialogueController != null)
            {
                dialogueController.Hide();
            }

            if (trustController != null)
            {
                trustController.HideHud();
            }

            if (fadeOverlayController != null)
            {
                yield return fadeOverlayController.PlayFadeToBlack(dayTimelapseFadeDuration);
            }

            SetBackground(hallwayBackground != null ? hallwayBackground : streetBackground);

            if (fadeOverlayController != null)
            {
                yield return fadeOverlayController.PlayFadeFromBlack(dayTimelapseFadeDuration);
            }

            CurrentBeat = Chapter01Beat.Hallway;
            PlayMusicIfNeeded(hallwayMusic);
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.Hallway), BeginSecondChoice);
        }

        private void BeginSecondChoice()
        {
            CurrentBeat = Chapter01Beat.SecondChoice;
            ShowChoiceOrContinue(GetChoiceBeatFor(Chapter01Beat.SecondChoice), BeginDayTransitionBeat);
        }

        private void BeginDayTransitionBeat()
        {
            if (CurrentBeat == Chapter01Beat.Completed)
            {
                return;
            }

            StartCoroutine(BeginDayTransitionRoutine());
        }

        private IEnumerator BeginDayTransitionRoutine()
        {
            CurrentBeat = Chapter01Beat.DayTransition;

            if (dialogueController != null)
            {
                dialogueController.Hide();
            }

            if (choiceController != null)
            {
                choiceController.Hide();
            }

            if (trustController != null)
            {
                trustController.HideHud();
            }

            if (fadeOverlayController != null)
            {
                yield return fadeOverlayController.PlayFadeToBlack(dayTimelapseFadeDuration);

                if (dayTimelapseBlackHoldDuration > 0f)
                {
                    yield return new WaitForSecondsRealtime(dayTimelapseBlackHoldDuration);
                }

                SetBackground(hallwayBackground != null ? hallwayBackground : friendsBackground);
                yield return fadeOverlayController.PlayFadeFromBlack(dayTimelapseFadeDuration);
            }

            PlayDialogueSequenceOrContinue(GetDialogueLinesForBeat(Chapter01Beat.DayTransition), TransitionIntoCafeteria);
        }

        private void TransitionIntoCafeteria()
        {
            StartCoroutine(TransitionIntoCafeteriaRoutine());
        }

        private IEnumerator TransitionIntoCafeteriaRoutine()
        {
            if (dialogueController != null)
            {
                dialogueController.Hide();
            }

            if (fadeOverlayController != null)
            {
                yield return fadeOverlayController.PlayFadeToBlack(dayTimelapseFadeDuration);
            }

            SetBackground(cafeteriaBackground);

            if (fadeOverlayController != null)
            {
                yield return fadeOverlayController.PlayFadeFromBlack(dayTimelapseFadeDuration);
            }

            BeginCafeteriaDialogue();
        }

        private void BeginCafeteriaDialogue()
        {
            SetBackground(cafeteriaBackground);
            CurrentBeat = Chapter01Beat.Cafeteria;
            PlayMusicIfNeeded(cafeteriaMusic);
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.Cafeteria), BeginThirdChoice);
        }

        private void BeginThirdChoice()
        {
            CurrentBeat = Chapter01Beat.ThirdChoice;
            ShowChoiceOrContinue(GetChoiceBeatFor(Chapter01Beat.ThirdChoice), BeginEndingDialogue);
        }

        private void BeginEndingDialogue()
        {
            CurrentBeat = Chapter01Beat.Ending;
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.Ending), CompleteChapter);
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
            PlaySfx(chapterCompleteSfx);

            if (fadeOverlayController != null)
            {
                yield return fadeOverlayController.PlayFadeToBlack(endingFadeDuration);
            }
        }

        private void HandleDialogueFinished()
        {
            if (pendingDialogueCompletion != null)
            {
                Action completion = pendingDialogueCompletion;
                pendingDialogueCompletion = null;
                completion.Invoke();
                return;
            }

            switch (CurrentBeat)
            {
                case Chapter01Beat.Intro:
                    BeginPhoneNotificationBeat();
                    break;
                case Chapter01Beat.Room:
                    BeginRoomExploration();
                    break;
                case Chapter01Beat.RoomInspectingBonsai:
                    BeginRoomExploration();
                    break;
                case Chapter01Beat.RoomInspectingProteinBar:
                    BeginRoomExploration();
                    break;
                case Chapter01Beat.Friends:
                    BeginFirstChoice();
                    break;
                case Chapter01Beat.StreetWalk:
                    BeginHallwayDialogue();
                    break;
                case Chapter01Beat.Hallway:
                    BeginSecondChoice();
                    break;
                case Chapter01Beat.DayTransition:
                    TransitionIntoCafeteria();
                    break;
                case Chapter01Beat.Cafeteria:
                    BeginThirdChoice();
                    break;
                case Chapter01Beat.Ending:
                    CompleteChapter();
                    break;
            }
        }

        private void HandleDialogueLineShown(int index, DialogueLine line)
        {
            if (trustController != null)
            {
                if (line != null && (line.speakerMode == DialogueSpeakerMode.Thought || line.speakerMode == DialogueSpeakerMode.Narration))
                {
                    trustController.HideHud();
                }

                TrustHudFocus focus = ResolveTrustHudFocus(line);
                if (focus != TrustHudFocus.None)
                {
                    trustController.SetHudFocus(focus);

                    bool waitingToShowTutorial = CurrentBeat == Chapter01Beat.Friends
                        && index == 0
                        && !hasShownTrustTutorial;

                    if (!trustController.IsTutorialVisible && !waitingToShowTutorial)
                    {
                        trustController.ShowHud();
                    }
                }
            }
        }

        private void HandleChoiceSelected(ChoiceOption selectedOption)
        {
            PlaySfx(choiceSelectedSfx);

            if (selectedOption != null && trustController != null)
            {
                ApplyTrustHudFocusForChoice(selectedOption);
                trustController.ApplyDeltas(selectedOption.seongsuTrustDelta, selectedOption.jeonghoTrustDelta);
            }

            switch (CurrentBeat)
            {
                case Chapter01Beat.FirstChoice:
                    PlayPostChoiceDialogueOrContinue(
                        Chapter01Beat.FirstChoice,
                        selectedOption,
                        BeginStreetWalkDialogue);
                    break;
                case Chapter01Beat.SecondChoice:
                    PlayPostChoiceDialogueOrContinue(
                        Chapter01Beat.SecondChoice,
                        selectedOption,
                        BeginDayTransitionBeat);
                    break;
                case Chapter01Beat.ThirdChoice:
                    PlayPostChoiceDialogueOrContinue(
                        Chapter01Beat.ThirdChoice,
                        selectedOption,
                        GetThirdChoiceEndingContinuation(selectedOption));
                    break;
            }
        }

        private Action GetThirdChoiceEndingContinuation(ChoiceOption selectedOption)
        {
            if (selectedOption != null && selectedOption.optionId == "just_watch_again")
            {
                return BeginEndingDialogueAfterPassiveHold;
            }

            return BeginEndingDialogue;
        }

        private void BeginEndingDialogueAfterPassiveHold()
        {
            StartCoroutine(BeginEndingDialogueAfterPassiveHoldRoutine());
        }

        private IEnumerator BeginEndingDialogueAfterPassiveHoldRoutine()
        {
            if (finalPassiveEndingHoldDuration > 0f)
            {
                yield return new WaitForSecondsRealtime(finalPassiveEndingHoldDuration);
            }

            BeginEndingDialogue();
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

            PrepareDialogueLines(lines);
            dialogueController.PlayLines(lines);
        }

        private void PlayFriendsDialogueOrContinue()
        {
            DialogueLine[] lines = GetDialogueLinesForBeat(Chapter01Beat.Friends);
            if (dialogueController == null || lines == null || lines.Length == 0)
            {
                BeginFirstChoice();
                return;
            }

            if (trustController == null || hasShownTrustTutorial || lines.Length == 1)
            {
                PlayDialogueOrContinue(lines, BeginFirstChoice);
                return;
            }

            PrepareDialogueLines(lines);

            DialogueLine[] firstSegment = new[] { lines[0] };
            DialogueLine[] remainingSegment = SliceDialogueLines(lines, 1);

            pendingTrustTutorialContinuation = () =>
            {
                if (remainingSegment == null || remainingSegment.Length == 0)
                {
                    BeginFirstChoice();
                    return;
                }

                PlayDialogueSequenceOrContinue(remainingSegment, BeginFirstChoice);
            };

            pendingDialogueCompletion = ShowFriendsTrustTutorialAfterFirstLine;
            dialogueController.PlayLines(firstSegment);
        }

        private void PlayDialogueSequenceOrContinue(DialogueLine[] lines, Action onFinished)
        {
            if (dialogueController == null || lines == null || lines.Length == 0)
            {
                onFinished?.Invoke();
                return;
            }

            PrepareDialogueLines(lines);
            pendingDialogueCompletion = onFinished;
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

        private void PlayPostChoiceDialogueOrContinue(
            Chapter01Beat choiceBeat,
            ChoiceOption selectedOption,
            Action onEmptyOrFinished)
        {
            DialogueLine[] lines = GetPostChoiceLines(choiceBeat, selectedOption);

            if (dialogueController == null || lines == null || lines.Length == 0)
            {
                onEmptyOrFinished?.Invoke();
                return;
            }

            PrepareDialogueLines(lines);
            pendingDialogueCompletion = onEmptyOrFinished;
            dialogueController.PlayLines(lines);
        }

        private void PrepareDialogueLines(DialogueLine[] lines)
        {
            if (lines == null)
            {
                return;
            }

            for (int i = 0; i < lines.Length; i++)
            {
                ApplySpecialLineOverrides(lines[i]);
            }
        }

        private void ShowFriendsTrustTutorialAfterFirstLine()
        {
            if (trustController == null || hasShownTrustTutorial)
            {
                ContinueAfterTrustTutorial();
                return;
            }

            hasShownTrustTutorial = true;

            if (!trustController.HasTutorial)
            {
                trustController.ShowHud();
                ContinueAfterTrustTutorial();
                return;
            }

            waitingForTrustTutorialClose = true;
            trustController.ShowTutorial();
        }

        private void HandleTrustTutorialClosed()
        {
            if (!waitingForTrustTutorialClose)
            {
                return;
            }

            waitingForTrustTutorialClose = false;
            ContinueAfterTrustTutorial();
        }

        private void ContinueAfterTrustTutorial()
        {
            Action continuation = pendingTrustTutorialContinuation;
            pendingTrustTutorialContinuation = null;
            continuation?.Invoke();
        }

        private void ApplySpecialLineOverrides(DialogueLine line)
        {
            if (!IsJeonghoMentirosaLine(line))
            {
                return;
            }

            if (!HasAssignedSequence(jeonghoMentirosaSequence) || HasAssignedSequence(line.rightPortraitSequence))
            {
                return;
            }

            line.rightPortraitSequence = jeonghoMentirosaSequence;
            line.portraitSequenceFrameDuration = jeonghoMentirosaFrameDuration;

            Sprite sequenceStart = GetFirstAssignedSprite(jeonghoMentirosaSequence);
            if (sequenceStart != null)
            {
                line.rightPortrait = sequenceStart;
            }
        }

        private bool IsJeonghoMentirosaLine(DialogueLine line)
        {
            return line != null
                && line.speakerMode == DialogueSpeakerMode.Signed
                && !string.IsNullOrWhiteSpace(line.speakerName)
                && line.speakerName.Equals("Jeongho", StringComparison.OrdinalIgnoreCase)
                && !string.IsNullOrWhiteSpace(line.text)
                && line.text.Trim().Equals("Mentirosa", StringComparison.OrdinalIgnoreCase);
        }

        private bool HasAssignedSequence(Sprite[] sequence)
        {
            if (sequence == null || sequence.Length == 0)
            {
                return false;
            }

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] != null)
                {
                    return true;
                }
            }

            return false;
        }

        private Sprite GetFirstAssignedSprite(Sprite[] sequence)
        {
            if (sequence == null)
            {
                return null;
            }

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] != null)
                {
                    return sequence[i];
                }
            }

            return null;
        }

        private DialogueLine[] SliceDialogueLines(DialogueLine[] sourceLines, int startIndex)
        {
            if (sourceLines == null || startIndex >= sourceLines.Length)
            {
                return null;
            }

            int length = sourceLines.Length - startIndex;
            DialogueLine[] slice = new DialogueLine[length];
            Array.Copy(sourceLines, startIndex, slice, 0, length);
            return slice;
        }

        private void SetBackground(Sprite backgroundSprite)
        {
            if (backgroundImage == null || backgroundSprite == null)
            {
                return;
            }

            backgroundImage.sprite = backgroundSprite;
        }

        private IEnumerator PlayBackgroundTransitionRoutine(Sprite targetBackground)
        {
            if (targetBackground == null)
            {
                yield break;
            }

            if (fadeOverlayController == null || backgroundTransitionFadeDuration <= 0f)
            {
                SetBackground(targetBackground);
                yield break;
            }

            yield return fadeOverlayController.PlayFadeToBlack(backgroundTransitionFadeDuration);
            SetBackground(targetBackground);
            yield return fadeOverlayController.PlayFadeFromBlack(backgroundTransitionFadeDuration);
        }

        private void HandleRoomExitClicked()
        {
            if (CurrentBeat != Chapter01Beat.RoomExploration)
            {
                return;
            }

            SetCanvasGroupState(roomExitCanvasGroup, false);
            PlaySfx(roomExitSfx);
            BeginFriendsDialogue();
        }

        private void HandleRoomBonsaiClicked()
        {
            if (CurrentBeat != Chapter01Beat.RoomExploration)
            {
                return;
            }

            CurrentBeat = Chapter01Beat.RoomInspectingBonsai;
            SetCanvasGroupState(roomExitCanvasGroup, false);
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.RoomInspectingBonsai), BeginRoomExploration);
        }

        private void HandleRoomProteinBarClicked()
        {
            if (CurrentBeat != Chapter01Beat.RoomExploration)
            {
                return;
            }

            CurrentBeat = Chapter01Beat.RoomInspectingProteinBar;
            SetCanvasGroupState(roomExitCanvasGroup, false);
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.RoomInspectingProteinBar), BeginRoomExploration);
        }

        private void SetCanvasGroupState(CanvasGroup canvasGroup, bool visible)
        {
            if (canvasGroup == null)
            {
                return;
            }

            canvasGroup.alpha = visible ? 1f : 0f;
            canvasGroup.interactable = visible;
            canvasGroup.blocksRaycasts = visible;
        }

        private void PlayMusicIfNeeded(AudioClip clip)
        {
            if (musicSource == null || clip == null)
            {
                return;
            }

            if (musicSource.clip == clip && musicSource.isPlaying)
            {
                return;
            }

            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }

        private void PlaySfx(AudioClip clip)
        {
            if (sfxSource == null || clip == null)
            {
                return;
            }

            sfxSource.PlayOneShot(clip);
        }

        private void ApplyTrustHudFocusForChoice(ChoiceOption selectedOption)
        {
            if (trustController == null || selectedOption == null)
            {
                return;
            }

            bool affectsSeongsu = selectedOption.seongsuTrustDelta != 0;
            bool affectsJeongho = selectedOption.jeonghoTrustDelta != 0;

            if (affectsSeongsu == affectsJeongho)
            {
                return;
            }

            trustController.SetHudFocus(affectsSeongsu ? TrustHudFocus.Seongsu : TrustHudFocus.Jeongho);
        }

        private TrustHudFocus ResolveTrustHudFocus(DialogueLine line)
        {
            if (line == null)
            {
                return TrustHudFocus.None;
            }

            if (!string.IsNullOrWhiteSpace(line.speakerName))
            {
                if (line.speakerName.Equals("Seongsu", StringComparison.OrdinalIgnoreCase))
                {
                    return TrustHudFocus.Seongsu;
                }

                if (line.speakerName.Equals("Jeongho", StringComparison.OrdinalIgnoreCase))
                {
                    return TrustHudFocus.Jeongho;
                }
            }

            return line.portraitFocus switch
            {
                PortraitFocus.Left => TrustHudFocus.Seongsu,
                PortraitFocus.Right => TrustHudFocus.Jeongho,
                _ => TrustHudFocus.None
            };
        }

        private DialogueLine[] GetRoomFirstThoughtLines()
        {
            if (roomAfterFirstMessageLines != null && roomAfterFirstMessageLines.Length > 0)
            {
                return roomAfterFirstMessageLines;
            }

            if (roomLines != null && roomLines.Length > 0)
            {
                return roomLines;
            }

            if (!useFallbackDataWhenEmpty)
            {
                return null;
            }

            return new[]
            {
                CreateLine("Jihuun", "Por que me cuesta tanto? Lo intento, de verdad lo intento, pero siempre siento que estoy un paso atras, como si nunca pudiera alcanzar lo que se espera de mi.", DialogueSpeakerMode.Thought),
                CreateLine("Jihuun", "No entiendo por que todo parece tan sencillo para los demas y yo sigo aqui, atrapada en mi propio ritmo.", DialogueSpeakerMode.Thought),
            };
        }

        private DialogueLine[] GetRoomSecondThoughtLines()
        {
            if (roomAfterSecondMessageLines != null && roomAfterSecondMessageLines.Length > 0)
            {
                return roomAfterSecondMessageLines;
            }

            if (!useFallbackDataWhenEmpty)
            {
                return null;
            }

            return new[]
            {
                CreateLine("Jihuun", "...Supongo que no tengo otra opcion.", DialogueSpeakerMode.Thought),
            };
        }

        private DialogueLine[] GetDialogueLinesForBeat(Chapter01Beat beat)
        {
            DialogueLine[] configuredLines = beat switch
            {
                Chapter01Beat.Intro => introLines,
                Chapter01Beat.Room => roomLines,
                Chapter01Beat.RoomInspectingBonsai => roomBonsaiLines,
                Chapter01Beat.RoomInspectingProteinBar => roomProteinBarLines,
                Chapter01Beat.Friends => friendsLines,
                Chapter01Beat.StreetWalk => streetWalkLines,
                Chapter01Beat.Hallway => hallwayLines,
                Chapter01Beat.DayTransition => dayTransitionLines,
                Chapter01Beat.Cafeteria => cafeteriaLines,
                Chapter01Beat.Ending => endingLines,
                _ => null
            };

            if (configuredLines != null && configuredLines.Length > 0)
            {
                return configuredLines;
            }

            return useFallbackDataWhenEmpty ? BuildFallbackLines(beat) : null;
        }

        private ChapterChoiceBeat GetChoiceBeatFor(Chapter01Beat beat)
        {
            ChapterChoiceBeat configuredChoice = beat switch
            {
                Chapter01Beat.FirstChoice => firstChoice,
                Chapter01Beat.SecondChoice => secondChoice,
                Chapter01Beat.ThirdChoice => thirdChoice,
                _ => null
            };

            if (configuredChoice != null && configuredChoice.options != null && configuredChoice.options.Length > 0)
            {
                return configuredChoice;
            }

            return useFallbackDataWhenEmpty ? BuildFallbackChoice(beat) : null;
        }

        private DialogueLine[] GetPostChoiceLines(Chapter01Beat beat, ChoiceOption selectedOption)
        {
            if (!useFallbackDataWhenEmpty || selectedOption == null)
            {
                return null;
            }

            return BuildFallbackPostChoiceLines(beat, selectedOption);
        }

        private DialogueLine[] BuildFallbackLines(Chapter01Beat beat)
        {
            Sprite leftPortrait = dialogueController != null ? dialogueController.LeftPortraitSprite : null;
            Sprite rightPortrait = dialogueController != null ? dialogueController.RightPortraitSprite : null;

            Sprite seongsuNeutral = GetSeongsuPortrait(CharacterExpression.Neutral, leftPortrait);
            Sprite seongsuTalking = GetSeongsuPortrait(CharacterExpression.Talking, leftPortrait);
            Sprite seongsuConfused = GetSeongsuPortrait(CharacterExpression.Confused, leftPortrait);
            Sprite seongsuHappy = GetSeongsuPortrait(CharacterExpression.Happy, leftPortrait);
            Sprite seongsuTenderness = GetSeongsuPortrait(CharacterExpression.Tenderness, leftPortrait);
            Sprite seongsuUpset = GetSeongsuPortrait(CharacterExpression.Upset, leftPortrait);

            Sprite jeonghoNeutral = GetJeonghoPortrait(CharacterExpression.Neutral, rightPortrait);
            Sprite jeonghoTalking = GetJeonghoPortrait(CharacterExpression.Talking, rightPortrait);
            Sprite jeonghoHappy = GetJeonghoPortrait(CharacterExpression.Happy, rightPortrait);
            Sprite jeonghoTenderness = GetJeonghoPortrait(CharacterExpression.Tenderness, rightPortrait);

            switch (beat)
            {
                case Chapter01Beat.Intro:
                    return new[]
                    {
                        CreateLine("Jihuun", "Uno pensaria que con los anos la vida se haria mas sencilla, que con cada dia el peso seria mas liviano, y vivir seria menos una carga.", DialogueSpeakerMode.Thought),
                        CreateLine("Jihuun", "Pero al parecer no.", DialogueSpeakerMode.Thought),
                    };
                case Chapter01Beat.Room:
                    return new[]
                    {
                        CreateLine("Jihuun", "Por que me cuesta tanto? Lo intento, de verdad lo intento, pero siempre siento que estoy un paso atras, como si nunca pudiera alcanzar lo que se espera de mi.", DialogueSpeakerMode.Thought),
                        CreateLine("Jihuun", "No entiendo por que todo parece tan sencillo para los demas y yo sigo aqui, atrapada en mi propio ritmo.", DialogueSpeakerMode.Thought),
                        CreateLine("Jihuun", "...Supongo que no tengo otra opcion.", DialogueSpeakerMode.Thought),
                    };
                case Chapter01Beat.RoomInspectingBonsai:
                    return new[]
                    {
                        CreateLine("Jihuun", "El bonsai sigue aqui, impecable.", DialogueSpeakerMode.Thought),
                        CreateLine("Jihuun", "Cuidarlo siempre me obliga a bajar el ritmo un poco.", DialogueSpeakerMode.Thought),
                    };
                case Chapter01Beat.RoomInspectingProteinBar:
                    return new[]
                    {
                        CreateLine("Jihuun", "La barra de proteina sigue donde la deje.", DialogueSpeakerMode.Thought),
                        CreateLine("Jihuun", "Tal vez deberia llevarmela. Con Seongsu nunca se sabe cuanto va a durar la salida.", DialogueSpeakerMode.Thought),
                    };
                case Chapter01Beat.Friends:
                    return new[]
                    {
                        CreateLine("Seongsu", "Hasta que te dignas en salir! Se me iba a quemar la cabeza aqui afuera.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, seongsuUpset, null),
                        CreateLine("Jeongho", "Ya, ya salio, no generes mas drama.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, seongsuUpset, jeonghoTenderness),
                        CreateLine("Jeongho", "Ya ya, ten. Se nota que lo necesitas.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, seongsuUpset, jeonghoTalking),
                        CreateLine("Jihuun", "Una barra de proteina, muy creativo jajaja.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuUpset, jeonghoTenderness),
                    };
                case Chapter01Beat.StreetWalk:
                    return new[]
                    {
                        CreateLine("Jihuun", "Me alegra estar con ellos... Aqui no siento que falte algo.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                        CreateLine(string.Empty, "Estar con ellos la hacia olvidar sus problemas, aunque fuera por un rato. Eran como su pequeno refugio. Con ellos no importaba si a veces no podia hablar. No sentia que sobrara, como en otros lugares. De alguna manera, su conexion traspasaba esas barreras invisibles que tanto la frenaban.", DialogueSpeakerMode.Narration, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                        CreateLine("Seongsu", "Estas bien?", DialogueSpeakerMode.Spoken, PortraitFocus.Left, seongsuTenderness, jeonghoTenderness),
                        CreateLine("Jihuun", "Estoy cansada", DialogueSpeakerMode.Signed, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                        CreateLine("Jeongho", "Mentirosa", DialogueSpeakerMode.Signed, PortraitFocus.Right, seongsuConfused, jeonghoTalking),
                        CreateLine("Jihuun", "A veces... me siento atrapada en mi propia cabeza.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                        CreateLine("Jeongho", "Pero te dejaremos tranquila... por ahora.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, seongsuTenderness, jeonghoTenderness),
                        CreateLine("Jihuun", "Cada vez que alguien me pregunta por que no hablo, siento que me estoy ahogando un poco mas...", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                        CreateLine("Jihuun", "La gente no entiende lo agotador que es tener que depender siempre de los demas para comunicarme. A veces me siento atrapada en mi propia cabeza y en mis propios recuerdos.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                    };
                case Chapter01Beat.Hallway:
                    return new[]
                    {
                        CreateLine("Jihuun", "Todos hablan...", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                        CreateLine("Jihuun", "Todos rien...", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                        CreateLine("Jihuun", "Y yo...", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                        CreateLine("Jihuun", "Estoy aqui.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                        CreateLine("Jihuun", "Pero no me siento presente.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                    };
                case Chapter01Beat.DayTransition:
                    return new[]
                    {
                        CreateLine("Seongsu", "Ven! Vamos a la cafe.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, seongsuHappy, null),
                    };
                case Chapter01Beat.Cafeteria:
                    return new[]
                    {
                        CreateLine(string.Empty, "La manana paso como todas las demas: clases, notas, miradas rapidas entre los companeros. Jihuun se sentia como una sombra, como si no pudiera encajar completamente, pero al mismo tiempo, no queria llamar la atencion.", DialogueSpeakerMode.Narration, PortraitFocus.None, seongsuConfused, jeonghoNeutral),
                        CreateLine("Seongsu", "Sabes que se me antoja? Un pastel de mango.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, seongsuConfused, null),
                        CreateLine("Jeongho", "Te tropezaste con una planta, no salvaste el mundo.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, seongsuConfused, jeonghoNeutral),
                        CreateLine("Seongsu", "Y tu que vas a pedir?", DialogueSpeakerMode.Spoken, PortraitFocus.Left, seongsuConfused, jeonghoNeutral),
                        CreateLine("Jihuun", "Jugo de durazno", DialogueSpeakerMode.Signed, PortraitFocus.None, seongsuConfused, jeonghoNeutral),
                        CreateLine("Jeongho", "Obvio. Desde que te conozco, la mas adicta al jugo de durazno.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, seongsuConfused, jeonghoNeutral),
                        CreateLine(string.Empty, "Seongsu sonrio con carino y fue a hacer el pedido.", DialogueSpeakerMode.Narration, PortraitFocus.None, seongsuTenderness, jeonghoNeutral),
                        CreateLine(string.Empty, "Jeongho saco su celular para ensenarle a Jihuun un video absurdo de un gato atrapado en una bolsa de papel.", DialogueSpeakerMode.Narration, PortraitFocus.None, seongsuTenderness, jeonghoTalking),
                        CreateLine(string.Empty, "Jihuun se rio bajito al verlo forcejear con la bolsa.", DialogueSpeakerMode.Narration, PortraitFocus.None, seongsuTenderness, jeonghoHappy),
                        CreateLine(string.Empty, "Seongsu volvio con la bandeja: dos pasteles, un cafe americano y su jugo de durazno.", DialogueSpeakerMode.Narration, PortraitFocus.None, seongsuHappy, jeonghoNeutral),
                        CreateLine("Seongsu", "Ahi tienes. Tu dosis de vida liquida.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, seongsuHappy, jeonghoNeutral),
                        CreateLine(string.Empty, "Seongsu, sin decir nada mas, partio su pastelito por la mitad y le ofrecio un pedazo a Jihuun. Como siempre, como si fuera algo que no necesitaba explicacion.", DialogueSpeakerMode.Narration, PortraitFocus.None, seongsuTenderness, jeonghoNeutral),
                        CreateLine(string.Empty, "El jugo de durazno estaba frio contra sus labios, un pequeno alivio bajo el sol que ya empezaba a picar en la piel. Jihuun bebia a pequenos sorbos mientras escuchaba a Jeongho hablar sobre una pelicula vieja que, segun el, era cine de culto solo porque casi nadie la conocia.", DialogueSpeakerMode.Narration, PortraitFocus.None, seongsuTenderness, jeonghoTalking),
                        CreateLine(string.Empty, "Seongsu, del otro lado, bufaba exageradamente y le decia que tenia gustos de senor de cincuenta anos.", DialogueSpeakerMode.Narration, PortraitFocus.None, seongsuHappy, jeonghoTalking),
                        CreateLine("Seongsu", "Apostaria a que ni siquiera tiene subtitulos.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, seongsuHappy, jeonghoTalking),
                        CreateLine("Seongsu", "Es mas, apuesto a que ni el director se acuerda que la hizo.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, seongsuHappy, jeonghoTalking),
                        CreateLine("Jihuun", "Ni yo la conozco", DialogueSpeakerMode.Signed, PortraitFocus.None, seongsuHappy, jeonghoHappy),
                        CreateLine("Seongsu", "Ya ves? Hasta Jihuun lo dice, y ella es la mas cool de nosotros.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, seongsuHappy, jeonghoHappy),
                        CreateLine("Jihuun", "Aqui... es facil. No necesito hablar.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                    };
                case Chapter01Beat.Ending:
                    return new[]
                    {
                        CreateLine(string.Empty, "Capitulo 1 terminado.", DialogueSpeakerMode.Narration),
                    };
                default:
                    return null;
            }
        }

        private ChapterChoiceBeat BuildFallbackChoice(Chapter01Beat beat)
        {
            switch (beat)
            {
                case Chapter01Beat.FirstChoice:
                    return new ChapterChoiceBeat
                    {
                        prompt = "Como reacciona Jihuun al ver a sus amigos?",
                        options = new[]
                        {
                            CreateChoice("smile_softly", "Sonrie ligeramente", 1, 1),
                            CreateChoice("just_watch", "Solo observa", 0, 0),
                            CreateChoice("sign_to_jeongho", "Hace una sena a Jeongho", 0, 1),
                        }
                    };
                case Chapter01Beat.SecondChoice:
                    return new ChapterChoiceBeat
                    {
                        prompt = "Como procesa Jihuun el ruido del pasillo?",
                        options = new[]
                        {
                            CreateChoice("look_around", "Mirar a la gente", 0, 0),
                            CreateChoice("look_down", "Bajar la mirada", 0, 0),
                            CreateChoice("ignore_everything", "Ignorar todo", 0, 0),
                        }
                    };
                case Chapter01Beat.ThirdChoice:
                    return new ChapterChoiceBeat
                    {
                        prompt = "Como participa Jihuun en la conversacion?",
                        options = new[]
                        {
                            CreateChoice("propose_weekend_plan", "Propone idea de salir el fin de semana", 1, 1),
                            CreateChoice("just_watch_again", "Solo observa", 0, 0),
                            CreateChoice("write_on_phone", "Escribe en celular", 1, 1),
                        }
                    };
                default:
                    return null;
            }
        }

        private DialogueLine[] BuildFallbackPostChoiceLines(Chapter01Beat beat, ChoiceOption selectedOption)
        {
            Sprite leftPortrait = dialogueController != null ? dialogueController.LeftPortraitSprite : null;
            Sprite rightPortrait = dialogueController != null ? dialogueController.RightPortraitSprite : null;

            Sprite seongsuHappy = GetSeongsuPortrait(CharacterExpression.Happy, leftPortrait);
            Sprite seongsuTenderness = GetSeongsuPortrait(CharacterExpression.Tenderness, leftPortrait);
            Sprite jeonghoTalking = GetJeonghoPortrait(CharacterExpression.Talking, rightPortrait);
            Sprite jeonghoHappy = GetJeonghoPortrait(CharacterExpression.Happy, rightPortrait);
            Sprite jeonghoTenderness = GetJeonghoPortrait(CharacterExpression.Tenderness, rightPortrait);

            switch (beat)
            {
                case Chapter01Beat.FirstChoice:
                    if (selectedOption.optionId == "sign_to_jeongho")
                    {
                        return new[]
                        {
                            CreateLine("Jihuun", "Ya lo tenias preparado?", DialogueSpeakerMode.Signed, PortraitFocus.None, seongsuTenderness, jeonghoTalking),
                            CreateLine("Jeongho", "Para que veas jajaja, era predecible.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, seongsuTenderness, jeonghoHappy),
                        };
                    }

                    return null;

                case Chapter01Beat.SecondChoice:
                    switch (selectedOption.optionId)
                    {
                        case "look_around":
                            return new[]
                            {
                                CreateLine("Jihuun", "Levanto la mirada.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                                CreateLine("Jihuun", "Por un segundo, todo se vuelve mas claro. Rostros. Movimiento. Ruido. Demasiado.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                                CreateLine("Jihuun", "Y entonces... alguien me esta mirando. No es como los demas. No se aparta de inmediato.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                            };
                        case "look_down":
                            return new[]
                            {
                                CreateLine("Jihuun", "Bajo la mirada.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                                CreateLine("Jihuun", "Es mas facil asi. Nadie se detiene. Nadie pregunta. Solo pasos y ruido.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                            };
                        case "ignore_everything":
                            return new[]
                            {
                                CreateLine("Jihuun", "...", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                            };
                    }

                    return null;

                case Chapter01Beat.ThirdChoice:
                    switch (selectedOption.optionId)
                    {
                        case "propose_weekend_plan":
                            return new[]
                            {
                                CreateLine("Jihuun", "Levanto las manos antes de pensarlo demasiado.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                                CreateLine("Jihuun", "Hago la sena torpemente... pero suficiente.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                                CreateLine("Jihuun", "No estoy segura de si lo entenderan.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                                CreateLine("Seongsu", "Burbujas?! Me encanta!", DialogueSpeakerMode.Spoken, PortraitFocus.Left, seongsuHappy, jeonghoHappy),
                                CreateLine("Jeongho", "Ok, eso si no me lo esperaba.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, seongsuHappy, jeonghoHappy),
                                CreateLine(string.Empty, "Jihuun se rio bajito.", DialogueSpeakerMode.Narration, PortraitFocus.None, seongsuHappy, jeonghoHappy),
                                CreateLine("Jihuun", "Alguien me estaba mirando otra vez.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuHappy, jeonghoHappy),
                                CreateLine("Jihuun", "Levante la vista, y ahi estaba el.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuHappy, jeonghoHappy),
                                CreateLine("Jihuun", "Ese chico que siempre parecia estar en el lugar correcto para hacerme sentir incomoda.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuHappy, jeonghoHappy),
                                CreateLine("Jihuun", "No era que el hiciera algo malo. No era como los otros que se reian o susurraban. Su mirada era distinta, como de curiosidad, pero igual de pesada. No me gustaba ser observada asi. No me gustaba sentirme un bicho raro en exhibicion.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuHappy, jeonghoHappy),
                                CreateLine("Jihuun", "Baje la cabeza rapidamente, reprimiendo el impulso de fruncir el ceno.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuHappy, jeonghoHappy),
                                CreateLine("Jihuun", "No era su culpa. Solo estaba... curioso. Quiza.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuHappy, jeonghoHappy),
                            };
                        case "just_watch_again":
                            return new[]
                            {
                                CreateLine("Jihuun", "Alguien me estaba mirando otra vez.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                                CreateLine("Jihuun", "Levante la vista, y ahi estaba el.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                                CreateLine("Jihuun", "Ese chico que siempre parecia estar en el lugar correcto para hacerme sentir incomoda.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                                CreateLine("Jihuun", "No era que el hiciera algo malo. No era como los otros que se reian o susurraban. Su mirada era distinta, como de curiosidad, pero igual de pesada. No me gustaba ser observada asi. No me gustaba sentirme un bicho raro en exhibicion.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                                CreateLine("Jihuun", "Baje la cabeza rapidamente, reprimiendo el impulso de fruncir el ceno.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                                CreateLine("Jihuun", "No era su culpa. Solo estaba... curioso. Quiza.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                            };
                        case "write_on_phone":
                            return new[]
                            {
                                CreateLine("Jihuun", "Escribo rapido en el celular y les enseno la pantalla.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                                CreateLine("Jihuun", "No estoy segura de si sonara ridiculo.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuTenderness, jeonghoTenderness),
                                CreateLine("Seongsu", "Burbujas?! Me encanta!", DialogueSpeakerMode.Spoken, PortraitFocus.Left, seongsuHappy, jeonghoHappy),
                                CreateLine("Jeongho", "Ok, eso si no me lo esperaba.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, seongsuHappy, jeonghoHappy),
                                CreateLine(string.Empty, "Jihuun sonrio sin querer.", DialogueSpeakerMode.Narration, PortraitFocus.None, seongsuHappy, jeonghoHappy),
                                CreateLine("Jihuun", "Alguien me estaba mirando otra vez.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuHappy, jeonghoHappy),
                                CreateLine("Jihuun", "Levante la vista, y ahi estaba el.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuHappy, jeonghoHappy),
                                CreateLine("Jihuun", "Ese chico que siempre parecia estar en el lugar correcto para hacerme sentir incomoda.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuHappy, jeonghoHappy),
                                CreateLine("Jihuun", "No era que el hiciera algo malo. No era como los otros que se reian o susurraban. Su mirada era distinta, como de curiosidad, pero igual de pesada. No me gustaba ser observada asi. No me gustaba sentirme un bicho raro en exhibicion.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuHappy, jeonghoHappy),
                                CreateLine("Jihuun", "Baje la cabeza rapidamente, reprimiendo el impulso de fruncir el ceno.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuHappy, jeonghoHappy),
                                CreateLine("Jihuun", "No era su culpa. Solo estaba... curioso. Quiza.", DialogueSpeakerMode.Thought, PortraitFocus.None, seongsuHappy, jeonghoHappy),
                            };
                    }

                    return null;
            }

            return null;
        }

        private DialogueLine CreateLine(
            string speakerName,
            string text,
            DialogueSpeakerMode speakerMode,
            PortraitFocus portraitFocus = PortraitFocus.None,
            Sprite leftPortrait = null,
            Sprite rightPortrait = null)
        {
            return new DialogueLine
            {
                speakerName = speakerName,
                speakerMode = speakerMode,
                portraitFocus = portraitFocus,
                leftPortrait = leftPortrait,
                rightPortrait = rightPortrait,
                text = text
            };
        }

        private Sprite GetSeongsuPortrait(CharacterExpression expression, Sprite fallback = null)
        {
            return ResolvePortrait(seongsuPortraits, expression, fallback);
        }

        private Sprite GetJeonghoPortrait(CharacterExpression expression, Sprite fallback = null)
        {
            return ResolvePortrait(jeonghoPortraits, expression, fallback);
        }

        private Sprite ResolvePortrait(CharacterPortraitLibrary library, CharacterExpression expression, Sprite fallback)
        {
            if (library == null)
            {
                return fallback;
            }

            Sprite portrait = expression switch
            {
                CharacterExpression.Neutral => library.neutral,
                CharacterExpression.Talking => library.talking,
                CharacterExpression.Confused => library.confused,
                CharacterExpression.Happy => library.happy,
                CharacterExpression.Tenderness => library.tenderness,
                CharacterExpression.Upset => library.upset,
                CharacterExpression.Sad => library.sad,
                CharacterExpression.Angry => library.angry,
                CharacterExpression.Shocked => library.shocked,
                CharacterExpression.Malicious => library.malicious,
                _ => null
            };

            return portrait != null ? portrait : fallback;
        }

        private ChoiceOption CreateChoice(string optionId, string label, int seongsuDelta, int jeonghoDelta)
        {
            return new ChoiceOption
            {
                optionId = optionId,
                label = label,
                seongsuTrustDelta = seongsuDelta,
                jeonghoTrustDelta = jeonghoDelta
            };
        }
    }
}
