using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    PlayerMovement player;

    [SerializeField] float rageRadius = 15;
    bool isSeen = false;

    [SerializeField] float lookWidth = 60;
    [SerializeField] float attackDistance = 2;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMovement>();
        agent.stoppingDistance = attackDistance;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        Vector3 dir = player.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, dir);

        if (angle < lookWidth && distance < rageRadius * 2) isSeen = true;
        if (angle > lookWidth && distance < rageRadius / 2) isSeen = true;

        if (distance > rageRadius * 2.5f) isSeen = false;
        

        if (isSeen == true)
        {
            agent.SetDestination(player.transform.position);
        }
        SetAnimation(distance);
    }

    void SetAnimation(float distance)
    {
        if(agent.desiredVelocity.magnitude > 0.2f)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
        if(distance < attackDistance)
        {
            anim.SetBool("attack", true);
            LookOnPlayer();
        }
        else
        {
            anim.SetBool("attack", false);
        }

    }

    void LookOnPlayer()
    {
        Vector3 dir = player.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Euler(0, rot.eulerAngles.y, 0);
    }

    public void FollowPlayer()
    {
        agent.SetDestination(player.transform.position);
    }

    private void OnDisable()
    {
        agent.isStopped = true;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rageRadius/2);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rageRadius*2);

        Gizmos.color = Color.yellow;
        Vector3 dirLeft =  Quaternion.Euler(0, -lookWidth, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, dirLeft * rageRadius * 2);

        Vector3 dirRight = Quaternion.Euler(0, lookWidth, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, dirRight * rageRadius * 2);

    }

}
