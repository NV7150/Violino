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
    }

    [Serializable]
    public class Score {
        [SerializeField] private string difficulty;
        [SerializeField] private Color imageColor;
        [SerializeField] private TextAsset asset;

        public string Difficulty => difficulty;

        public TextAsset Asset => asset;

        public Color ImageColor => imageColor;
    }

}