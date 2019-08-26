using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class AICharacterControl : MonoBehaviour
    {
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for

        private void Start()
        {
            character = GetComponent<ThirdPersonCharacter>();
        }


        private void Update()
        {
            FindClosestTarget();

            if (target == null) return;

            character.Move(target.position - transform.position, false, false);
        }

        private void FindClosestTarget()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if (players.Length > 0)
            {
                float minDistance = Vector3.Distance(players[0].transform.position, gameObject.transform.position);
                Transform currentTarget = null;
                foreach (GameObject player in players)
                {
                    float tmp = Vector3.Distance(player.transform.position, gameObject.transform.position);
                    ThirdPersonCharacter thirdPersonCharacter = player.GetComponent<ThirdPersonCharacter>();
                    if (tmp <= minDistance && !thirdPersonCharacter.m_Dead)
                    {
                        minDistance = tmp;
                        currentTarget = player.transform;
                    }
                }
                this.SetTarget(currentTarget);
            }
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
