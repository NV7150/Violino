using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Visuals {
    public class BgColorChanger : MonoBehaviour {
        [SerializeField] private Color disableColor = Color.gray;
        [SerializeField] private Color enableColor = Color.white;

        [SerializeField] private List<Image> colorNodes;

        private bool _isAble = true;

        // Start is called before the first frame update
        void Start() {
        }

        // Update is called once per frame
        void Update() {
        
        }

        public void enableImage() {
            if (_isAble)
                return;
            
            _isAble = true;
            foreach (var node in colorNodes) {
                node.color = enableColor;
            }
        }

        public void disableImage() {
            if (!_isAble)
                return;
            
            _isAble = false;
            foreach (var node in colorNodes) {
                node.color = disableColor;
            }
        }
    }
}
