using Parameters;
using UnityEngine;

namespace Judge {
    public class PointManager : MonoBehaviour {
        [SerializeField] private ResultInfo resultInfo;
        
        [SerializeField] private int perfectScore = 10;
        [SerializeField] private int goodScore = 5;
        [SerializeField] private int missScore = 0;

        private int _combo = 0;
        
        // Start is called before the first frame update
        void Start() {
            resultInfo.reset();
        }

        // Update is called once per frame
        void Update() {
        
        }

        public void judge(JudgeCode code) {
            Debug.Log(code);
            switch (code) {
                case JudgeCode.PERFECT:
                    resultInfo.Point += perfectScore;
                    resultInfo.Perfect += 1;
                    break;
                
                case JudgeCode.GOOD:
                    resultInfo.Point += goodScore;
                    resultInfo.Good += 1;
                    break;

                case JudgeCode.MISS:
                    resultInfo.Point += missScore;
                    resultInfo.Miss += 1;
                    _combo = 0;
                    return;
                
                default:
                    return;
            }
            _combo++;
            resultInfo.updateMaxCombo(_combo);
        }
    }
}
