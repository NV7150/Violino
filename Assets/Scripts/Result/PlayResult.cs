using Parameters;
using UnityEngine;
using UnityEngine.UI;

namespace Result {
    public class PlayResult : MonoBehaviour {
        [SerializeField] private ResultInfo resultInfo;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text perfectText;
        [SerializeField] private Text goodText;
        [SerializeField] private Text badText;
        [SerializeField] private Text comboText;
        
        // Start is called before the first frame update
        void Start() {
            scoreText.text = resultInfo.Point + "";
            perfectText.text = resultInfo.Perfect + "";
            goodText.text = resultInfo.Good + "";
            badText.text = resultInfo.Miss + "";
            comboText.text = resultInfo.MaxCombo + "";
        }

        // Update is called once per frame
        void Update() {
        
        }
    }
}
