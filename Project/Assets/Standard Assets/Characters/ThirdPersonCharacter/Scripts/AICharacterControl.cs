using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;

            agent.stoppingDistance = 0.6f;
        }


        private void Update()
        {
            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);

            FindClosestTarget();
        }

        private void FixedUpdate()
        {
           // FindClosestTarget();
        }

        private void FindClosestTarget()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if (players.Length > 0)
            {
                float minDistance = Vector3.Distance(players[0].transform.position, gameObject.transform.position);
                Transform currentTarget = players[0].transform;
                foreach (GameObject player in players)
                {
                    float tmp = Vector3.Distance(player.transform.position, gameObject.transform.position);
                    if (tmp < minDistance)
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
