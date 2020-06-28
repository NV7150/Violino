using System;
using System.Collections.Generic;
using Judge;
using UnityEngine;

namespace Visuals {
    public class RingEffect : BanishEffect {
        [SerializeField] private List<ParticleSystem> particleSystems;
        [SerializeField] private List<EffectColor> colors;

        private Dictionary<JudgeCode, Color> _colors;
        private int _finishedParticle = 0;
        private EffectFinished _effectFinished;

        private void Awake() {
            _colors = getColorDict(colors);
        }

        // Start is called before the first frame update
        void Start() {
        }

        // Update is called once per frame
        void Update() {
        
        }

        public override void banishEffect(JudgeCode code, EffectFinished finCallback) {
            foreach (var ps in particleSystems) {
                var particleSystemMain = ps.main;
                particleSystemMain.startColor = _colors[code];
            }


            foreach (var ps in particleSystems) {
                ps.Play();
            }

            _effectFinished = finCallback;
            _finishedParticle = 0;
        }

        public override void particleEnded() {
            _finishedParticle++;
            if (_finishedParticle == particleSystems.Count) {
                _effectFinished?.Invoke();
            }
        }
    }
}
