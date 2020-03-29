using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private NavMeshAgent agent;

    public bool landed = false;

    private Animator anim;

    private AlienState currentState;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player");

        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }

    private void Update()
    {
        switch (currentState)
        {
            case AlienState.Falling:
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
                    {
                        {
                            if(hit.distance <= 2.5f)
                            {
                                anim.SetBool("hasFallen", true);

                                currentState = AlienState.Chasing;
                            }
                        }
                    }
                    break;
                }

            case AlienState.Chasing:
                {
                    StartCoroutine(enableMovement());
                    if (agent.enabled)
                    {
                        if (player != null)
                        {
                            agent.SetDestination(player.transform.position);
                            GetComponent<Rigidbody>().isKinematic = true;
                            GetComponent<Rigidbody>().useGravity = false;

                            GetComponent<EnemyShooting>().canShoot = true;
                        }
                        if (player == null)
                        {
                            GameObject center = GameObject.Find("Plane");
                            agent.SetDestination(center.transform.position);
                        }
                    }
                    break;
                }
        }
    }

    IEnumerator enableMovement()
    {
        yield return new WaitForSeconds(3f);

        agent.enabled = true;
    }

    public enum AlienState
    {
        Falling,
        Chasing
    }
}
