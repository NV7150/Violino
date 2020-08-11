﻿using System;
using System.Collections.Generic;
using Parameters;
using UnityEngine;

namespace Menu {
    public class MenuManager : MonoBehaviour {
        [SerializeField] private TracksInfo tracks;
        [SerializeField] private PlayerInfo playerInfo;
        [SerializeField] private MenuFrame menuFrame;

        [SerializeField] private GameObject trackNodeObj;

        private int _selectingTrack = 0;

        public int SelectingTrack {
            get => _selectingTrack;
            set {
                if (menuFrame.CurrentTrack != _selectingTrack)
                    return;
                
                if (value < 0) {
                    value = tracks.getTrackNum() - 1;
                }else if (tracks.getTrackNum() <= value) {
                    value = 0;
                }
                
                _selectingTrack = value;
                menuFrame.CurrentTrack = _selectingTrack;
            }
        }

        // Start is called before the first frame update
        void Start() {
            initMenu();
            menuFrame.TrackNum = tracks.getTrackNum();
        }

        private void initMenu() {
            for (int i = 0; i < tracks.getTrackNum(); i++) {
                var track = tracks.getTrack(i);
                var node = generateTrack(track);
            }
        }

        private TrackNode generateTrack(Track track) {
            var obj = Instantiate(trackNodeObj, menuFrame.transform);
            var trackNode = obj.GetComponent<TrackNode>();
            trackNode.Track = track;
            return trackNode;
        }

        // Update is called once per frame
        void Update() {
            
        }

        public void selected() {
            Debug.Log(tracks.getTrack(_selectingTrack).Name);
        }
    }
}