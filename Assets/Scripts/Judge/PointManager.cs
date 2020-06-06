using UnityEngine;

namespace Judge {
    public class PointManager : MonoBehaviour {
        private int _point = 0;
        private int _combo = 0;
        
        // Start is called before the first frame update
        void Start() {
        
        }

        // Update is called once per frame
        void Update() {
        
        }

        public void judge(JudgeCode code) {
            Debug.Log(code);
            switch (code) {
                case JudgeCode.PERFECT:
                    _point++;
                    _combo++;
                    break;
                
                case JudgeCode.GOOD:
                    _point++;
                    _combo++;
                    break;
                
                case JudgeCode.BAD:
                    _combo = 0;
                    break;
                
                case JudgeCode.MISS:
                    _combo = 0;
                    break;
            }
        }
    }
}
