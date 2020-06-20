using Judge;
using UnityEngine;

namespace ScoreControl {
    public class LongNoteSection : MonoBehaviour, Note {
        [SerializeField] private LongNote longNote;

        public LongNote LongNote => longNote;

        // Start is called before the first frame update
        void Start() {
        
        }

        // Update is called once per frame
        void Update() {
        
        }

        public NoteType getNoteType() {
            return NoteType.LONG_SECTION;
        }

        public NoteDirection getNoteDirection() {
            return longNote.getNoteDirection();
        }

        public NoteLane getNoteLane() {
            return longNote.getNoteLane();
        }

        public void banish(JudgeCode code) {
            longNote.banish(code);
        }

        public void registerOnBanished(NoteBanished func) {
            longNote.registerOnBanished(func);
        }
    }
}
