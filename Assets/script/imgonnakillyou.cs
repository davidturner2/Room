using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imgonnakillyou : MonoBehaviour
{
    bool stopgoing;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,20);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
            Vector3 target = GameObject.FindWithTag("Target").transform.position;

            if (Vector3.Distance(transform.position, target) > 2 && stopgoing == false)
            {
                gameObject.GetComponent<Rigidbody>().velocity = (target - transform.position).normalized * 3;
            }
        else
        {
            stopgoing = true;
        }
       


    }
}
