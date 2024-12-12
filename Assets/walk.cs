using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class walk : MonoBehaviour
{
    Rigidbody r;
    bool isGrounded;
    Animator a;
    public GameObject child;
    float speed = 10;
    private Racer trolls;
    private Vector2 mover;
    float accel = 400f;
    bool curve = false;
    bool um = false;
    Quaternion HELPMEEEE;
    public void Awake()
    {
        trolls = new Racer();
    // input system
        trolls.PCtrolls.move.performed += ctx => mover = ctx.ReadValue<Vector2>();
        trolls.PCtrolls.move.canceled += ctx => mover = Vector2.zero;
        trolls.PCtrolls.jump.performed += ctx => Jump();
     


    }
    private void OnEnable()
    {
        trolls.PCtrolls.Enable();
    }
    private void OnDisable()
    {
        trolls.PCtrolls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        //a = child.GetComponent<Animator>();
    }
    void OnCollisionStay()
    {
        isGrounded = true;
        //a.SetBool("Jump", false);
        //a.SetBool("Jump2", false);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // movement vecot for position
        Vector3 ad = new Vector3(mover.x, 0, mover.y);
        // movement vector based on the curve
            Vector3 ad3 = new Vector3(HELPMEEEE.eulerAngles.x, 0, HELPMEEEE.eulerAngles.z);


      //  print(distance(child.transform.rotation.eulerAngles.x, 0) <= 15f);
       // print(distance(child.transform.rotation.eulerAngles.x, 0)+" distance");

        // print(mover.y);
        // approximate to set the rotation straight or based on curve so you dont rotate in the wrong direction
        if (ad != Vector3.zero){
            if (distance(child.transform.rotation.eulerAngles.x, 0) <= 10 && distance(child.transform.rotation.eulerAngles.z, 0) <= 10)
            {
                child.transform.rotation = Quaternion.RotateTowards(child.transform.rotation, Quaternion.Euler(ad3), 150.01f * Time.deltaTime);
            }
            else
            {
                child.transform.rotation = HELPMEEEE;//Quaternion.RotateTowards(child.transform.rotation, Quaternion.Euler(ad3), accel * Time.deltaTime);
            }
            // set velocity to the rotation times the movment vector times the speed 
            r.velocity = (child.transform.rotation*ad * speed*2.4f);
                                //child.transform.rotation = Quaternion.RotateTowards(child.transform.rotation, Quaternion.Euler(ad3), accel * Time.deltaTime);
           
            
      }
      // acceleration
        speed += 0.2f;
        //max speed
        if (speed >= 12)
        {
            speed = 12;

        }
        // reset speed
        if (mover == Vector2.zero)
        {
            speed = 0;
            accel = 0;
            //a.SetBool("walkin", false);
        }
        else
        {
            accel = 200;

            //a.SetBool("walkin", true);
        }
        //start raycast
                RaycastHit down;
            Vector3 movetothis = child.transform.position+ child.transform.rotation*new Vector3(0,1,0);
            //Vector3 ra = new Vector3(movetothis.x - 0.3f, movetothis.y + 0.3f, movetothis.z);
       if (Physics.Raycast(movetothis, child.transform.rotation*(Vector3.down), out down, 2f))
        {
            if(down.collider.tag == "curve"){
                curve = true;
            }else{
                curve = false;
            }
            // set the rotation to rotate towards the from to rotation of the normals based on the transform of the player mulitplied by the current player rotation
            Debug.DrawRay(movetothis, child.transform.rotation*(Vector3.down) * down.distance, Color.yellow);
            HELPMEEEE = Quaternion.RotateTowards(child.transform.rotation,Quaternion.FromToRotation(child.transform.up,down.normal)*child.transform.rotation,150.01f * Time.deltaTime);

        }
        else
        {
            HELPMEEEE = Quaternion.RotateTowards(child.transform.rotation,quaternion.identity, 150.01f * Time.deltaTime);


            curve = false;
            Debug.DrawRay(movetothis, child.transform.rotation*(Vector3.down) * 1f, Color.red);
        }

    }
    void Jump()
    {
        if (isGrounded)
        {
            Debug.Log("ASDFGGJSDKF");
            if (speed < 12)
            {
               // a.SetBool("Jump", true);
            }
            else
            {
                //a.SetBool("Jump2", true);

            }
            isGrounded = false;

            r.AddForce(Vector2.up * 50, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            other.gameObject.GetComponent<dialoge>().asdf();
        }
        if(other.gameObject.tag == "Finish")
        {
           
                SceneManager.LoadScene(1);

                }
    }
            void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "person"){
            AudioSource []sd = gameObject.GetComponentsInChildren<AudioSource>();
            for(int i = 0; i<sd.Length;i++){
                if(!sd[i].isPlaying){
                sd[i].Play();
                }
            }
            other.gameObject.GetComponent<Rigidbody>().AddForce(40*transform.forward,ForceMode.Impulse);
        }
    }
    
    float distance(float xi,float xf)
    {
        if (xi > 180)
        {
            return 360-Mathf.Abs(xf - xi);

        }
        else
        {
            return Mathf.Abs(xf - xi);

        }
    }
}
