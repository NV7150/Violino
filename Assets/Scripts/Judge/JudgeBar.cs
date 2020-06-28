using ScoreControl;
using UnityEngine;

namespace Judge {
    public class JudgeBar : MonoBehaviour , ScoreUser {

        [SerializeField] private AudioSource source;
        
        private float _speed = 1f;
        private ScoreInfo _info;

        public void scoreDecided(ScoreInfo info) {
            _info = info;
            
            _speed = _info.Bpm / 60f;
            
            var offsetHeight = _info.Offset / 500000f;
            transform.Translate(Vector3.down * offsetHeight);
        }
        

        // Start is called before the first frame update
        void Start() {
        
        }

        // Update is called once per frame
        void Update() {
            translateBar();
        }

        private void translateBar() {
            if(!source.isPlaying)
                source.Play();
            transform.Translate(Vector3.up * (_speed * Time.deltaTime));
        }
    }
}
