using UnityEngine;

namespace GrandfatherSimulator
{
    public class QuestPoint : MonoBehaviour
    {
        public Quest _quest;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player player))
            {
                _quest.QuestPoint = this;
                QuestUI.Instance.StartUI.Show(_quest);
            }
        } 
    }
}
