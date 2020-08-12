using System;
using System.Collections.Generic;
using Parameters;
using UnityEngine;
using UnityEngine.UI;

namespace Menu {
    public class DifficultyManager : MonoBehaviour {
        [SerializeField] private Image menuImage;
        [SerializeField] private MenuFrame menuFrame;
        
        [SerializeField] private PlayerInfo plInfo;
        
        [SerializeField] private GameObject difNodePrefab;

        private readonly List<ScoreNode> _difNodes = new List<ScoreNode>();

        private int _selecting = 0;
        private int _maxSelect = 1;
        private bool _isEnable = false;

        public int Selecting {
            get => _selecting;
            set {
                if (!_isEnable || menuFrame.CurrentNode != _selecting) 
                    return;

                if (value < 0)
                    value = _maxSelect - 1;
                if (value >= _maxSelect)
                    value = 0;

                _selecting = value;
                menuFrame.CurrentNode = _selecting;
            }
        }

        // Start is called before the first frame update
        void Start() {
            menuImage.enabled = false;
        }

        // Update is called once per frame
        void Update() {
        
        }

        public void enableMenu(Track track) {
            
            var scores = track.Scores;
            _maxSelect = scores.Count;
            _selecting = 0;
            menuFrame.NodeNum = _maxSelect;

            foreach (var score in scores) {
                generateScoreNode(score);
            }
            
            menuImage.enabled = true;
            _isEnable = true;
            menuFrame.CurrentNode = 0;
        }
        
        private void generateScoreNode(Score score) {
            var nodeComp = Instantiate(difNodePrefab, menuFrame.transform).GetComponent<ScoreNode>();
            nodeComp.setNode(score);
            _difNodes.Add(nodeComp);
            _isEnable = false;
        }

        public void selected() {
            var score = _difNodes[_selecting].Score;
            plInfo.ScoreText = score.ScoreFile;
        }

        public void clearNodes() {
            foreach (var node in _difNodes) {
                Destroy(node.gameObject);
            }
            _difNodes.Clear();
            menuImage.enabled = false;
            _isEnable = false;
        }
    }
}
