using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Menu {
    public enum MenuDirection {
        UP,
        DOWN,
        RIGHT,
        LEFT
    }

    public class MenuFrame : MonoBehaviour {
        [SerializeField] private MenuDirection direction;

        [SerializeField] private float nodeSpacing;
        [SerializeField] private Vector2 nodeAspect;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float deltaTime = 0.025f;
        
        [SerializeField] private GameObject canvas;
        

        private Vector2 _nodeSize;
        
        private int _nodeNum = 0;
        private int _currentNode = 0;
        private bool _isMoving = false;
        private float _frameSize = 0;
        private float _directionSize;

        private RectTransform _rectTransform;
        private Vector2 _screenSize;

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
                } else if (NodeNum <= value) {
                    value = 0;
                }

                setNodePos(value);
            }
        }

        private void Awake() {
            _rectTransform = GetComponent<RectTransform>();

            _screenSize = 
                canvas.TryGetComponent(out CanvasScaler scalerComp) ? 
                    scalerComp.referenceResolution 
                    : new Vector2(Screen.width, Screen.height);
                
            calculateNodeSize();
            _directionSize = getDirectionSize();
        }
        
        void calculateNodeSize() {
            var anchorSize = new Vector2(1f,1f);
            
            //再帰的にアンカーの大きさを取得
            var calObj = transform;
            do {
                var rect = calObj.GetComponent<RectTransform>();
                var anchorMin = rect.anchorMin;
                var anchorMax = rect.anchorMax;
                
                var anchorDif = anchorMax - anchorMin;
                anchorSize = Vector2.Scale(anchorSize, anchorDif);
                
                calObj = calObj.transform.parent;
            } while (calObj != canvas.transform);

            float height, width;
            if (direction == MenuDirection.RIGHT || direction == MenuDirection.LEFT) {
                height = anchorSize.y * _screenSize.y;
                width = height * nodeAspect.x / nodeAspect.y ;
            } else {
                width = anchorSize.x * _screenSize.x;
                height = width * nodeAspect.y / nodeAspect.x ;
            }
            
            _nodeSize = new Vector2(width, height);
        }

        private float getDirectionSize() {
            switch (direction) {
                case MenuDirection.UP:
                    goto case MenuDirection.DOWN;
                case MenuDirection.DOWN:
                    return _nodeSize.y;

                case MenuDirection.RIGHT:
                    goto case MenuDirection.LEFT;
                case MenuDirection.LEFT:
                    return _nodeSize.x;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        // Start is called before the first frame update
        void Start() {
        }
        

        // Update is called once per frame
        void Update() {

        }

        private void setFrameSize() {
            _frameSize = _nodeNum * (nodeSpacing + _directionSize) - nodeSpacing;

            if (direction == MenuDirection.LEFT || direction == MenuDirection.RIGHT) {
                _rectTransform.sizeDelta = new Vector2(_frameSize, 0);
            } else {
                _rectTransform.sizeDelta = new Vector2(0, _frameSize);
            }

            CurrentNode = 0;
        }

        private IEnumerator moveRoutine(int moveTo) {
            if (_isMoving)
                yield break;

            _isMoving = true;

            float currPos = moveSpeed;
            var extraNum = NodeNum - (moveTo + 1);

            var startPos = _rectTransform.anchoredPosition;
            var endPosScalar = extraNum * (nodeSpacing + _directionSize) + (_directionSize / 2f) - (_frameSize / 2f);
            var endPos = getDirection() * endPosScalar;

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

        private Vector2 getDirection() {
            switch (direction) {
                case MenuDirection.UP:
                    return Vector2.up;

                case MenuDirection.DOWN:
                    return Vector2.down;

                case MenuDirection.RIGHT:
                    return Vector2.right;

                case MenuDirection.LEFT:
                    return Vector2.left;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
