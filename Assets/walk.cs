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
    bool curve = false;
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
        Vector3 ad2 = new Vector3(0, Camera.main.transform.rotation.eulerAngles.y+90 * mover.x, 0);;
        if (mover.y>=0){
            ad2 = new Vector3(0, Camera.main.transform.rotation.eulerAngles.y+90 * mover.x, 0);
        }else{
            ad2 = new Vector3(0, Camera.main.transform.rotation.eulerAngles.y+180 * mover.y, 0);

        }
       // print(mover.y);
      
            if (curve){
                r.velocity =child.transform.rotation * ad * speed;
            // Camera.main.transform.parent = child.transform;
            }else{
                child.transform.rotation = Quaternion.RotateTowards(child.transform.rotation, Quaternion.Euler(ad2), accel * Time.deltaTime);

                // Camera.main.transform.parent = gameObject.transform;
                r.velocity =Camera.main.transform.rotation * ad * speed;

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
                RaycastHit down;
            Vector3 movetothis = child.transform.position+ child.transform.rotation*new Vector3(0,1,0);
            //Vector3 ra = new Vector3(movetothis.x - 0.3f, movetothis.y + 0.3f, movetothis.z);
       if (Physics.Raycast(movetothis, child.transform.rotation*(Vector3.down), out down, 2f))
        {
            if(down.collider.tag == "curve"){
                //curve = true;
            }else{
               // curve = false;
            }
            print(down.collider.gameObject.name);
            Debug.DrawRay(movetothis, child.transform.rotation*(Vector3.down) * down.distance, Color.yellow);
            child.transform.rotation = Quaternion.RotateTowards(child.transform.rotation,Quaternion.FromToRotation(child.transform.up,down.normal)*child.transform.rotation,60.01f * Time.deltaTime);
            Camera.main.transform.rotation = child.transform.rotation;

        }
        else
        {
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
