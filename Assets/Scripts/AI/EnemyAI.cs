using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    private bool isAware = false;
    public float fieldOfView = 40f;
    public float viewDistance = 10f;
    public float shootDistance = 5f;
    private NavMeshAgent agent;
    //public Transform[] PossibleTargets;
    //protected Transform target;
    float wanderRadius = 7f;
    private Vector3 wanderPoint;
    Animator anim;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        //wanderPoint = RandomWanderPoint();
        //target = PossibleTargets[Random.Range(0, PossibleTargets.Length)];
    }
    private void Update()
    {
        if (isAware)
        {
            anim.SetBool("isWalking", true);
            agent.SetDestination(CalculateDestination());
            if (Vector3.Distance(player.transform.position, transform.position) < shootDistance)
            {
                ShootLogic();
            }
        }
        else
        {
            //Wander();
            SearchForPlayer();
        }
    }

    void SearchForPlayer ()
    {

        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(player.transform.position)) < fieldOfView / 2f)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < viewDistance)
            {
                transform.LookAt(player.transform.position);
                RaycastHit hit;
                //if (Physics.Raycast(transform.position + new Vector3(0, 1.0f, 2f), transform.forward, out hit))
                //{

                //    Debug.DrawLine(transform.position + new Vector3(0, 1.5f, 0), hit.point);
                //    Debug.Log(hit.collider.gameObject.tag);
                //    if (hit.collider.CompareTag("Player"))
                //        OnAware();
                //}

                OnAware();

            }
            }
    }

    public void OnAware()
    {
        isAware = true;
    }

    public void Wander()
    {
        if (Vector3.Distance (transform.position, wanderPoint) < 2f)
        {
            wanderPoint = RandomWanderPoint();
        }
        else
        {
            agent.SetDestination(wanderPoint);
        }
    }

    public Vector3 RandomWanderPoint()
    {
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1);
        return new Vector3(navHit.position.x, transform.position.y, navHit.position.z);
    }

    public virtual Vector3 CalculateDestination()
    {
        return player.transform.position;
    }

    public virtual void ShootLogic()
    {
        agent.velocity = Vector3.zero;
        anim.SetBool("isWalking", false);
        anim.SetTrigger("shoot");
        isAware = false;
    }


}
