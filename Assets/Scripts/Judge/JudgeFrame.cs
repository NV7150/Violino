﻿using System;
using System.Collections.Generic;
using ScoreControl;
using UnityEngine;

namespace Judge {
    public partial class JudgeFrame : MonoBehaviour {
        private readonly string NOTE_TAG = "Note";
        private readonly string LONG_TAG = "Long";
        
        private readonly List<Note> _enteredNotes = new List<Note>();

        public delegate void NoteExit(Note note);
        public event NoteExit onNoteExit;

        public delegate void LongExit();
        public event LongExit onLongExit;
        
        // Start is called before the first frame update
        void Start() {
        
        }

        // Update is called once per frame
        void Update() {
        
        }

        public Note getLastNote() {
            if (hasNote()) {
                var note = _enteredNotes[0];
                _enteredNotes.RemoveAt(0);
                return note;
            }

            return null;
        }

        public bool hasNote() {
            return _enteredNotes.Count > 0;
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag(NOTE_TAG)) {
                _enteredNotes.Add(other.GetComponent<Note>());
            }
        }

        private void OnTriggerExit(Collider other) {
            if (other.CompareTag(NOTE_TAG)) {
                var note = other.GetComponent<Note>();
                onNoteExit?.Invoke(note);
                _enteredNotes.Remove(note);
                
            }else if (other.CompareTag(LONG_TAG)) {
                onLongExit?.Invoke();
            }
        }
    }
}