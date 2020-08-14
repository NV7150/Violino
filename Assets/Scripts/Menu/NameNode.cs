using Parameters;
using UnityEngine;
using UnityEngine.UI;

namespace Menu {
    public class NameNode : MonoBehaviour {
        [SerializeField] private Text text;

        private string _name;

        public string Name {
            get => _name;
            set {
                _name = value;
                text.text = _name;
            }
        }

        // Start is called before the first frame update
        void Start() {
        }

        // Update is called once per frame
        void Update() {
        
        }
    }
}
