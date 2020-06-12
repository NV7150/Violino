using System;
using System.Collections.Generic;
using ScoreControl;
using UnityEngine;
using UnityEngine.Playables;

namespace Judge {
    
    public class RhythmJudge : MonoBehaviour {
        [SerializeField] private JudgeLane rightLane;
        [SerializeField] private JudgeLane centerLane;
        [SerializeField] private JudgeLane leftLane;
        
        [SerializeField] private PointManager pointManager;

        private readonly string RIGHT_BUTTON = "Right";
        private readonly string CENTER_BUTTON = "Center";
        private readonly string LEFT_BUTTON = "Left";
        
        private readonly Tuple<bool, LongNote> _defaultTuple 
            = new Tuple<bool, LongNote>(false, null);
        
        private readonly Dictionary<NoteLane, Tuple<bool, LongNote>> _holdingNote 
            = new Dictionary<NoteLane, Tuple<bool, LongNote>>();

        // Start is called before the first frame update
        void Start() {
            rightLane.onNoteExit += onNoteExit;
            leftLane.onNoteExit += onNoteExit;
            centerLane.onNoteExit += onNoteExit;

            for (int i = 0; i < 3; i++) {
                _holdingNote.Add((NoteLane)i, _defaultTuple);
            }
        }
        
        private void onNoteExit(Note note) {
            if (note.getNoteType() == NoteType.SHORT) {
                shortNotePushed((ShortNote)note, JudgeCode.MISS);
                
            } else if (note.getNoteType() == NoteType.LONG) {
                onLongNoteExit((LongNote)note);
            }
        }
        
        private void onLongNoteExit(LongNote note) {
            judgeLongNote(note, JudgeCode.PERFECT);
        }
        

        // Update is called once per frame
        void Update() {
            processLaneButton(LEFT_BUTTON, leftLane);

            processLaneButton(RIGHT_BUTTON, rightLane);

            processLaneButton(CENTER_BUTTON, centerLane);
        }
        
        void processLaneButton(string buttonName, JudgeLane lane) {
            if (Input.GetButtonUp(buttonName) && _holdingNote[lane.Lane].Item1) {
                judgeLongNote(_holdingNote[lane.Lane].Item2, JudgeCode.MISS);
            }
            
            if (Input.GetButtonDown(buttonName)) {
                pushLane(lane);
            }
        }

        private void pushLane(JudgeLane lane) {
            if (!lane.hasNote())
                return;
            
            JudgeCode code = JudgeCode.MISS;
            Note note = lane.getLastNote(ref code);

            if (note.getNoteType() == NoteType.SHORT) {
                shortNotePushed((ShortNote) note, code);
            } else {
                longNotePushed((LongNote)note , code);
            }
        }
        

        void shortNotePushed(ShortNote shortNote, JudgeCode code) {
            judgeAndBanish(shortNote,code);
        }

        void longNotePushed(LongNote longNote, JudgeCode code) {

            if (code != JudgeCode.MISS) {
                longNote.IsHolding = true;
                _holdingNote[longNote.getNoteLane()] = new Tuple<bool, LongNote>(true, longNote);
            }
            pointManager.judge(code);
        }


        void judgeAndBanish(Note note, JudgeCode code) {
            note.banish(code);
            pointManager.judge(code);
        }
        
        
        void judgeLongNote(LongNote note, JudgeCode code) {
            _holdingNote[note.getNoteLane()] = _defaultTuple;

            if (!note.IsHolding) {
                judgeAndBanish(note, JudgeCode.MISS);
                return;
            }
            
            judgeAndBanish(note, code);
        }
    }
}
