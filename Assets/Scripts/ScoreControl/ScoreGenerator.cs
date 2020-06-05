using System;
using UnityEngine;
using static ScoreControl.NoteDirection;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace ScoreControl {
    public class ScoreGenerator : MonoBehaviour {
        [SerializeField] private GameObject wallPrefab;
        [SerializeField] private GameObject notePrefab;

        [SerializeField] private Material rightNoteMat;
        [SerializeField] private Material centerNoteMat;
        [SerializeField] private Material leftNoteMat;

        [SerializeField] private Material rightWallMat;
        [SerializeField] private Material leftWallMat;

        [SerializeField] private float laneWidth = 1f;
        [SerializeField] private float noteHeight = 0.25f;
        [SerializeField] private int centerLaneIndex = 1;
        [SerializeField] private Vector3 noteOffset = Vector3.zero;

        //数え上げの単位
        //16分・3連符同時対応のため、4と3の公倍数を推奨
        private readonly float POS_UNIT = 4 * 3;

        private readonly int BLOCK_CHANGE = 3;
        
        private ScoreInfo _info;

        public void generateScoreObj(ScoreInfo info) {
            _info = info;
            
            float pos = 0;
            NoteDirection currDir = LEFT;
            
            var notes = info.Notes;
            foreach (var note in notes) {
                float currPos = note.Num * (POS_UNIT / note.Lpb);
                generateWall(currPos, pos, currDir);
                if (note.Block == BLOCK_CHANGE) {
                    currDir = (currDir == LEFT) ? RIGHT : LEFT;
                } else {
                    if (note.Type == (int) NoteType.SHORT) {
                        generateShortNote(currPos, note, currDir);
                    }
                }
                pos = currPos;
            }
        }

        private void generateWall(float currPos, float prevPos, NoteDirection currDir) {
            var deltaPos = currPos - prevPos;
            
            var wallMaterial = (currDir == LEFT) ? leftWallMat : rightWallMat;

            var wallTall = 1f * (deltaPos / POS_UNIT);
            var wallPosY = currPos / POS_UNIT - wallTall / 2f + noteHeight / 2;
            var wallPos = new Vector3(0, wallPosY, 0);
            
            var wallObj = Instantiate(wallPrefab, wallPos, Quaternion.identity).GetComponent<Wall>();
            
            wallObj.initWall(wallMaterial);
            wallObj.transform.localScale = new Vector3(1, wallTall , 1);
        }

        private void generateShortNote(float currPos, NoteInfo noteInfo, NoteDirection dir) {
            var lanePos = (noteInfo.Block - centerLaneIndex) * laneWidth;
            var notePos = new Vector3(lanePos, currPos / POS_UNIT, 0) + noteOffset;

            var noteLane = (NoteLane) noteInfo.Block;
            Material noteMat;
            switch (noteLane) {
                case NoteLane.LEFT :
                    noteMat = leftNoteMat;
                    break;
                
                case NoteLane.CENTER:
                    noteMat = centerNoteMat;
                    break;
                
                case NoteLane.RIGHT:
                    noteMat = rightNoteMat;
                    break;
                
                default:
                    throw new InvalidProgramException();
            }

            var note = Instantiate(notePrefab, notePos, Quaternion.identity).GetComponent<Note>();
            note.initNote(noteLane, dir, NoteType.SHORT, noteMat);
        }

    }
}