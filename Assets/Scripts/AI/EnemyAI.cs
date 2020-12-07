using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public bool isAware = false;
    public float fieldOfView = 40f;
    public float viewDistance = 10f;
    public float shootDistance = 5f;
    public NavMeshAgent agent;
    //public Transform[] PossibleTargets;
    //protected Transform target;
    float wanderRadius = 7f;
    private Vector3 wanderPoint;
    public EnemyShooter shooter;
    public Animator anim;
    public bool intelligent = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        shooter = GetComponent<EnemyShooter>();
        //wanderPoint = RandomWanderPoint();
        //target = PossibleTargets[Random.Range(0, PossibleTargets.Length)];
    }
    private void Update()
    {
        if (isAware)
        {
            isAware = false;
            anim.SetBool("isWalking", true);
            agent.SetDestination(CalculateDestination().position);
            EnemyBehaviour();

        }
        else
        {
            if (intelligent)
            {
                IntelligentSearch();
            }
                
            //Wander();
            else
                SearchForPlayer();
        }
    }

    public virtual void SearchForPlayer ()
    {

        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(player.transform.position)) < fieldOfView / 2f)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < viewDistance)
            {
                transform.LookAt(player.transform.position);
                RaycastHit hit;
                if (Physics.Raycast(transform.position + new Vector3(0, 1.0f, 0f), transform.forward, out hit))
                {
                    Debug.Log(hit.collider.gameObject.tag);
                    if (hit.collider.CompareTag("Player"))
                        OnAware();
                }

            }
            }
    }

    public virtual void IntelligentSearch()
    {
        //intelligent logic
    }

    public void OnAware()
    {
        isAware = true;
    }

    //public void Wander()
    //{
    //    if (Vector3.Distance (transform.position, wanderPoint) < 2f)
    //    {
    //        wanderPoint = RandomWanderPoint();
    //    }
    //    else
    //    {
    //        agent.SetDestination(wanderPoint);
    //    }
    //}

    //public Vector3 RandomWanderPoint()
    //{
    //    Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
    //    NavMeshHit navHit;
    //    NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1);
    //    return new Vector3(navHit.position.x, transform.position.y, navHit.position.z);
    //}

    public virtual Transform CalculateDestination()
    {
        return player.transform;
    }

    public virtual void EnemyBehaviour()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < shootDistance)
        {
            shooter.Fire();
            agent.velocity = Vector3.zero;
            anim.SetBool("isWalking", false);
            anim.SetTrigger("shoot");
        }
    }
}
