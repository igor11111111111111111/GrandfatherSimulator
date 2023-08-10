using System.Collections;
using UnityEngine;

namespace GrandfatherSimulator
{

    public class SudokuQuest : Quest
    {
        public Camera Camera;
        private Player _player;

        public override void StartQuest(Player player)
        {
            _player = player;

            Camera.transform.position = new Vector3(4.74f, 1.84f, -2.54f);
            Camera.transform.rotation = Quaternion.Euler(20.8f, 124f, 0);

            player.IsUnderQuest = true;
            player.Animator.SetTrigger("OnSudoku");
            player.transform.position = new Vector3(6f, -0.06f, -2.85f);
            player.transform.rotation = Quaternion.Euler(-6f, 176f, 0);
            player.Rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            StartCoroutine(nameof(CustomUpdate));
        }

        public override void StopQuest()
        {
            StopCoroutine(nameof(CustomUpdate));

            Camera.transform.rotation = Quaternion.Euler(42.15f, 180, 0);

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
