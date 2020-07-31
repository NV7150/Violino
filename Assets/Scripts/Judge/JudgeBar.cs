using System.Collections.Generic;
using Parameters;
using ScoreControl;
using UnityEngine;

namespace Judge {
    public class JudgeBar : MonoBehaviour , ScoreUser {

        [SerializeField] private AudioSource source;
        [SerializeField] private PlayerInfo plInfo;
        [SerializeField] private List<GameObject> judgeLanes;

        private const float OFFSET_PER_SEC = 50000f;
        private const float SEC_PER_MIN = 60f;

        private float _speed = 1f;
        private ScoreInfo _info;

        private bool _isPlayStarted = false;

        public void scoreDecided(ScoreInfo info) {
            _info = info;
            
            _speed = _info.Bpm / SEC_PER_MIN * plInfo.Speed;
            
            var offsetHeight = _info.Offset / OFFSET_PER_SEC;
            Debug.Log(offsetHeight);
            transform.Translate(Vector3.down * offsetHeight * _speed);
            
            judgeLanes.ForEach(resizeJudgeLane);
        }

        private void resizeJudgeLane(GameObject judgeLane) {
            var originalScale = judgeLane.transform.localScale;
            var correctedScale = new Vector3(originalScale.x, originalScale.y * plInfo.Speed, originalScale.z);
            judgeLane.transform.localScale = correctedScale;
            
        }
        

        // Start is called before the first frame update
        void Start() {
        
        }

        // Update is called once per frame
        void Update() {
            if (_isPlayStarted) {
                translateBar();
            }
        }

        private void translateBar() {
            transform.Translate(Vector3.up * (_speed * Time.deltaTime));
        }

        public void startPlay() {
            if(!source.isPlaying)
                source.Play();
            _isPlayStarted = true;
        }
    }
}
