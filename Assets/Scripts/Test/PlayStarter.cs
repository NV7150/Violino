using Judge;
using UnityEngine;

namespace Test {
    public class PlayStarter : MonoBehaviour {
        [SerializeField] private JudgeBar judgeBar;
        
        // Start is called before the first frame update
        void Start() {
            
        }

        // Update is called once per frame
        void Update() {
            if(Input.GetKeyDown(KeyCode.S))
                judgeBar.startPlay();
        }
    }
}
