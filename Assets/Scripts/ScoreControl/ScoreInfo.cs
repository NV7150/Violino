using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreControl {
    [Serializable]
    public class ScoreInfo {
        [SerializeField] private string name;
        [SerializeField] private int BPM;
        [SerializeField] private int offset;
        [SerializeField] private int maxBlock;
        [SerializeField] private List<NoteInfo> notes;

        private bool _isSorted = false;

        public string Name => name;

        public int Bpm => BPM;

        public int Offset => offset;

        public int MaxBlock => maxBlock;

        public List<NoteInfo> Notes {
            get {
                if (_isSorted) 
                    return new List<NoteInfo>(notes);
                
                notes.Sort((a,b) => a.isGreaterThan(b));
                _isSorted = true;
                return new List<NoteInfo>(notes);
            }
        }
    }
}
