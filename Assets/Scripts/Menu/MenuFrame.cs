using System;
using System.Collections;
using UnityEngine;

namespace Menu {
    public class MenuFrame : MonoBehaviour {

        [SerializeField] private float nodePadding;
        [SerializeField] private float nodeSize;
        [SerializeField] private float moveSpeed;

        private static readonly float DELTA_TIME = 0.025f;

        private int _nodeNum = 0;
        private int _currentNode = 0;
        private bool _isMoving = false;
        private float _frameSize = 0;

        private RectTransform _rectTransform;
        
        public int NodeNum {
            get => _nodeNum;
            set {
                if (value <= 0) 
                    throw new ArgumentException();
                
                _nodeNum = value;
                setFrameSize();
            }
        }

        public int CurrentNode {
            get => _currentNode;
            set {
                if (value < 0) {
                    value = NodeNum - 1;
                }else if (NodeNum <= value) {
                    value = 0;
                }

                setNodePos(value);
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
            _frameSize = _nodeNum * (nodePadding + nodeSize) - nodePadding;
            _rectTransform.sizeDelta = new Vector2(_frameSize, 0);
            CurrentNode = 0;
        }

        private IEnumerator moveRoutine(int moveTo) {
            if(_isMoving)
                yield break;
            
            _isMoving = true;
            
            float currPos = moveSpeed;
            var extraNum = NodeNum - (moveTo + 1);
            
            var startPos = _rectTransform.anchoredPosition;
            var endPosX = extraNum * (nodePadding + nodeSize) + (nodeSize / 2f) - (_frameSize / 2f);
            var endPos = Vector2.right * endPosX;
            
            while (currPos < 1) {
                _rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, currPos);
                currPos += moveSpeed;
                yield return new WaitForSeconds(DELTA_TIME);
            }
            _rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, 1f);

            _currentNode = moveTo;
            _isMoving = false;
        }
        
        private void setNodePos(int trackNum) {
            StartCoroutine(moveRoutine(trackNum));
        }
        
    }
}
