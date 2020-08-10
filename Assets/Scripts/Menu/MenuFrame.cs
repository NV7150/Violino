﻿using System;
using System.Collections;
using UnityEngine;

namespace Menu {
    public class MenuFrame : MonoBehaviour {

        [SerializeField] private float nodePadding;
        [SerializeField] private float nodeSize;
        [SerializeField] private float moveSpeed;

        private static readonly float DELTA_TIME = 0.025f;

        private int _trackNum = 0;
        private int _currentTrack = 0;
        private bool _isMoving = false;
        private float _frameSize = 0;

        private RectTransform _rectTransform;
        
        public int TrackNum {
            get => _trackNum;
            set {
                if (value <= 0) 
                    throw new ArgumentException();
                
                _trackNum = value;
                setFrameSize();
            }
        }

        public int CurrentTrack {
            get => _currentTrack;
            set {
                if (_isMoving)
                    return;
                
                if (value <= 0) {
                    value = TrackNum;
                }else if (TrackNum < value) {
                    value = 1;
                }

                _currentTrack = value;
                setTrackPos();
            }
        }

        private void Awake() {
            _rectTransform = GetComponent<RectTransform>();
        }

        // Start is called before the first frame update
        void Start() {
            
        }

        // Update is called once per frame
        void Update() {
        
        }

        private void setFrameSize() {
            _frameSize = _trackNum * (nodePadding + nodeSize) - nodePadding;
            _rectTransform.sizeDelta = new Vector2(_frameSize, 0);
            CurrentTrack = 1;
        }

        private IEnumerator moveRoutine() {
            if(_isMoving)
                yield break;
            
            _isMoving = true;
            
            float currPos = moveSpeed;
            var startPos = _rectTransform.anchoredPosition;
            var endPosX = (_currentTrack - 1) * (nodePadding + nodeSize) + (nodeSize / 2f) - (_frameSize / 2f);
            var endPos = Vector2.right * endPosX;
            
            while (currPos < 1) {
                _rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, currPos);
                currPos += moveSpeed;
                yield return new WaitForSeconds(DELTA_TIME);
            }
            _rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, 1f);
            
            _isMoving = false;
        }
        
        private void setTrackPos() {
            StartCoroutine(moveRoutine());
        }
        
    }
}