using UnityEngine;

namespace GrandfatherSimulator
{
    public class TV : MonoBehaviour
    {
        public GameObject Body;

        private void Awake()
        {
            Switch(false);
        }

        public void Switch(bool active)
        {
            Body.SetActive(active);
        }
    }
}
