using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPatrol : MonoBehaviour
{
    EnemyPatrol enemyPatrol;

    SphereCollider triggerCollider;
    public float agroRad;
    public static bool isStunned;

    private void Start()
    {
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        triggerCollider = GetComponent<SphereCollider>();
        triggerCollider.radius = agroRad;
        triggerCollider.isTrigger = true;
    }

    private void Update()
    {
        isStunned = EnemyPatrol.isStunnedToggle;
    }

    private void OnTriggerEnter(Collider coll)
    {
        print("isStunned = " + isStunned);
        if (coll.gameObject.tag == "Player" && isStunned != true)
        {
            print("player has entered the danger zone");
            enemyPatrol.target = coll.gameObject;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            print("player has exited the danger zone");
            enemyPatrol.target = null;
        }
    }
}
