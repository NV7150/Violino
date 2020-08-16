using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScoreControl {
    public class Goal : MonoBehaviour {
        [SerializeField] private string playerTag = "bar";
        [SerializeField] private string resultSceneName = "ResultScene";
        
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
            SceneManager.LoadScene(resultSceneName);
        }
    }
}
