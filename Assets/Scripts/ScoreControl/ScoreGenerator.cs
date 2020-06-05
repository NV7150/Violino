using System;
using UnityEngine;
using static ScoreControl.NoteDirection;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace ScoreControl {
    public class ScoreGenerator : MonoBehaviour {
        [SerializeField] private Transform wallParent;
        
        [SerializeField] private GameObject wallPrefab;
        [SerializeField] private GameObject notePrefab;
        [SerializeField] private GameObject longNotePrefab;

        [SerializeField] private GameObject leftArrowPrefab;
        [SerializeField] private GameObject rightArrowPrefab;

        [SerializeField] private Material rightNoteMat;
        [SerializeField] private Material centerNoteMat;
        [SerializeField] private Material leftNoteMat;

        [SerializeField] private Material rightLongMat;
        [SerializeField] private Material centerLongMat;
        [SerializeField] private Material leftLongMat;

        [SerializeField] private Material rightWallMat;
        [SerializeField] private Material leftWallMat;

        [SerializeField] private float laneWidth = 1f;
        [SerializeField] private float noteHeight = 0.25f;
        [SerializeField] private int centerLaneIndex = 1;
        [SerializeField] private Vector3 noteOffset = Vector3.zero;
        [SerializeField]private Vector3 arrowOffset = Vector3.zero;

        //数え上げの単位
        //16分・3連符同時対応のため、4と3の公倍数を推奨
        private readonly float POS_UNIT = 4 * 3;

        private readonly int BLOCK_CHANGE = 3;

        public void generateScoreObj(ScoreInfo info) {
            float pos = 0;
            NoteDirection currDir = LEFT;
            
            var notes = info.Notes;
            NoteInfo prevNote = null;
            foreach (var note in notes) {

                float currPos = getNotePos(note);
                
                generateWall(currPos, pos, currDir);
                
                if (note.Block == BLOCK_CHANGE) {
                    currDir = (currDir == LEFT) ? RIGHT : LEFT;
                    
                    generateArrow(currPos,currDir);
                } else {
                    if (note.Type == (int) NoteType.SHORT) {
                        generateShortNote(currPos, note, currDir);
                    } else {
                        generateLongNote(currPos, note, currDir);
                    }
                }
                
                pos = currPos;
                prevNote = note;
            }

            if (prevNote?.Notes.Count > 0) {
                generateWall(getNotePos(prevNote.Notes[0]), pos, currDir);
            }
        }

        private float getNotePos(NoteInfo noteInfo) {
            return noteInfo.Num * (POS_UNIT / noteInfo.Lpb);
        }

        private void generateArrow(float currPos, NoteDirection dir) {
            var arrowPos = new Vector3(0, currPos / POS_UNIT, 0) + arrowOffset;
            
            var prefab = (dir == LEFT) ? leftArrowPrefab : rightArrowPrefab;
            Instantiate(prefab, arrowPos, prefab.transform.rotation);
        }

        private void generateWall(float currPos, float prevPos, NoteDirection currDir) {
            var deltaPos = currPos - prevPos;
            
            var wallMaterial = (currDir == LEFT) ? leftWallMat : rightWallMat;

            var wallTall = 1f * (deltaPos / POS_UNIT) * scaleCorrection();
            var wallPosY = currPos / POS_UNIT - wallTall / 2f + noteHeight / 2;
            var wallPos = new Vector3(0, wallPosY, 0);
            
            var wallObj = Instantiate(wallPrefab, wallPos, Quaternion.identity, wallParent).GetComponent<Wall>();
            
            wallObj.initWall(wallMaterial);
            wallObj.transform.localScale = new Vector3(1, wallTall , 1);
        }

        private void generateShortNote(float currPos, NoteInfo noteInfo, NoteDirection dir) {
            var notePos = getGeneratePos(currPos, noteInfo);

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
        
        private Vector3 getGeneratePos(float currPos, NoteInfo noteInfo) {
            var lanePos = (noteInfo.Block - centerLaneIndex) * laneWidth;
            var notePos = new Vector3(lanePos, currPos / POS_UNIT, 0) + noteOffset;
            return notePos;
        }

        private void generateLongNote(float currPos, NoteInfo noteInfo, NoteDirection dir) {
            generateShortNote(currPos, noteInfo, dir);
            
            var noteLength = (getNotePos(noteInfo.Notes[0]) - currPos) / POS_UNIT * scaleCorrection();
            var genPos = getGeneratePos(currPos, noteInfo) + Vector3.up * (noteLength / 2f);

            var longNote = Instantiate(longNotePrefab, genPos, Quaternion.identity);

            Material mat = null;
            var lane = (NoteLane) noteInfo.Block;
            switch (lane) {
                case NoteLane.LEFT:
                    mat = leftLongMat;
                    break;
                
                case NoteLane.RIGHT:
                    mat = rightLongMat;
                    break;
                
                case NoteLane.CENTER:
                    mat = centerLongMat;
                    break;
                
                default:
                    throw new InvalidProgramException();
            }
            longNote.GetComponent<MeshRenderer>().material = mat;

            var prevScale = longNote.transform.localScale;
            longNote.transform.localScale = new Vector3(prevScale.x, noteLength, prevScale.z);
        }

        private float scaleCorrection() {
            return 1f;
        }

    }
}