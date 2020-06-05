using UnityEngine;

namespace ScoreControl {
    public class ScoreFileLoader : MonoBehaviour {
        [SerializeField] private ScoreGenerator scoreGen;
        [SerializeField] private bool generateOnLoad = true;
        
        private static TextAsset _scoreJson;

        public static void setScore(TextAsset score) {
            _scoreJson = score;
        }

        void Start() {
            if(generateOnLoad) 
                generateObj();
        }

        public void generateObj() {
            var scoreInfo = JsonUtility.FromJson<ScoreInfo>(_scoreJson.text);
            scoreGen.generateScoreObj(scoreInfo);
        }

    }
}