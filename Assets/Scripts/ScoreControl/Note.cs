using UnityEngine;

namespace ScoreControl {
    public class Note : MonoBehaviour {
        private NoteLane _lane;
        private NoteDirection _direction;
        private NoteType _type;

        private MeshRenderer _renderer;

        public NoteLane Lane => _lane;

        public NoteDirection Direction => _direction;

        public NoteType Type => _type;

        public void initNote(NoteLane lane, NoteDirection dir, NoteType type, Material mat) {
            _lane = lane;
            _direction = dir;
            _type = type;
            _renderer.material = mat;
        }
        
        // Start is called before the first frame update
        void Awake() {
            _renderer = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update() {
        
        }

        public void banish() {
            
        }
    }
}
