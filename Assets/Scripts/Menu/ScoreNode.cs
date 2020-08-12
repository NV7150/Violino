using Parameters;
using UnityEngine;
using UnityEngine.UI;

namespace Menu {
    public class ScoreNode : MonoBehaviour {
        [SerializeField] private Text text;
        [SerializeField] private Image image;

        private Score _score;

        public Score Score => _score;

        public void setNode(Score score) {
            text.text = score.Difficulty;
            image.color = score.ImageColor;
            _score = score;
        }

        // Start is called before the first frame update
        void Start() {
        
        }

        // Update is called once per frame
        void Update() {
        
        }
    }
}
