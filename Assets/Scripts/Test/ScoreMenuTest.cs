using Menu;
using Parameters;
using UnityEngine;

namespace Test {
    public class ScoreMenuTest : MonoBehaviour {
        [SerializeField] private DifficultyManager difMan;
        [SerializeField] private TracksInfo tracks;
        
        // Start is called before the first frame update
        void Start() {
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.A)) {
                difMan.Selecting -= 1;
            }else if (Input.GetKeyDown(KeyCode.D)) {
                difMan.Selecting += 1;
            }else if (Input.GetKeyDown(KeyCode.I)) {
                difMan.selected();
            }else if (Input.GetKeyDown(KeyCode.S)) {
                difMan.enableMenu(tracks.getTrack(0));
            }
        }
    }
}
