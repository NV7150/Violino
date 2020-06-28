using System;
using UnityEngine;

namespace Visuals {
    public class ParticleCallBack : MonoBehaviour {
        [SerializeField] private BanishEffect rootEffect;
        
        // Start is called before the first frame update
        void Start() {
        
        }

        // Update is called once per frame
        void Update() {
        
        }

        private void OnParticleSystemStopped() {
            rootEffect.particleEnded();
        }
    }
}
