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

        [SerializeField] private GameObject rhythmInputObj;

        private RhythmInput _input;
        
        private readonly Tuple<bool, LongNote> _defaultTuple 
            = new Tuple<bool, LongNote>(false, null);
        
        private readonly Dictionary<NoteLane, Tuple<bool, LongNote>> _holdingNote 
            = new Dictionary<NoteLane, Tuple<bool, LongNote>>();

        
        // Start is called before the first frame update
        void Start() {
            _input = rhythmInputObj.GetComponent<RhythmInput>();
            if (_input == null) {
                throw new InvalidProgramException();
            }

            rightLane.onNoteExit += onNoteExit;
            rightLane.onNoteExitHold += onNoteExitLong;
            leftLane.onNoteExit += onNoteExit;
            leftLane.onNoteExitHold += onNoteExitLong;
            centerLane.onNoteExit += onNoteExit;
            centerLane.onNoteExitHold += onNoteExitLong;

            foreach (NoteLane lane in Enum.GetValues(typeof(NoteLane))) {
                _holdingNote.Add(lane, _defaultTuple);
            }
        }
        
        private void onNoteExit(Note note) {
            switch (note.getNoteType()) {
                case NoteType.SHORT:
                    judgeAndBanish(note, JudgeCode.MISS);
                    break;
                
                // case NoteType.LONG:
                //     judgeLongNote((LongNote)note, JudgeCode.PERFECT);
                //     break;
                
                case NoteType.LONG_SECTION:
                    var section = (LongNoteSection) note;
                    if(!section.LongNote.IsHolding)
                        judgeAndBanish(note, JudgeCode.MISS);
                    break;
            }
        }

        private void onNoteExitLong(Note note) {
            if (note.getNoteType() == NoteType.LONG) {
                judgeLongNote((LongNote)note, JudgeCode.PERFECT);
            }
        }
        
        

        // Update is called once per frame
        void Update() {
            processLaneButton(leftLane);

            processLaneButton(rightLane);

            processLaneButton(centerLane);
        }
        
        void processLaneButton(JudgeLane lane) {
            if (_holdingNote[lane.Lane].Item1 && !_input.getButton(lane.Lane)) {
                judgeLongNote(_holdingNote[lane.Lane].Item2, JudgeCode.MISS);
            }
            
            if (_input.isJudgeTiming(lane.Lane)) {
                pushLane(lane);
            }
        }
        
        private void pushLane(JudgeLane lane) {
            if (!lane.hasNote())
                return;
            
            var code = JudgeCode.MISS;
            Note note = lane.getLastNote(ref code);

            if (_input.getDirection() != note.getNoteDirection()) {
                return;
            }

            if (note.getNoteType() == NoteType.SHORT) {
                judgeAndBanish(note, code);
            } else if (note.getNoteType() == NoteType.LONG){
                longNotePushed((LongNote)note , code);
            }
        }
        
        
        void longNotePushed(LongNote longNote, JudgeCode code) {
            if (code != JudgeCode.MISS) {
                longNote.IsHolding = true;
                _holdingNote[longNote.getNoteLane()] = new Tuple<bool, LongNote>(true, longNote);
                pointManager.judge(code);
            } else {
                judgeAndBanish(longNote, code);
            }
        }
        
        void judgeLongNote(LongNote note, JudgeCode code) {
            _holdingNote[note.getNoteLane()] = _defaultTuple;

            if (!note.IsHolding) {
                judgeAndBanish(note, JudgeCode.MISS);
                return;
            }
            
            judgeAndBanish(note, code);
        }


        void judgeAndBanish(Note note, JudgeCode code) {
            note.banish(code);
            
            pointManager.judge(code);
        }
        
        public bool getLaneHolding(NoteLane lane) {
            return _holdingNote[lane].Item1;
        }
    }
}
