using System;
using UnityEngine;

namespace Visuals {

    public class ColorBarChanger : MonoBehaviour {

        [SerializeField] private Material baseMat;
        [SerializeField] private Material changeMat;
        [SerializeField] private string changeButton;

        private MeshRenderer _meshRenderer;
        private State _currStatus = State.BASE;

        private void Awake() {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        // Start is called before the first frame update
        void Start() {
            toBaseMat();
        }

        // Update is called once per frame
        void Update() {
            judgeChanging();
        }

        void judgeChanging() {
            if (Input.GetButton(changeButton)) {
                toChangeMat();
            } else {
                toBaseMat();
            }
        }

        void toBaseMat() {
            if (_currStatus == State.BASE) 
                return;
            
            _meshRenderer.material = baseMat;
            _currStatus = State.BASE;
        }

        void toChangeMat() {
            if (_currStatus == State.CHANGE)
                return;
            
            _meshRenderer.material = changeMat;
            _currStatus = State.CHANGE;
        }

        private enum State {
            BASE,
            CHANGE
        }
    }
}
