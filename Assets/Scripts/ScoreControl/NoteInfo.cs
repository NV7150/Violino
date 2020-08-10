using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreControl {
    [Serializable]
    public class NoteInfo {
        [SerializeField] private int LPB;
        [SerializeField] private int num;
        [SerializeField] private int block;
        [SerializeField] private int type;
        [SerializeField] private List<NoteInfo> notes;

        private bool _isSorted = false;

        public int Lpb => LPB;

        public int Num => num;

        public int Block => block;

        public int Type => type;

        public List<NoteInfo> Notes {
            get {
                if (_isSorted) 
                    return new List<NoteInfo>(notes);
                
                notes.Sort((a,b) => a.isGreaterThan(b));
                _isSorted = true;
                return new List<NoteInfo>(notes);
            }
        }

        public int isGreaterThan(NoteInfo compare) {
            if (compare.Num == Num) {
                return Block - compare.Block;
            } else {
                return Num - compare.Num;
            }
        }
    }
}
