using System;
using UnityEngine;

namespace Parameters {
    [CreateAssetMenu]
    public class ResultInfo : ScriptableObject {
        [SerializeField] private int point;
        [SerializeField] private int perfect;
        [SerializeField] private int good;
        [SerializeField] private int miss;
        [SerializeField] private int maxCombo;

        public int Point {
            get => point;
            set {
                if (value < 0)
                    throw new ArgumentException();
                point = value;
            }
        }

        public int Perfect {
            get => perfect;
            set {
                if(value < 0)
                    throw new ArgumentException();
                perfect = value;
            }
        }

        public int Good {
            get => good;
            set {
                if(value < 0)
                    throw new ArgumentException();
                good = value;
            }
        }

        public int Miss {
            get => miss;
            set {
                if(value < 0)
                    throw new ArgumentException();
                miss = value;
            }
        }

        public int MaxCombo => maxCombo;

        public void updateMaxCombo(int newCombo) {
            if (newCombo > maxCombo)
                maxCombo = newCombo;
        }

        public void reset() {
            maxCombo = 0;
            miss = 0;
            good = 0;
            perfect = 0;
            point = 0;
        }
    }
}
