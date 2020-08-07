using UnityEngine;

namespace Menu {
    public enum TrackCommand {
        //右から中央へ
        GO_CENTER_R,
        //左から中央へ
        GO_CENTER_L,
        //中央から右へ
        LEFT_CENTER_R,
        //中央から左へ
        LEFT_CENTER_L
    }
    
    public class Track : MonoBehaviour {
        // [SerializeField]private 

        private int _id;
        private string _name;
        private string _trackPath;

        public int Id => _id;

        public string Name => _name;

        public string TrackPath => _trackPath;

        public void initTrack(int id, string trackName, string trackPath) {
            _id = id;
            _name = trackName;
            _trackPath = trackPath;
        }
        

        // Start is called before the first frame update
        void Start() {
            
        }

        // Update is called once per frame
        void Update() {
        
        }

        public void enVisible() {
            
        }

        public void moveTo(TrackCommand command) {
            
        }

        public void enInvisible() {
            
        }
    }
}
