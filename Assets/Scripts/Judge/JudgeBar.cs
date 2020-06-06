using UnityEngine;

namespace Judge {
    public class JudgeBar : MonoBehaviour {
        [SerializeField] private float speed = 1f;
        
        // Start is called before the first frame update
        void Start() {
        
        }

        // Update is called once per frame
        void Update() {
            transform.Translate(Vector3.up * speed);
        }
    }
}
