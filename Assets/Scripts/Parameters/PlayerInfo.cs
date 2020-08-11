using ScoreControl;
using UnityEngine;

namespace Parameters {
    [CreateAssetMenu]
    public class PlayerInfo : ScriptableObject {
        public static readonly float MAX_PLAY_SPEED = 2.0f;
        
        [SerializeField] private float speed = 1.0f;

        [SerializeField] private AudioClip selectedAudio;
        [SerializeField] private TextAsset scoreText;
        
        public float Speed {
            get => speed;
            set {
                if(MAX_PLAY_SPEED >= value && 0 < value ) 
                    speed = value;
            }
        }

        public AudioClip SelectedAudio {
            get => selectedAudio;
            set => selectedAudio = value;
        }

        public TextAsset ScoreText {
            get => scoreText;
            set => scoreText = value;
        }
    }
}
