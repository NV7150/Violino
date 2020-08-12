using Menu;
using UnityEngine;

namespace Test {
    public class SpeedChangeTest : MonoBehaviour {
        [SerializeField] private SpeedManager speedMan;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.A)) {
                speedMan.increaseSpeed();
            }else if (Input.GetKeyDown(KeyCode.D)) {
                speedMan.decreaseSpeed();
            }else if (Input.GetKeyDown(KeyCode.I)) {
                speedMan.enableObj();
            }else if (Input.GetKeyDown(KeyCode.S)) {
                speedMan.disableObj();
            }
        }
    }
}
