using UnityEngine;

namespace GrandfatherSimulator
{
    public class CameraMove : MonoBehaviour
    {
        public Player Player;
        private Vector3 _offset;

        private void Awake()
        {
            _offset = new Vector3(2, 3.9f, 2);
        }

        private void Update()
        {
            if (Player.IsUnderQuest)
                return;

            var angleRad = (transform.localEulerAngles * Mathf.Deg2Rad).y;

            var offset = new Vector3(
                -Mathf.Sin(angleRad) * _offset.x,
                _offset.y,
                -Mathf.Cos(angleRad) * _offset.z);

            transform.position = Vector3.Lerp(transform.position, Player.transform.position + offset, 0.03f);
        }
    }
}
