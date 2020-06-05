using UnityEngine;

namespace ScoreControl {
    public class LongNote : MonoBehaviour {
        [SerializeField] private GameObject noteObj;
        [SerializeField] private GameObject noteEnd;
        [SerializeField] private float noteEndAlpha = 225;
        

        private MeshRenderer _noteObjRenderer;
        private MeshRenderer _noteEndRenderer;

        void Awake() {
            _noteObjRenderer = noteObj.GetComponent<MeshRenderer>();
            _noteEndRenderer = noteEnd.GetComponent<MeshRenderer>();
        }

        // Start is called before the first frame update
        void Start() {
        }

        // Update is called once per frame
        void Update() {
        
        }

        public void setLength(float length) {
            var lcScale = noteObj.transform.localScale;
            var rootScale = transform.localScale;
            noteObj.transform.localScale = new Vector3(lcScale.x * rootScale.x, length, lcScale.z * rootScale.z);
            noteEnd.transform.position = transform.position + Vector3.up * (length / 2);
        }

        public void setMat(Material longNoteMat, Material endMat) {
            _noteObjRenderer.material = longNoteMat;
            _noteEndRenderer.material = endMat;
        }
    }
}
