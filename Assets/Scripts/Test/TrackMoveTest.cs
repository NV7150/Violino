using Menu;
using UnityEngine;

namespace Test {
    public class TrackMoveTest : MonoBehaviour {
        [SerializeField] private MenuFrame frame;

        [SerializeField] private int trackNum;
        // Start is called before the first frame update
        void Start() {
            frame.TrackNum = trackNum;
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.A)) {
                frame.CurrentTrack += 1;
            }else if (Input.GetKeyDown(KeyCode.D)) {
                frame.CurrentTrack -= 1;
            }
        }
    }
}
