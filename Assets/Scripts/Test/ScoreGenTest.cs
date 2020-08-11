using ScoreControl;
using UnityEngine;

namespace Test {
    public class ScoreGenTest : MonoBehaviour {
        [SerializeField] private TextAsset score;

        [SerializeField] private ScoreFileLoader loader;
        // Start is called before the first frame update
        void Start() {
            // ScoreFileLoader.setScore(score);
            loader.generateObj();
        }

        // Update is called once per frame
        void Update() {
        
        }
    }
}
