using Parameters;
using UnityEngine;
using UnityEngine.UI;

namespace Menu {
    public class TrackNode : MonoBehaviour {
        [SerializeField] private Image image;
        
        private Track _track;

        public Track Track {
            get => _track;
            set {
                _track = value;
                setImage();
            }
        }

        private void setImage() {
            image.sprite = _track.Jacket;
        }

        // Start is called before the first frame update
        void Start() {
            
        }

        // Update is called once per frame
        void Update() {
        
        }
    }
}
