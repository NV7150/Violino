using Judge;
using UnityEngine;
using Visuals;

namespace ScoreControl {
    
    public class ShortNote : MonoBehaviour, Note {
        [SerializeField] private BanishEffect effect;
        
        private NoteLane _lane;
        private NoteDirection _direction;
        private NoteType _type = NoteType.SHORT;

        private MeshRenderer _renderer;

        private event NoteBanished onNoteBanished;

        public void initNote(NoteLane lane, NoteDirection dir, NoteType type, Material mat) {
            _lane = lane;
            _direction = dir;
            _renderer.material = mat;
        }
        
        // Start is called before the first frame update
        void Awake() {
            _renderer = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update() {
        
        }

        public void banish(JudgeCode banishCode) {
            _type = NoteType.BANISHED;
            onNoteBanished?.Invoke(this);
            effect.banishEffect(banishCode, completeBanish);
        }

        void completeBanish() {
            gameObject.SetActive(false);
        }

        public NoteType getNoteType() {
            return _type;
        }

        public NoteDirection getNoteDirection() {
            return _direction;
        }

        public NoteLane getNoteLane() {
            return _lane;
        }

        public void registerOnBanished(NoteBanished func) {
            onNoteBanished += func;
        }
    }
}
