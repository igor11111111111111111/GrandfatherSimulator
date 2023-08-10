using System.Collections;
using UnityEngine;

namespace GrandfatherSimulator
{
    public class WatchTVQuest : Quest
    {
        public TV TV;
        public Camera Camera;
        private Player _player;
        
        public override void StartQuest(Player player)
        {
            _player = player;

            TV.Switch(true);
            Camera.transform.position = new Vector3(2.72f, 2.26f, 0.16f);
            Camera.transform.rotation = Quaternion.Euler(30.35f, 41f, 0);

            player.IsUnderQuest = true;
            player.Animator.SetTrigger("OnWatchTV");
            player.transform.position = new Vector3(2.73f, -0.117f, 1.625f);
            player.transform.rotation = Quaternion.Euler(-11.2f, 90.68f, 0);
            player.Rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            StartCoroutine(nameof(CustomUpdate));
        }

        public override void StopQuest()
        {
            StopCoroutine(nameof(CustomUpdate));

            TV.Switch(false);
            Camera.transform.rotation = Quaternion.Euler(42.15f, 0, 0);

            _player.CanMove = true;
            _player.IsUnderQuest = false;
            _player.Animator.SetTrigger("OnEndQuest");
            _player.Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            _player.transform.position = QuestPoint.transform.position +
                new Vector3(-1, 0, 0);
            _player.transform.rotation = Quaternion.Euler(0, 180f, 0);
        }

        private IEnumerator CustomUpdate()
        {
            while (true)
            {
                _player.Data.Leisure.Current += 3;
                AllNeedsUI.Instance.Refresh(_player.Data);

                yield return new WaitForSeconds(1f);
            }
        }
    }
}
