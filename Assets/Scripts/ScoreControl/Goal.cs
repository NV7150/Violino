using System;
using UnityEngine;

namespace ScoreControl {
    public class Goal : MonoBehaviour {
        [SerializeField] private string playerTag = "bar";
        
        // Start is called before the first frame update
        void Start() {
            
        }

        // Update is called once per frame
        void Update() {
        
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag(playerTag)) {
                endGame();
            }
        }

        private void endGame() {
            //TODO:実装
            Debug.Log("goal!");
        }
    }
}
