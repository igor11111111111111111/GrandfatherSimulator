﻿using UnityEngine;

namespace GrandfatherSimulator
{
    public class Satiety : INeed
    {
        public Satiety(int max)
        {
            Current = Max = max;
        }
        public int Current
        {
            get
            {
                return _current;
            }
            set
            {
                _current = Mathf.Clamp(value, 0, Max);
            }
        }
        private int _current;
        public int Max { get; set; }
    }
}