using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class movement : MonoBehaviour
{
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
    private bool godown;
    private bool goup;
    private bool anotherboolean = true;
    private float um;
    private Vector3 movetothis;
    public GameObject win;
    public GameObject lose;
    private Vector3 prev;
    // Start is called before the first frame update
    void Start()
    {


        movetothis = new Vector3(0f, 0.035f, 0f);
        StartCoroutine("begining");
    }

    // Update is called once per frame
    void Update()
    {
        print(goup);
        if (start == true)
        {
            if (godown && (trol = false))
            {
                print("Asdfgpork");
                if (Input.GetKeyDown("down"))
                {
                   
                        movelol(new Vector3(-1f, 0f, 0f));
                        prev = new Vector3(1f, 0, 0f);
                    
                    godown = false;
                }
              
            }
            if (goup)
            {
                print("Asdfgpork");

                if (Input.GetKeyDown("up"))
                {
                    print("asdfg");
                   movelol(new Vector3(1f, 0f, 0f));
                     prev = new Vector3(-1f, 0, 0f);
                    goup = false;

                }
            }

            if (transform.position.y > -0.5)
            {
                um = 5.01f * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, movetothis, um);
            }
            if (transform.position == movetothis)
            {
                start = false;
                trol = true;
                goup = false;
                godown = false;

            }
        }
        if (trol)
        {

            if (Input.GetKeyDown("up"))
            {
                if (ul || ur)
                {
                    trol = false;
                }
                if (!u)
                {
                    movelol(new Vector3(1f, 0f, 0f));
                    prev = new Vector3(-1f, 0, 0f);
                }
            }
            else if (Input.GetKeyDown("down"))
            {
                if (dl || dr)
                {
                    trol = false;
                }
                if (!d)
                {
                    movelol(new Vector3(-1f, 0f, 0f));
                    prev = new Vector3(1f, 0, 0f);
                }
            }
            else if (Input.GetKeyDown("left"))
            {
                if (dl)
                {
                    goup = true;
                    trol = false;
                }
                if (ul)
                {
                    godown = true;
                    trol = false;
                }
                if (!l)
                {
                    movelol(new Vector3(0f, 0f, 1f));
                    prev = new Vector3(0f, 0, -1f);
                }
            }
            else if (Input.GetKeyDown("right"))
            {
                if (dr || ur)
                {
                    trol = false;
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

    private void movelol(Vector3 a)
    {
        movetothis = movetothis + a;
        start = true;
        //trol = false;
    }


    void FixedUpdate()
    {

        Vector3 ra = new Vector3(movetothis.x - 0.5f, movetothis.y + 0.5f, movetothis.z);
        Vector3 ra2 = new Vector3(movetothis.x + 0.5f, movetothis.y + 0.5f, movetothis.z);
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




        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(ra, transform.TransformDirection(Vector3.forward), out down, 0.5f))
        {
            d = true;
            Debug.DrawRay(ra, transform.TransformDirection(Vector3.forward) * down.distance, Color.yellow);
        }
        else
        {
            d = false;
            Debug.DrawRay(ra, transform.TransformDirection(Vector3.forward) * 0.5f, Color.white);
        }


        if (Physics.Raycast(ra32, transform.TransformDirection(Vector3.forward), out downright, 0.5f))
        {
            dr = true;
            Debug.DrawRay(ra32, transform.TransformDirection(Vector3.forward) * downright.distance, Color.yellow);
        }
        else
        {
            dr = false;
            Debug.DrawRay(ra32, transform.TransformDirection(Vector3.forward) * 0.5f, Color.red);
        }



        if (Physics.Raycast(ra332, transform.TransformDirection(Vector3.forward), out downleft, 0.5f))
        {
            dl = true;
            Debug.DrawRay(ra332, transform.TransformDirection(Vector3.forward) * downleft.distance, Color.yellow);
        }
        else
        {
            dl = false;
            Debug.DrawRay(ra332, transform.TransformDirection(Vector3.forward) * 0.5f, Color.green);
        }




        if (Physics.Raycast(ra42, transform.TransformDirection(Vector3.back), out upright, 0.5f))
        {
            ur = true;
            Debug.DrawRay(ra42, transform.TransformDirection(Vector3.back) * upright.distance, Color.yellow);
        }
        else
        {
            ur = false;
            Debug.DrawRay(ra42, transform.TransformDirection(Vector3.back) * 0.5f, Color.magenta);
        }






        if (Physics.Raycast(ra442, transform.TransformDirection(Vector3.back), out upleft, 0.5f))
        {
            ul = true;
            Debug.DrawRay(ra442, transform.TransformDirection(Vector3.back) * upleft.distance, Color.yellow);
        }
        else
        {
            ul = false;
            Debug.DrawRay(ra442, transform.TransformDirection(Vector3.back) * 0.5f, Color.cyan);
        }









        if (Physics.Raycast(ra2, transform.TransformDirection(Vector3.back), out up, 0.5f))
        {
            u = true;
            Debug.DrawRay(ra2, transform.TransformDirection(Vector3.back) * up.distance, Color.yellow);
        }
        else
        {
            u = false;
            Debug.DrawRay(ra2, transform.TransformDirection(Vector3.back) * 0.5f, Color.white);
        }

        if (Physics.Raycast(ra3, transform.TransformDirection(Vector3.left), out right, 0.5f))
        {
            r = true;
            Debug.DrawRay(ra3, transform.TransformDirection(Vector3.left) * right.distance, Color.yellow);
        }
        else
        {
            r = false;
            Debug.DrawRay(ra3, transform.TransformDirection(Vector3.left) * 0.5f, Color.white);
        }

        if (Physics.Raycast(ra4, transform.TransformDirection(Vector3.right), out left, 0.5f))
        {
            l = true;
            Debug.DrawRay(ra4, transform.TransformDirection(Vector3.right) * left.distance, Color.yellow);
        }
        else
        {
            l = false;
            Debug.DrawRay(ra4, transform.TransformDirection(Vector3.right) * 0.5f, Color.white);
        }
    }


    IEnumerator begining()
    {
        yield return new WaitForSeconds(1);
        start = true;
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(0);
    }
    public void moveback()
    {
        movelol(prev);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "win")
        {
            win.SetActive(true);
            Destroy(gameObject);

        }

    }
}
