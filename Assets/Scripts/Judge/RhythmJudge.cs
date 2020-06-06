using System;
using System.Collections.Generic;
using ScoreControl;
using UnityEngine;

namespace Judge {
    
    public class RhythmJudge : MonoBehaviour {
        [SerializeField] private JudgeLane rightLane;
        [SerializeField] private JudgeLane centerLane;
        [SerializeField] private JudgeLane leftLane;
        
        [SerializeField] private PointManager pointManager;

        private readonly string RIGHT_BUTTON = "Right";
        private readonly string CENTER_BUTTON = "Center";
        private readonly string LEFT_BUTTON = "Left";

        // Start is called before the first frame update
        void Start() {
            rightLane.onNoteExit += onMiss;
            leftLane.onNoteExit += onMiss;
            centerLane.onNoteExit += onMiss;
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetButtonDown(LEFT_BUTTON)) {
                pushLane(leftLane);
            }

            if (Input.GetButtonDown(RIGHT_BUTTON)) {
                pushLane(rightLane);
            }

            if (Input.GetButtonDown(CENTER_BUTTON)) {
                pushLane(centerLane);
            }
        }

        private void onMiss(Note note) {
            if (note.Type == NoteType.SHORT) {
                shortNotePushed(note, JudgeCode.MISS);
            }
        }

        private void pushLane(JudgeLane lane) {
            if (!lane.hasNote())
                return;
            
            JudgeCode code = JudgeCode.MISS;
            Note note = lane.getLastNote(ref code);

            if (note.Type == NoteType.SHORT) {
                shortNotePushed(note, code);
            }
        }

        void shortNotePushed(Note note, JudgeCode code) {
            note.banish(code);
            pointManager.judge(code);
        }

        void longNotePushed() {
            
        }
    }
}
