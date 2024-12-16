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
        //set goal to the transform position
        goal = transform.position;
        // get the navmesh ageny
        agent = GetComponent<NavMeshAgent>();
        n = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ( agent.remainingDistance <= 0 && aaa && n){
         
        }
        //print(agent.remainingDistance);
        //if aaa is true then start moving to the goal
        if (aaa){
        agent.destination = goal;
        }
    }
}
