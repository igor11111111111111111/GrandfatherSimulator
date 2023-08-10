using System.Collections;
using UnityEngine;

namespace GrandfatherSimulator
{
    public class NeedsDegradator : MonoBehaviour
    {
        public Player Player;

        private void Start()
        {
            StartCoroutine(nameof(CustomUpdate));
        }

        private IEnumerator CustomUpdate()
        {
            while (true)
            {
                Player.Data.Health.Current--;
                Player.Data.Fatigue.Current--;
                Player.Data.Leisure.Current--;
                Player.Data.Satiety.Current--;
                AllNeedsUI.Instance.Refresh(Player.Data);

                yield return new WaitForSeconds(3f);
            }
        }
    }
}
