using Parameters;
using UnityEngine;
using UnityEngine.UI;
using Visuals;

namespace Menu {
    public class SpeedManager : MonoBehaviour {
        [SerializeField] private PlayerInfo playerInfo;
        [SerializeField] private Text text;
        [SerializeField] private GameObject dispObj;
        [SerializeField] private float speedUnit = 0.1f;
        [SerializeField] private float speedDefault = 1.0f;

        [SerializeField] private BgColorChanger changer;

        // Start is called before the first frame update
        void Start() {
            playerInfo.Speed = speedDefault;
            disableObj();
        }

        // Update is called once per frame
        void Update() {
        }

        public void enableObj() {
            dispObj.SetActive(true);
            playerInfo.Speed = speedDefault;
        }

        public void enterMode() {
            changer.enableImage();
        }

        public void exitMode() {
            changer.disableImage();
        }

        public void disableObj() {
            dispObj.SetActive(false);
        }

        public void increaseSpeed() {
            playerInfo.Speed += speedUnit;
            updateSpeed();
        }

        public void decreaseSpeed() {
            playerInfo.Speed -= speedUnit;
            updateSpeed();
        }
        
        private void updateSpeed() {
            text.text = $"{playerInfo.Speed:f1}";
        }
        
    }
}
