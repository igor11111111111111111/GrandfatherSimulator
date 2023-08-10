using TMPro;
using UnityEngine;

namespace GrandfatherSimulator
{
    public class BaseStatsUI : MonoBehaviour
    {
        public TextMeshProUGUI Money;
        public TextMeshProUGUI Age;
        public Player Player;
        private string DayTime;

        private void Start()
        {
            DayTime = "07.02";
            Age.text = DayTime + ", " + Player.Data.Age + " лет";
        }

        private void Update()
        {
            Money.text = Player.Data.Money + " Р";
        }
    }
}
