using UnityEngine;

namespace Visuals {
    public abstract class HoldEffectBase : MonoBehaviour {
        public abstract void startEffect();
        public abstract void endEffect();

        public abstract bool getEffectStatus();
    }
}
