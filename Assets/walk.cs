using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    Rigidbody r;
        Animator a;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        a = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         if (Input.GetKey("w"))
        {
            a.SetBool("walkin",true);
                    //r.AddForce(direction * 20 * boost);
            speed += 0.2f;
            if(speed>=12){
                speed = 12;

            }
            r.velocity =transform.rotation * (Vector3.forward*speed);
if (Input.GetKey("a"))// && !Input.GetKey("w")&& !Input.GetKey("s"))
        {
                        a.SetBool("walkin",true);

            transform.Rotate(new Vector3(0,-4,0));
     
            //r.velocity  =Quaternion.Inverse(transform.rotation) *  Vector3.right*20*boost;
          
        }
         else  if (Input.GetKey("d"))//&& !Input.GetKey("w")&& !Input.GetKey("s"))
        {
                        a.SetBool("walkin",true);

                        transform.Rotate(new Vector3(0,4,0));

           // r.velocity  =Quaternion.Inverse(transform.rotation) *  Vector3.left*20*boost;
        
        }
    
        }
        else if (Input.GetKey("a"))// && !Input.GetKey("w")&& !Input.GetKey("s"))
        {
                        a.SetBool("walkin",true);

            transform.Rotate(new Vector3(0,-4,0));
     
            //r.velocity  =Quaternion.Inverse(transform.rotation) *  Vector3.right*20*boost;
          
        }
         else  if (Input.GetKey("d"))//&& !Input.GetKey("w")&& !Input.GetKey("s"))
        {
                        a.SetBool("walkin",true);

                        transform.Rotate(new Vector3(0,4,0));

           // r.velocity  =Quaternion.Inverse(transform.rotation) *  Vector3.left*20*boost;
        
        }

       else if (Input.GetKey("s"))
        {
                        a.SetBool("walkin",true);

            
                       r.velocity =transform.rotation * (Vector3.back*8);

         }
         else{
                        a.SetBool("walkin",false);
                        speed = 0;
            
         }
        if (Input.GetKeyDown("space")){
            a.SetTrigger("Jump");
            r.AddForce(Vector2.up*9);
        }

    }
}
