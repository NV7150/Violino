using System;
using ScoreControl;
using UnityEngine;

namespace Judge {
    public class JudgeLane : MonoBehaviour {
        [SerializeField] private JudgeFrame perfectFrame;
        [SerializeField] private JudgeFrame goodFrame;
        [SerializeField] private JudgeFrame holdFrame;

        [SerializeField]private NoteLane lane;
        
        public event JudgeFrame.NoteExit onNoteExit;
        public event JudgeFrame.NoteExit onNoteExitHold;

        public NoteLane Lane => lane;

        // Start is called before the first frame update
        void Start() {
            perfectFrame.onNoteExit += note => {onNoteExit?.Invoke(note);};
            holdFrame.onNoteExit += note => { onNoteExitHold?.Invoke(note); };
        }


        // Update is called once per frame
        void Update() {
        
        }

        public bool hasNote() {
            return perfectFrame.hasNote() || goodFrame.hasNote();
        }

        public Note getLastNote(ref JudgeCode code) {
            Note returnShortNote = null;
            if (perfectFrame.hasNote()) {
                returnShortNote = perfectFrame.getLastNote();
                code = JudgeCode.PERFECT;
            }else if (goodFrame.hasNote()) {
                returnShortNote = goodFrame.getLastNote();
                code = JudgeCode.GOOD;
            }

            return returnShortNote;
        }
    }
}
