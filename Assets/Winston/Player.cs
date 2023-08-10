using UnityEngine;

namespace GrandfatherSimulator
{
    public class Player : MonoBehaviour
    {
        public PlayerData Data;
        public Animator Animator;
        public PlayerController PlayerController;
        public Rigidbody Rigidbody => _rigidbody;
        private Rigidbody _rigidbody;
        public Camera Camera;
        public bool CanMove;
        public bool IsUnderQuest;

        public void Awake()
        {
            CanMove = true;
            IsUnderQuest = false;

            Data = new PlayerData();
            _rigidbody = GetComponent<Rigidbody>();

            PlayerController.OnMove += Move;

        }

        private void Move(Vector3 dir)
        {
            if (!CanMove)
            {
                Animator.SetBool("IsMove", false);
                return;
            }

            var angleRad = (Camera.transform.localEulerAngles * Mathf.Deg2Rad).y;

            if(dir != Vector3.zero)
            {
                dir = new Vector3(
                dir.z * Mathf.Sin(angleRad) + dir.x * Mathf.Cos(angleRad),
                0,
                dir.z * Mathf.Cos(angleRad) + dir.x * -Mathf.Sin(angleRad));
            }

            if (dir == Vector3.zero)
            {
                _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            }
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            _rigidbody.velocity = dir * 1.5f;
            transform.LookAt(transform.position + dir);
            Animator.SetBool("IsMove", dir == Vector3.zero ? false : true);
        }
    }
}
