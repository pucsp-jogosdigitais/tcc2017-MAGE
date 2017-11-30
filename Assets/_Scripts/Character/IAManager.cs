using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAManager : MonoBehaviour
{

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    public Vector3 destination;
    public float moveSpeed = 8.0f;
    Vector3 gravity;
    public float gravityPower;

    bool onRadius;

    void Start()
    {
        target = Singleton.instance.player.transform;
        gravity = new Vector3(0, -gravityPower, 0);
    }


    void Update()
    {

        transform.LookAt(target);

        //Move towards the target
        if (Vector3.Distance(transform.position, target.position) > 3)
        {
            //destination = ((Vector3.forward * moveSpeed * Time.deltaTime) + Vector3.down);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

    }

}
