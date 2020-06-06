using UnityEngine;

namespace ScoreControl {
    public class LongNote : MonoBehaviour {
        [SerializeField] private GameObject noteStart;
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

        public void initNote(NoteLane lane, NoteDirection dir, Material sectionMat, Material longMat, float length) {
            noteStart.GetComponent<Note>().initNote(lane, dir, NoteType.LONG, sectionMat);
            _noteObjRenderer.material = longMat;
            _noteEndRenderer.material = sectionMat;
            setLength(length);
        }

        public void setLength(float length) {
            var lcScale = noteObj.transform.localScale;

            var rootTrans = transform;
            var rootScale = rootTrans.localScale;
            var rootPos = rootTrans.position;
            
            noteStart.transform.position = rootPos;
            
            noteObj.transform.localScale = new Vector3(lcScale.x * rootScale.x, length, lcScale.z * rootScale.z);
            noteObj.transform.position = rootPos + Vector3.up * (length / 2);
                                         
            noteEnd.transform.position = rootPos + Vector3.up * length;
            
        }
    }
}
