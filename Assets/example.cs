using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class example : MonoBehaviour
{
    Rigidbody r;
    float boost = 1f;
    Vector3 direction;
    bool left= false;
    public GameObject b;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        b.GetComponent<ParticleSystem>().Stop();
direction =Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        r.AddForce(direction * 20 * boost);

        if (Input.GetKey("up"))
        {
            direction = Vector3.back;
        }
         if (Input.GetKey("left"))
        {
            if(!left){
         float z=   r.velocity.z;
         r.velocity = new Vector3(0,0,z);
         left = true;
            }
            direction = Vector3.right;
        }
           if (Input.GetKey("right"))
        {
            if(left){
            
            float z=   r.velocity.z;
         r.velocity = new Vector3(0,0,z);
         left = false;
            }
            direction = Vector3.left;
        }
        if (Input.GetKey("down"))
        {
            r.velocity = r.velocity/1.202f; //(direction * 20 * boost);

            direction = Vector3.zero; //(transform.position-Vector3.back*100);
        }
        if (Input.GetKey("space"))
        {
                        b.SetActive(true);

            /*if( b.GetComponent<ParticleSystem>().isPlaying==false){
            b.GetComponent<ParticleSystem>().Play();
            }*/
            if (direction == Vector3.zero)
            {
                direction = Vector3.back;

            }
            boost = 10f;
        }
        else 
        {
            b.SetActive(false);
            boost = 1f;
        }
    }
}
