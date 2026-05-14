using System;
using UnityEngine;

namespace EntreTuSilencio.Dialogue
{
    public enum DialogueSpeakerMode
    {
        Spoken,
        Thought,
        Narration,
        Signed
    }

    public enum PortraitFocus
    {
        None,
        Left,
        Right
    }

    [Serializable]
    public class DialogueLine
    {
        public string speakerName;
        public DialogueSpeakerMode speakerMode = DialogueSpeakerMode.Spoken;
        public bool useSpeakerColor;
        public Color speakerColor = Color.white;
        public PortraitFocus portraitFocus = PortraitFocus.None;
        public Sprite leftPortrait;
        public Sprite rightPortrait;
        public Sprite[] leftPortraitSequence;
        public Sprite[] rightPortraitSequence;
        public float portraitSequenceFrameDuration = 0.12f;

        [TextArea(2, 5)]
        public string text;
    }
}
