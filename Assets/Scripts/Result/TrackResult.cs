using Parameters;
using UnityEngine;
using UnityEngine.UI;

namespace Result {
    public class TrackResult : MonoBehaviour {
        [SerializeField] private PlayerInfo plInfo;

        [SerializeField] private Image jacket;
        [SerializeField] private Image difBackGround;
        [SerializeField] private Text difName;
        
        // Start is called before the first frame update
        void Start() {
            jacket.sprite = plInfo.Track.Jacket;
            difBackGround.color = plInfo.Score.ImageColor;
            difName.text = plInfo.Score.Difficulty;
        }

        // Update is called once per frame
        void Update() {
        
        }
    }
}
