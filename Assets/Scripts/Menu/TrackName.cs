using Parameters;
using UnityEngine;
using UnityEngine.UI;

namespace Menu {
    public class TrackName : MonoBehaviour {
        [SerializeField] private TrackChooseManager trackChooseMan;
        [SerializeField] private TracksInfo tracks;
        private Text _text;

        void Awake() {
            _text = GetComponent<Text>();
        }
        
        // Start is called before the first frame update
        void Start() {
            changeText(tracks.getTrack(0));
            trackChooseMan.onTrackChanged += changeText;
        }

        private void changeText(Track track) {
            _text.text = track.Name;
        }

        // Update is called once per frame
        void Update() {
        
        }
    }
}
