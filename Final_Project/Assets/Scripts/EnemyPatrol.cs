using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyPatrol : MonoBehaviour
{
    TriggerPatrol triggerPatrol;
    Rigidbody m_Rigidbody;  

    [HideInInspector]
    public GameObject target;
    public bool showDebug;
    public static bool isStunnedToggle = false;
    private float stunTime = 4f;

    [Header ("Nav Mesh Stuff")]
    NavMeshAgent myAgent;
    public Transform[] points;
    private int destPoint = 0;
    public float speed = 8f;

    [Header ("Ranges")]
    public float agroRadius;
    public float attakDistance;
    public float attackCoolDown;
    float startTimer;
    bool attacking = false;

    //
    private void OnEnable()
    {
        triggerPatrol = GetComponentInChildren<TriggerPatrol>();
        triggerPatrol.agroRad = agroRadius;
    }

    // Start is called before the first frame update
    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.speed = speed;
        myAgent.autoBraking = false;
        for (int i = 0; i < points.Length; i++)
        {
            points[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }

    //
    private void OnDrawGizmos()
    {
        if (showDebug)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attakDistance);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, agroRadius);
            Gizmos.color = Color.blue;
            for(int i = 0; i < points.Length; i++)
            {
                Gizmos.DrawWireSphere(points[i].position, 0.5f);
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        

        if (attacking == true)
        {
            startTimer += Time.deltaTime;
            if(startTimer >= attackCoolDown)
            {
                startTimer = 0f;
                Attack();
            }
        }
        if (target != null)
        {
            ChkDist();
        }
        if(!myAgent.pathPending && myAgent.remainingDistance <= 0.5f)
        {
            NextPoint();
        }
        

        if (isStunnedToggle == true)
        {
            stunTime -= Time.deltaTime;
            if (stunTime < 0)
            {
                isStunnedToggle = false;
                print("isStunnedToggle = false");
            }
        }

        OnOffNavMeshAgent();
    }//end a update

    //
    private void OnOffNavMeshAgent()
    {
        if (isStunnedToggle == true)
        {
            //myAgent.Stop();
            //transform.GetComponent<NavMeshAgent>().Stop();
            //gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            print("isStunnedToggle = false");
        }
        else if (isStunnedToggle == false)
        {
            //myAgent.Resume();
            //transform.GetComponent<NavMeshAgent>().Resume();
            //gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            print("isStunnedToggle = true");
        }
    }

    //
    private void NextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        myAgent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }//end a nextpoint

    //
    private void ChkDist()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);

        if (dist <= attakDistance)
        {
            attacking = true;
            myAgent.isStopped = true;
        }
        else
        {
            myAgent.isStopped = false;
            myAgent.destination = target.transform.position;
            attacking = false;
        }
    }

    //
    private void Attack()
    {
        print("attacking the player");

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    //
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Bullet")
        {
            print("ENEMY HIT");
            Destroy(collision.gameObject);
        }
    }
}
