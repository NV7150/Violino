using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreControl {
    public class ScoreFileLoader : MonoBehaviour {
        [SerializeField] private List<GameObject> scoreUsers;
        [SerializeField] private bool generateOnLoad = true;

        private readonly List<ScoreUser> _users = new List<ScoreUser>();
        
        private static TextAsset _scoreJson;
        
        public static void setScore(TextAsset score) {
            _scoreJson = score;
        }

        void Start() {
            foreach (var userObject in scoreUsers) {
                ScoreUser userComp;
                try {
                    userComp = userObject.GetComponent<ScoreUser>();
                } catch (Exception e) {
                    throw new InvalidProgramException(userObject.name + " has no ScoreUser");
                }
                _users.Add(userComp);
            }
            
            if (generateOnLoad) {
                generateObj();
            }
        }

        public void generateObj() {
            var scoreInfo = JsonUtility.FromJson<ScoreInfo>(_scoreJson.text);
            foreach (var user in _users) {
                user.scoreDecided(scoreInfo);
            }
        }

    }
}