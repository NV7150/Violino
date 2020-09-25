using System;
using System.Collections.Generic;
using Parameters;
using UnityEngine;
using Visuals;

namespace Menu {
    public class TrackChooseManager : MonoBehaviour {
        [SerializeField] private TracksInfo tracks;
        [SerializeField] private PlayerInfo playerInfo;
        
        [SerializeField] private MenuFrame trackMenuFrame;
        [SerializeField] private MenuFrame nameMenuFrame;

        [SerializeField] private GameObject trackNodePrefab;
        [SerializeField] private GameObject nameNodePrefab;

        private int _selectingTrack = 0;
        
        public delegate void TrackChanged(Track track);

        public event TrackChanged onTrackChanged;
        
        public int SelectingTrack {
            get => _selectingTrack;
            set {
                if (trackMenuFrame.CurrentNode != _selectingTrack)
                    return;
                
                if (value < 0) {
                    value = tracks.getTrackNum() - 1;
                }else if (tracks.getTrackNum() <= value) {
                    value = 0;
                }
                
                _selectingTrack = value;
                trackMenuFrame.CurrentNode = _selectingTrack;
                nameMenuFrame.CurrentNode = _selectingTrack;

                onTrackChanged?.Invoke(tracks.getTrack(_selectingTrack));
            }
        }


        // Start is called before the first frame update
        void Start() {
            initMenu();
            trackMenuFrame.NodeNum = tracks.getTrackNum();
            nameMenuFrame.NodeNum = tracks.getTrackNum();
        }


        private void initMenu() {
            for (int i = 0; i < tracks.getTrackNum(); i++) {
                var track = tracks.getTrack(i);
                generateTrack(track);
                generateName(track);
            }
        }

        private void generateTrack(Track track) {
            var obj = Instantiate(trackNodePrefab, trackMenuFrame.transform);
            var trackNode = obj.GetComponent<TrackNode>();
            trackNode.Track = track;
        }

        private void generateName(Track track) {
            var obj = Instantiate(nameNodePrefab, nameMenuFrame.transform);
            var nameNode = obj.GetComponent<NameNode>();
            nameNode.Name = track.Name;
        }

        // Update is called once per frame
        void Update() {
            
        }

        public Track selected() {
            var selectedTrack = tracks.getTrack(_selectingTrack);
            playerInfo.Track = selectedTrack;
            return selectedTrack;
        }
    }
}
