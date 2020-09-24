using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parameters {
    [Serializable]
    public class Track {
        [SerializeField] private string name;
        [SerializeField] private AudioClip audio;
        [SerializeField] private Sprite jacket;
        [SerializeField] private List<Score> scores;
        
        private Dictionary<string, Score> _scores;
        private bool _isInit = false;

        public string Name => name;

        public AudioClip Audio => audio;

        public Sprite Jacket => jacket;

        public Score getScore(string dif) {
            if (_isInit) 
                return _scores[dif];
            
            _scores = new Dictionary<string, Score>();
            foreach (var score in scores) {
                _scores.Add(score.Difficulty, score);
            }
            _isInit = true;
            
            return _scores[dif];
        }

        public List<Score> Scores => new List<Score>(scores);

        public override string ToString() {
            return Name;
        }
    }

    [Serializable]
    public class Score {
        [SerializeField] private string difficulty;
        [SerializeField] private Color imageColor;
        [SerializeField] private TextAsset scoreFile;

        public string Difficulty => difficulty;

        public TextAsset ScoreFile => scoreFile;

        public Color ImageColor => imageColor;

        public override string ToString() {
            return difficulty;
        }
    }

}