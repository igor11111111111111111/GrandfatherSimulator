using UnityEngine;
using UnityEngine.EventSystems;

namespace GrandfatherSimulator
{
    public class CameraRotator : MonoBehaviour, IDragHandler
    {
        public Camera Camera;
        private float _speed;

        private void Awake()
        {
            _speed = 0.5f;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 eulers = new Vector3(0, -eventData.delta.x * _speed, 0);
            Camera.transform.Rotate(eulers, Space.World);
        }
    }
}
