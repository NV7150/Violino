using ScoreControl;
using UnityEngine;

namespace Parameters {
    [CreateAssetMenu]
    public class PlayerInfo : ScriptableObject {
        public static readonly float MAX_PLAY_SPEED = 2.0f;
        
        [SerializeField] private float speed = 1.0f;

        [SerializeField] private Track track;
        [SerializeField] private Score score;
        
        public float Speed {
            get => speed;
            set {
                //微小な数を足して誤差修正
                if(MAX_PLAY_SPEED + 1.0e-6f > value && 0 < value ) 
                    speed = value;
            }
        }

        public Track Track {
            get => track;
            set => track = value;
        }

        public Score Score {
            get => score;
            set => score = value;
        }
    }
}
