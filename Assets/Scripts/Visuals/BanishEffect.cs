using System;
using System.Collections.Generic;
using System.Linq;
using Judge;
using UnityEngine;

namespace Visuals {
    public abstract class BanishEffect : MonoBehaviour {
        public delegate void EffectFinished();
        public abstract void banishEffect(JudgeCode code, EffectFinished finCallback);
        public abstract void particleEnded();

        protected static Dictionary<JudgeCode, Color> getColorDict(List<EffectColor> colors) {
            return colors.ToDictionary(efColor => efColor.Code, efColor => efColor.Color);
        }
    }
    
    [Serializable]
    public class EffectColor {
        [SerializeField] private JudgeCode code;
        [SerializeField] private Color color;

        public JudgeCode Code => code;

        public Color Color => color;
    }
}
