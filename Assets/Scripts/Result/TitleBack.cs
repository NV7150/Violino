using UnityEngine;
using UnityEngine.SceneManagement;

namespace Result {
    public class TitleBack : MonoBehaviour {
        [SerializeField] private string selectSceneName;
        [SerializeField] private string backButtonName;

        // Update is called once per frame
        void Update() {
            if (Input.GetButtonDown(backButtonName)) {
                backSelect();
            }
        }

        void backSelect() {
            SceneManager.LoadScene(selectSceneName);
        }
    }
}
