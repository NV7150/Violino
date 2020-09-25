using System;
using Parameters;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
    enum MenuMode {
        TRACK_CHOOSE,
        DIFFICULTY,
        SPEED
    }
    
    public class MenuManager : MonoBehaviour {
        [SerializeField] private TrackChooseManager trackChooseManager;
        [SerializeField] private DifficultyManager difficultyManager;
        [SerializeField] private SpeedManager speedManager;
        [SerializeField] private string playSceneName;

        private MenuMode _currMode = MenuMode.TRACK_CHOOSE;
        private Track _currTrack;

        // Start is called before the first frame update
        void Start() {
            
        }

        // Update is called once per frame
        void Update() {
        
        }

        public void next() {
            switch (_currMode) {
                case MenuMode.TRACK_CHOOSE:
                    trackChooseManager.SelectingTrack += 1;
                    break;
                
                case MenuMode.DIFFICULTY:
                    difficultyManager.Selecting += 1;
                    break;
                
                case MenuMode.SPEED:
                    speedManager.increaseSpeed();
                    break;
            }
        }

        public void prev() {
            switch (_currMode) {
                case MenuMode.TRACK_CHOOSE:
                    trackChooseManager.SelectingTrack -= 1;
                    break;
                
                case MenuMode.DIFFICULTY:
                    difficultyManager.Selecting -= 1;
                    break;
                
                case MenuMode.SPEED:
                    speedManager.decreaseSpeed();
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void enter() {
            switch (_currMode) {
                case MenuMode.TRACK_CHOOSE:
                    _currTrack = trackChooseManager.selected();
                    
                    difficultyManager.enableMenu(_currTrack);
                    difficultyManager.enterMode();
                    
                    speedManager.enableObj();
                    speedManager.exitMode();
                    
                    _currMode = MenuMode.DIFFICULTY;
                    break;
                
                case MenuMode.DIFFICULTY:
                    difficultyManager.selected();
                    difficultyManager.exitMode();
                    
                    speedManager.enterMode();
                    
                    _currMode = MenuMode.SPEED;
                    break;
                
                case MenuMode.SPEED:
                    difficultyManager.clearNodes();
                    speedManager.disableObj();

                    SceneManager.LoadScene(playSceneName);
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void cancel() {
            
        }

    }
}
