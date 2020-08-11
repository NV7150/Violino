using Menu;
using UnityEngine;

namespace Test {
    public class TrackMoveTest : MonoBehaviour {
        [SerializeField] private MenuManager man;

        // Start is called before the first frame update
        void Start() {
            man.SelectingTrack = 0;
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.D)) {
                man.SelectingTrack += 1;
            }else if (Input.GetKeyDown(KeyCode.A)) {
                man.SelectingTrack -= 1;
            }else if (Input.GetKeyDown(KeyCode.Space)) {
                man.selected();
            }
        }
    }
}
