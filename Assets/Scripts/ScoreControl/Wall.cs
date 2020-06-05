using System.Collections.Generic;
using UnityEngine;

namespace ScoreControl {
    public class Wall : MonoBehaviour {
        [SerializeField] private List<MeshRenderer> applyMatObj;

        public void initWall(Material mat) {
            foreach (var renderer in applyMatObj) {
                renderer.material = mat;
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
