using UnityEngine;

namespace GrandfatherSimulator
{
    public abstract class Quest : MonoBehaviour
    {
        public string Name;
        public string UIMessage;
        [HideInInspector]
        public QuestPoint QuestPoint;
        protected MeshRenderer _mesh;

        private void Awake()
        {
            _mesh =  GetComponent<MeshRenderer>();
        }

        public virtual void StartQuest(Player player)
        {

        }

        public virtual void StopQuest()
        {

        }
    }
}