using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Vector3 goal;
    NavMeshAgent agent;
    public bool aaa = true;
    public bool n = true;

    // Start is called before the first frame update
    void Awake()
    {
        goal = transform.position;
        agent = GetComponent<NavMeshAgent>();
        n = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ( agent.remainingDistance <= 0 && aaa && n){
         
        }
        //print(agent.remainingDistance);
        if (aaa){
        agent.destination = goal;
        }
    }
}
