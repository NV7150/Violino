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

        public int Lpb => LPB;

        public int Num => num;

        public int Block => block;

        public int Type => type;

        public List<NoteInfo> Notes => new List<NoteInfo>(notes);
    }
}
