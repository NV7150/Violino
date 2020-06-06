using System;
using ScoreControl;
using UnityEngine;

namespace Judge {
    public class JudgeLane : MonoBehaviour {
        [SerializeField] private JudgeFrame perfectFrame;
        [SerializeField] private JudgeFrame goodFrame;
        
        public event JudgeFrame.NoteExit onNoteExit;

        public event JudgeFrame.LongExit onLongExit;

        // Start is called before the first frame update
        void Start() {
            perfectFrame.onNoteExit += note => {onNoteExit?.Invoke(note);};
            perfectFrame.onLongExit += () => {onLongExit?.Invoke();};
        }


        // Update is called once per frame
        void Update() {
        
        }

        public bool hasNote() {
            return perfectFrame.hasNote() || goodFrame.hasNote();
        }

        public Note getLastNote(ref JudgeCode code) {
            Note returnNote = null;
            if (perfectFrame.hasNote()) {
                returnNote = perfectFrame.getLastNote();
                code = JudgeCode.PERFECT;
            }else if (goodFrame.hasNote()) {
                returnNote = goodFrame.getLastNote();
                code = JudgeCode.GOOD;
            }

            return returnNote;
        }
    }
}
