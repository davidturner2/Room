using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    Rigidbody r;
    bool isGrounded;
    Animator a;
    public GameObject child;
    float speed = 10;
    private Racer trolls;
    private Vector2 mover;
    float accel = 200f;
    public bool movewithit;
    public void Awake()
    {
        trolls = new Racer();

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
        a = child.GetComponent<Animator>();
    }
    void OnCollisionStay()
    {
        isGrounded = true;
        a.SetBool("Jump", false);
        a.SetBool("Jump2", false);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 ad = new Vector3(mover.x, 0, mover.y);
        Vector3 ad2 = new Vector3(0, Camera.main.transform.rotation.eulerAngles.y+90 * mover.x, 0);
        print(mover.y);
        if (!movewithit)
        {
            child.transform.rotation = Quaternion.RotateTowards(child.transform.rotation, Quaternion.Euler(ad2), accel * Time.deltaTime);
            r.velocity = Camera.main.transform.rotation * ad * speed;
        }
        else
        {
            child.transform.rotation = Quaternion.RotateTowards(child.transform.rotation, Quaternion.Euler(child.transform.rotation * ad2), accel * Time.deltaTime);

            r.velocity = child.transform.rotation* ad * speed;

        }
        speed += 0.2f;
        if (speed >= 12)
        {
            speed = 12;

        }
        if (mover == Vector2.zero)
        {
            speed = 0;
            accel = 0;
            a.SetBool("walkin", false);
        }
        else
        {
            accel = 200;

            a.SetBool("walkin", true);
        }
        /*
        if (Input.GetKey("w"))
        {
            a.SetBool("walkin", true);
            //r.AddForce(direction * 20 * boost);
         
            r.velocity = child.transform.rotation * (Vector3.forward * speed);
            if (Input.GetKey("a"))// && !Input.GetKey("w")&& !Input.GetKey("s"))
            {
                a.SetBool("walkin", true);

                child.transform.Rotate(new Vector3(0, -4, 0));

                //r.velocity  =Quaternion.Inverse(transform.rotation) *  Vector3.right*20*boost;

            }
            else if (Input.GetKey("d"))//&& !Input.GetKey("w")&& !Input.GetKey("s"))
            {
                a.SetBool("walkin", true);

                child.transform.Rotate(new Vector3(0, 4, 0));

                // r.velocity  =Quaternion.Inverse(transform.rotation) *  Vector3.left*20*boost;

            }

        }
        else if (Input.GetKey("a"))// && !Input.GetKey("w")&& !Input.GetKey("s"))
        {
            a.SetBool("walkin", true);
            r.velocity = child.transform.rotation * (Vector3.forward * speed);

            // child.transform.Rotate(new Vector3(0,-1,0));

            //r.velocity  =Quaternion.Inverse(transform.rotation) *  Vector3.right*20*boost;

        }
        else if (Input.GetKey("d"))//&& !Input.GetKey("w")&& !Input.GetKey("s"))
        {
            a.SetBool("walkin", true);

            child.transform.Rotate(new Vector3(0, 4, 0));
            r.velocity = child.transform.rotation * (Vector3.forward * speed);

            // r.velocity  =Quaternion.Inverse(transform.rotation) *  Vector3.left*20*boost;

        }

        else if (Input.GetKey("s"))
        {
            a.SetBool("walkin", true);


            r.velocity = child.transform.rotation * (Vector3.back * 8);

        }
        else
        {
            a.SetBool("walkin", false);
            speed = 0;

        }
        */

    }
    void Jump()
    {
        if (isGrounded)
        {
            Debug.Log("ASDFGGJSDKF");
            if (speed < 12)
            {
                a.SetBool("Jump", true);
            }
            else
            {
                a.SetBool("Jump2", true);

            }
            isGrounded = false;

            r.AddForce(Vector2.up * 50, ForceMode.Impulse);
        }
    }
    void Update()
    {
        
    }
}
