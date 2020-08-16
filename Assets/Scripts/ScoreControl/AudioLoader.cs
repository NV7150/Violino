using System;
using Parameters;
using UnityEngine;

namespace ScoreControl {
    public class AudioLoader : MonoBehaviour {
        [SerializeField] private PlayerInfo plInfo;

        private AudioSource _audioSource;

        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
        }

        // Start is called before the first frame update
        void Start() {
            _audioSource.clip = plInfo.Track.Audio;
        }

        // Update is called once per frame
        void Update() {
        
        }
    }
}
