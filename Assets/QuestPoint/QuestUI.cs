using UnityEngine;
using UnityEngine.UI;

namespace GrandfatherSimulator
{
    public class QuestUI : MonoBehaviour
    {
        public static QuestUI Instance;
        public StartQuestUI StartUI;
        public Button Stop;
        [HideInInspector]
        public Quest CurrentQuest;

        private void OnEnable()
        {
            Instance = this;
            StartUI.Show(false);
            Stop.onClick.AddListener(StopQuestButton);
            Stop.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            Instance = null;
        }

        private void StopQuestButton()
        {
            if (CurrentQuest == null)
                return;
            CurrentQuest.StopQuest();
            Stop.gameObject.SetActive(false);
        }
    }
}
