using System.Collections.Generic;
using System.Security.Cryptography;
using Judge;
using UnityEngine;
using Visuals;

namespace ScoreControl {
    public class LongNote : MonoBehaviour, Note {
        [SerializeField] private GameObject rootObj;
        [SerializeField] private GameObject noteStart;
        [SerializeField] private GameObject noteObj;
        [SerializeField] private GameObject noteEnd;
        [SerializeField] private List<MeshRenderer> meshes;
        [SerializeField] private BanishEffect effect;

        private MeshRenderer _noteObjRenderer;
        private MeshRenderer _noteEndRenderer;
        private MeshRenderer _noteStartRenderer;

        private NoteLane _lane;
        private NoteDirection _direction;

        private NoteType _type = NoteType.LONG;

        private event NoteBanished onNoteBanished;

        public bool IsHolding { get; set; }

        void Awake() {
            _noteObjRenderer = noteObj.GetComponent<MeshRenderer>();
            _noteEndRenderer = noteEnd.GetComponent<MeshRenderer>();
            _noteStartRenderer = noteStart.GetComponent<MeshRenderer>();
        }

        // Start is called before the first frame update
        void Start() {
        }

        // Update is called once per frame
        void Update() {
        
        }

        public void initNote(NoteLane lane, NoteDirection dir, Material sectionMat, Material longMat, float length) {
            _noteObjRenderer.material = longMat;
            _noteEndRenderer.material = sectionMat;
            _noteStartRenderer.material = sectionMat;
            
            _lane = lane;
            _direction = dir;
            setLength(length);
        }

        private void setLength(float length) {
            var lcScale = noteObj.transform.localScale;

            var rootTrans = rootObj.transform;
            var rootScale = rootTrans.localScale;
            var rootPos = rootTrans.position;
            
            noteStart.transform.position = rootPos;
            
            noteObj.transform.localScale = new Vector3(lcScale.x * rootScale.x, length, lcScale.z * rootScale.z);
            noteObj.transform.position = rootPos + Vector3.up * (length / 2);
                                         
            noteEnd.transform.position = rootPos + Vector3.up * length;
            
        }
        

        public NoteType getNoteType() {
            return _type;
        }

        public NoteDirection getNoteDirection() {
            return _direction;
        }

        public NoteLane getNoteLane() {
            return _lane;
        }

        public void banish(JudgeCode code) {
            _type = NoteType.BANISHED;
            
            onNoteBanished?.Invoke(this);
            
            foreach (var mesh in meshes) {
                mesh.enabled = false;
            }

            if (code != JudgeCode.MISS) {
                effect.banishEffect(code, banishObj);
            } else {
                banishObj();
            }
        }

        void banishObj() {
            rootObj.SetActive(false);
        }

        public void registerOnBanished(NoteBanished func) {
            onNoteBanished += func;
        }
    }
}
