using UnityEngine;

namespace Parameters {
    [CreateAssetMenu]
    public class PlayerInfo : ScriptableObject {
        public static readonly float MAX_PLAY_SPEED = 2.0f;
        
        [SerializeField]
        private float speed = 1.0f;

        public float Speed {
            get => speed;
            set {
                if(MAX_PLAY_SPEED >= value && 0 < value ) 
                    speed = value;
            }
        }
    }
}
