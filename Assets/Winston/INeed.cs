using UnityEngine;

namespace GrandfatherSimulator
{
    public interface INeed
    {
        public int Current { get; set; }
        public int Max { get; set; }
    }
}