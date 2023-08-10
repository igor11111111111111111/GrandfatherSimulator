using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GrandfatherSimulator
{
    public class StartQuestUI : MonoBehaviour
    {
        public TextMeshProUGUI Text;
        public Button Accept;
        public Button Deny;
        private Quest _quest;
        public Player Player;
        public Button Stop;

        private void Awake()
        {
            Accept.onClick.AddListener
            (() =>
            {
                QuestUI.Instance.CurrentQuest = _quest;
                _quest.StartQuest(Player);
                Stop.gameObject.SetActive(true);
                Show(false);
            });
            Deny.onClick.AddListener(
            () =>
            {
                Player.CanMove = true;
                Show(false);
            });
        }

        public void Show(Quest quest)
        {
            _quest = quest;
            Player.CanMove = false;
            gameObject.SetActive(true);
            Text.text = quest.UIMessage;
        }

        public void Show(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
