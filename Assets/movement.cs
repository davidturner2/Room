using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class movement : MonoBehaviour
{
    public AudioSource death;
    public bool stopdetecting;
    private bool start = false;
    private bool trol = false;
    private bool d;
    private bool u;
    private bool l;
    private bool r;
    private bool ur;
    private bool dr;
    private bool dl;
    private bool ul;
    private bool cantdown;
    private bool cantup;
    private bool cantleft;
    private bool cantright;
    private bool slow = false;
    private bool anotherboolean = true;
    private float um;
    public Vector3 movetothis;
    public GameObject win;
    public GameObject lose;
    private Vector3 prev;

    // Start is called before the first frame update
    void Start()
    {


        movetothis = new Vector3(0f, 0.35f, 0f);
        StartCoroutine("begining");
    }

    // Update is called once per frame
    void Update()
    {

        if (start == true)
        {

            if (transform.position.y > -0.5)
            {

                um = 5.01f * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, movetothis, um);
            }
            if (transform.position == movetothis)
            {
                if (slow)
                {
                    StartCoroutine("asdf");
                }
                else
                {
                    trol = true;
                }
                start = false;
                cantdown = false;
                cantleft = false;
                cantup = false;
                cantright = false;


            }
        }
        if (trol && stopdetecting == false)
        {

            if (Input.GetKeyDown("up") && !cantup)
            {
                if (ul && start)
                {
                    cantleft = true;
                }
                else
                {
                    cantleft = false;
                }
                if (ur && start)
                {
                    cantright = true;
                }
                else
                {
                    cantright = false;
                }
                if (!u)
                {
                    movelol(new Vector3(1f, 0f, 0f));
                    prev = new Vector3(-1f, 0, 0f);
                }
            }
            else if (Input.GetKeyDown("down") && !cantdown)
            {
                if (dl && start)
                {
                    cantleft = true;
                }
                else
                {
                    cantleft = false;
                }
                if (dr && start)
                {
                    cantright = true;
                }
                else
                {
                    cantright = false;
                }
                if (!d)
                {
                    movelol(new Vector3(-1f, 0f, 0f));
                    prev = new Vector3(1f, 0, 0f);
                }
            }
            else if (Input.GetKeyDown("left") && !cantleft)
            {
                if (dl && start)
                {
                    cantdown = true;
                }
                else
                {
                    cantdown = false;
                }
                if (ul && start)
                {
                    cantup = true;
                }
                else
                {
                    cantup = false;
                }
                if (!l)
                {
                    movelol(new Vector3(0f, 0f, 1f));
                    prev = new Vector3(0f, 0, -1f);
                }
            }
            else if (Input.GetKeyDown("right") && !cantright)
            {
                if (dr && start)
                {
                    cantdown = true;
                }
                else
                {
                    cantdown = false;
                }
                if (ur && start)
                {
                    cantup = true;
                }
                else
                {
                    cantup = false;
                }
                if (!r)
                {
                    movelol(new Vector3(0f, 0f, -1f));
                    prev = new Vector3(0f, 0, 1f);
                }
            }
            if (Input.GetKeyDown("space") && !r)
            {
                moveback();
            }


        }
        if (transform.position.y <= -2 && anotherboolean)
        {
            anotherboolean = false;
            lose.SetActive(true);
            StartCoroutine("restart");
        }

    }

    public void movelol(Vector3 a)
    {
        GetComponent<AudioSource>().Play();
        movetothis = movetothis + a;
       start = true;

        if (dr || ur || ul || dl){
                    trol = false;
        StartCoroutine("kar");
        }
    }

    //code based on unity raycast documentation
    void FixedUpdate()
    {
        if (stopdetecting == false){
        Vector3 ra = new Vector3(movetothis.x - 0.3f, movetothis.y + 0.3f, movetothis.z);
        Vector3 ra2 = new Vector3(movetothis.x + 0.3f, movetothis.y + 0.3f, movetothis.z);
        Vector3 ra3 = new Vector3(movetothis.x, movetothis.y + 0.5f, movetothis.z - 0.5f);
        Vector3 ra4 = new Vector3(movetothis.x, movetothis.y + 0.5f, movetothis.z + 0.5f);

        Vector3 ra32 = new Vector3(movetothis.x - 0.5f, movetothis.y + 0.5f, movetothis.z - 1f);
        Vector3 ra332 = new Vector3(movetothis.x - 0.5f, movetothis.y + 0.5f, movetothis.z + 1f);

        Vector3 ra42 = new Vector3(movetothis.x + 0.5f, movetothis.y + 0.5f, movetothis.z - 1f);
        Vector3 ra442 = new Vector3(movetothis.x + 0.5f, movetothis.y + 0.5f, movetothis.z + 1f);

        RaycastHit down;
        RaycastHit up;
        RaycastHit left;
        RaycastHit right;
        RaycastHit upleft;
        RaycastHit upright;
        RaycastHit downleft;
        RaycastHit downright;
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;




        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(ra, transform.TransformDirection(Vector3.forward), out down, 0.7f, layerMask))
        {
            d = true;
            Debug.DrawRay(ra, transform.TransformDirection(Vector3.forward) * down.distance, Color.yellow);
        }
        else
        {
            d = false;
            Debug.DrawRay(ra, transform.TransformDirection(Vector3.forward) * 0.7f, Color.white);
        }


        if (Physics.Raycast(ra32, transform.TransformDirection(Vector3.forward), out downright, 0.7f, layerMask))
        {
            dr = true;
            Debug.DrawRay(ra32, transform.TransformDirection(Vector3.forward) * downright.distance, Color.yellow);
        }
        else
        {
            dr = false;
            Debug.DrawRay(ra32, transform.TransformDirection(Vector3.forward) * 0.7f, Color.red);
        }



        if (Physics.Raycast(ra332, transform.TransformDirection(Vector3.forward), out downleft, 0.7f, layerMask))
        {
            dl = true;
            Debug.DrawRay(ra332, transform.TransformDirection(Vector3.forward) * downleft.distance, Color.yellow);
        }
        else
        {
            dl = false;
            Debug.DrawRay(ra332, transform.TransformDirection(Vector3.forward) * 0.7f, Color.green);
        }




        if (Physics.Raycast(ra42, transform.TransformDirection(Vector3.back), out upright, 0.7f, layerMask))
        {
            ur = true;
            Debug.DrawRay(ra42, transform.TransformDirection(Vector3.back) * upright.distance, Color.yellow);
        }
        else
        {
            ur = false;
            Debug.DrawRay(ra42, transform.TransformDirection(Vector3.back) * 0.7f, Color.magenta);
        }






        if (Physics.Raycast(ra442, transform.TransformDirection(Vector3.back), out upleft, 0.7f, layerMask))
        {
            ul = true;
            Debug.DrawRay(ra442, transform.TransformDirection(Vector3.back) * upleft.distance, Color.yellow);
        }
        else
        {
            ul = false;
            Debug.DrawRay(ra442, transform.TransformDirection(Vector3.back) * 0.7f, Color.cyan);
        }









        if (Physics.Raycast(ra2, transform.TransformDirection(Vector3.back), out up, 0.7f, layerMask))
        {
            u = true;
            Debug.DrawRay(ra2, transform.TransformDirection(Vector3.back) * up.distance, Color.yellow);
        }
        else
        {
            u = false;
            Debug.DrawRay(ra2, transform.TransformDirection(Vector3.back) * 0.7f, Color.white);
        }

        if (Physics.Raycast(ra3, transform.TransformDirection(Vector3.left), out right, 0.7f, layerMask))
        {
            r = true;
            Debug.DrawRay(ra3, transform.TransformDirection(Vector3.left) * right.distance, Color.yellow);
        }
        else
        {
            r = false;
            Debug.DrawRay(ra3, transform.TransformDirection(Vector3.left) * 0.7f, Color.white);
        }

        if (Physics.Raycast(ra4, transform.TransformDirection(Vector3.right), out left, 0.7f, layerMask))
        {
            l = true;
            Debug.DrawRay(ra4, transform.TransformDirection(Vector3.right) * left.distance, Color.yellow);
        }
        else
        {
            l = false;
            Debug.DrawRay(ra4, transform.TransformDirection(Vector3.right) * 0.7f, Color.white);
        }
        }
        else{
            l = false;
            u = false;
            r = false;
            d = false;
            ul = false;
            ur = false;
            dl = false;
            dr = false;
        }
    }


    IEnumerator begining()
    {
        yield return new WaitForSeconds(1);
        start = true;
    }
    IEnumerator kar()
    {
        yield return new WaitForSeconds(0.1f);
        trol = true;

    }
    IEnumerator restart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }

    IEnumerator asdf()
    {
        yield return new WaitForSeconds(1f);
        trol = true;
        slow = false;

    }
    public void moveback()
    {
        slow = true;
        trol = false;
        movelol(prev);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "win")
        {
            death.Play();
            win.SetActive(true);
            Destroy(gameObject);

        }

    }

}

