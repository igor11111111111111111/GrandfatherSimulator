using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrandfatherSimulator
{
    public class CustomizationQuest : Quest
    {
        public Camera Camera;
        private Player _player;
        public List<Texture> Textures;
        public Material material;

        public override void StartQuest(Player player)
        {
            _player = player;

            _mesh.enabled = false;
            Camera.transform.position = new Vector3(3.07f, 1.34f, -2.36f);
            Camera.transform.rotation = Quaternion.Euler(7.73f, -124.5f, 0);

            player.IsUnderQuest = true;
            player.transform.position = new Vector3(0.97f, 0.03f, -3.13f);
            player.transform.rotation = Quaternion.Euler(0, 71.84f, 0);
            player.Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        public override void StopQuest()
        {
            _mesh.enabled = true;
            Camera.transform.rotation = Quaternion.Euler(42.15f, 180, 0);

            _player.CanMove = true;
            _player.IsUnderQuest = false;
            _player.Animator.SetTrigger("OnEndQuest");
            _player.Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            _player.transform.position = QuestPoint.transform.position +
                new Vector3(1, 0, 0);
            _player.transform.rotation = Quaternion.Euler(0, 180f, 0);
        }

        private void Update() // V
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                material.SetTexture("_MainTex", Textures[0]);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                material.SetTexture("_MainTex", Textures[1]);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                material.SetTexture("_MainTex", Textures[2]);
            }
        }
    }
}
