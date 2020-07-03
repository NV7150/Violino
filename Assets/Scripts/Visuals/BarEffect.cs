using System;
using System.Collections.Generic;
using Judge;
using ScoreControl;
using UnityEngine;

namespace Visuals {
    public class BarEffect : MonoBehaviour {
        [SerializeField] private RhythmJudge rhythmJudge;
        [SerializeField] private HoldEffectBase effectR;
        [SerializeField] private HoldEffectBase effectC;
        [SerializeField] private HoldEffectBase effectL;

        private readonly Dictionary<NoteLane, HoldEffectBase> _effectDict 
            = new Dictionary<NoteLane, HoldEffectBase>();
        
        private void Awake() {
            _effectDict.Add(NoteLane.RIGHT, effectR);
            _effectDict.Add(NoteLane.CENTER, effectC);
            _effectDict.Add(NoteLane.LEFT, effectL);
        }

        // Start is called before the first frame update
        void Start() {
        
        }

        // Update is called once per frame
        void Update() {
            foreach (NoteLane lane in Enum.GetValues(typeof(NoteLane))) {
                if (!_effectDict[lane].getEffectStatus()) {
                    if (rhythmJudge.getLaneHolding(lane)) {
                        _effectDict[lane].startEffect();
                    }
                } else {
                    if (!rhythmJudge.getLaneHolding(lane)) {
                        _effectDict[lane].endEffect();
                    }
                }
            }
        }
    }
}
