using System;
using System.Collections.Generic;
using ScoreControl;
using UnityEngine;

namespace Parameters {
    [CreateAssetMenu]
    public class TracksInfo : ScriptableObject {
        [SerializeField]private List<Track> tracks;

        public Track getTrack(int id) {
            return tracks[id];
        }

        public int getTrackNum() {
            return tracks.Count;
        }
    }
}
