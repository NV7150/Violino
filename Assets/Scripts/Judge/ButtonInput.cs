using System;
using System.Collections.Generic;
using System.Linq;
using ScoreControl;
using UnityEngine;

namespace Judge {
    public class ButtonInput : MonoBehaviour, RhythmInput {
        [SerializeField] private string rightButtonName = "Right";
        [SerializeField] private string centerButtonName = "Center";
        [SerializeField] private string leftButtonName = "Left";

        [SerializeField] private List<string> rightDirButtonNames;
        [SerializeField] private List<string> leftDirButtonNames;

        private readonly Dictionary<NoteLane, string> _laneButtons = new Dictionary<NoteLane, string>();

        void Awake() {
            _laneButtons.Add(NoteLane.RIGHT, rightButtonName);
            _laneButtons.Add(NoteLane.LEFT, leftButtonName);
            _laneButtons.Add(NoteLane.CENTER, centerButtonName);
        }

        public bool isJudgeTiming() {
            return _laneButtons.Values.Any(Input.GetButtonDown);
        }

        public bool isJudgeContinue() {
            return _laneButtons.Values.Any(Input.GetButton);
        }

        public bool getButton(NoteLane lane) {
            return Input.GetButton(_laneButtons[lane]);
        }

        public NoteDirection getDirection() {
            //とりあえず現状、同時に押された場合は考慮しない
            if (rightDirButtonNames.Any(Input.GetButton)) {
                return NoteDirection.RIGHT;
            } else if(leftDirButtonNames.Any(Input.GetButton)){
                return NoteDirection.LEFT;
            }

            return NoteDirection.NONE;
        }
    }
}
