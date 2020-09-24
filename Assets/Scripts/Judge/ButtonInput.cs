using System;
using System.Collections.Generic;
using System.Linq;
using ScoreControl;
using UnityEngine;

namespace Judge {
    public class ButtonInput : MonoBehaviour, RhythmInput {
        [SerializeField] private int affordanceFrames = 5;
        
        [SerializeField] private string rightButtonName = "Right";
        [SerializeField] private string centerButtonName = "Center";
        [SerializeField] private string leftButtonName = "Left";

        [SerializeField] private List<string> rightDirButtonNames;
        [SerializeField] private List<string> leftDirButtonNames;

        private readonly Dictionary<NoteLane, string> _laneButtons = new Dictionary<NoteLane, string>();

        private NoteDirection _currDirection = NoteDirection.NONE;

        private int _noneCount = 0;

        void Awake() {
            _laneButtons.Add(NoteLane.RIGHT, rightButtonName);
            _laneButtons.Add(NoteLane.LEFT, leftButtonName);
            _laneButtons.Add(NoteLane.CENTER, centerButtonName);
        }

        private void Update() {
            updateDir();
        }

        void updateDir() {
            var dir = getCurrDir();
            if (dir != NoteDirection.NONE) {
                _currDirection = dir;
                _noneCount = 0;
                return;
            }

            if (_noneCount >= affordanceFrames) {
                _currDirection = NoteDirection.NONE;
            } else {
                _noneCount++;
            }
        }

        NoteDirection getCurrDir() {
            //とりあえず現状、同時に押された場合は考慮しない
            if (rightDirButtonNames.Any(Input.GetButton)) {
                return NoteDirection.RIGHT;
            } else if(leftDirButtonNames.Any(Input.GetButton)){
                return NoteDirection.LEFT;
            }

            return NoteDirection.NONE;
        }

        public bool isJudgeTiming(NoteLane lane) {
            return Input.GetButtonDown(_laneButtons[lane]);
        }

        public bool getButton(NoteLane lane) {
            return Input.GetButton(_laneButtons[lane]);
        }

        public NoteDirection getDirection() {
            return _currDirection;
        }
    }
}
