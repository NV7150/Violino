using UnityEngine;

namespace Visuals {
    public class HoldEffectSimple : HoldEffectBase {
        [SerializeField] private ParticleSystem particleSystem;
        
        // Start is called before the first frame update
        void Start() {
        
        }

        // Update is called once per frame
        void Update() {
        
        }

        public override void startEffect() {
            particleSystem.Play();
        }

        public override void endEffect() {
            particleSystem.Stop();
        }

        public override bool getEffectStatus() {
            return particleSystem.isPlaying;
        }
    }
}
