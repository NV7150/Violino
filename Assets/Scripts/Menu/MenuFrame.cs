using System;
using System.Collections;
using UnityEngine;

namespace Menu {
    public enum MenuDirection {
        UP,
        DOWN,
        RIGHT,
        LEFT
    }
    
    public class MenuFrame : MonoBehaviour {
        [SerializeField] private MenuDirection direction;
        
        [SerializeField] private float nodePadding;
        [SerializeField] private float nodeSize;
        [SerializeField] private float moveSpeed;
        [SerializeField]private float deltaTime = 0.025f;

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
            
            if (direction == MenuDirection.LEFT || direction == MenuDirection.RIGHT) {
                _rectTransform.sizeDelta = new Vector2(_frameSize, 0);
            } else {
                _rectTransform.sizeDelta = new Vector2(0, _frameSize);
            }

            CurrentNode = 0;
        }

        private IEnumerator moveRoutine(int moveTo) {
            if(_isMoving)
                yield break;
            
            _isMoving = true;
            
            float currPos = moveSpeed;
            var extraNum = NodeNum - (moveTo + 1);
            
            var startPos = _rectTransform.anchoredPosition;
            var endPosScalar = extraNum * (nodePadding + nodeSize) + (nodeSize / 2f) - (_frameSize / 2f);
            var endPos = getDirection(direction) * endPosScalar;
            
            while (currPos < 1) {
                _rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, currPos);
                currPos += moveSpeed;
                yield return new WaitForSeconds(deltaTime);
            }
            _rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, 1f);

            _currentNode = moveTo;
            _isMoving = false;
        }
        
        private void setNodePos(int trackNum) {
            StartCoroutine(moveRoutine(trackNum));
        }

        private Vector2 getDirection(MenuDirection dir) {
            switch (dir) {
                case MenuDirection.UP:
                    return Vector2.up;
                
                case MenuDirection.DOWN:
                    return Vector2.down;
                
                case MenuDirection.RIGHT:
                    return Vector2.right;
                
                case MenuDirection.LEFT:
                    return Vector2.left;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
        }
        
    }
}
