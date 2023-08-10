using UnityEngine;

namespace GrandfatherSimulator
{
    public class AllNeedsUI : MonoBehaviour
    {
        public static AllNeedsUI Instance;
        public NeedUI Fatigue;
        public NeedUI Leisure;
        public NeedUI Health;
        public NeedUI Satiety;

        private void OnEnable()
        {
            Instance = this;
        }

        private void OnDisable()
        {
            Instance = null;
        }

        //public void Refresh(PlayerData data, INeed need)
        //{
        //    if(need is Fatigue)
        //    {
        //        Fatigue.Refresh(data.Fatigue.Current / (float)data.Fatigue.Max);
        //    }
        //    else if()

        //}

        public void Refresh(PlayerData data)
        {
            Fatigue.Refresh(data.Fatigue.Current / (float)data.Fatigue.Max);
            Leisure.Refresh(data.Leisure.Current / (float)data.Leisure.Max);
            Health.Refresh(data.Health.Current / (float)data.Health.Max);
            Satiety.Refresh(data.Satiety.Current / (float)data.Satiety.Max);
        }
    }
}
