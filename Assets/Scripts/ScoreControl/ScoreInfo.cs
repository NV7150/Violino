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

        public string Name => name;

        public int Bpm => BPM;

        public int Offset => offset;

        public int MaxBlock => maxBlock;

        public List<NoteInfo> Notes => new List<NoteInfo>(notes);
    }
}
