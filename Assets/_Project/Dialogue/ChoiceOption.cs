using System;
using UnityEngine;

namespace EntreTuSilencio.Dialogue
{
    [Serializable]
    public class ChoiceOption
    {
        public string optionId;
        public int seongsuTrustDelta;
        public int jeonghoTrustDelta;

        [TextArea(2, 4)]
        public string label;
    }
}
