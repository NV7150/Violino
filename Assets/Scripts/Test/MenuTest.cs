using Menu;
using UnityEngine;

namespace Test {
    public class MenuTest : MonoBehaviour {
        [SerializeField] private MenuManager menuManager;
        
        // Start is called before the first frame update
        void Start() {
        
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.A)) {
                menuManager.prev();
            }else if (Input.GetKeyDown(KeyCode.D)) {
                menuManager.next();
            }else if (Input.GetKeyDown(KeyCode.S)) {
                menuManager.enter();
            }
        }
    }
}
