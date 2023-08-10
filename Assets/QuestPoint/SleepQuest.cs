using System.Collections;
using UnityEngine;

namespace GrandfatherSimulator
{
    public class SleepQuest : Quest
    {
        private Player _player;

        public override void StartQuest(Player player)
        {
            _player = player;

            player.Animator.SetTrigger("OnSleep");
            player.transform.position = new Vector3(1.5f, -0.614f, 1.64f);
            player.transform.rotation = Quaternion.Euler(0, 90.68f, 0);
            player.Rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            StartCoroutine(nameof(CustomUpdate));
        }

        public override void StopQuest()
        {
            StopCoroutine(nameof(CustomUpdate));
            _player.CanMove = true;
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
                _player.Data.Fatigue.Current += 3;
                AllNeedsUI.Instance.Refresh(_player.Data);

                yield return new WaitForSeconds(1f);
            }
        }
    }
}
