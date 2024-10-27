using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointout : MonoBehaviour
{
    public Vector3 movetothis;
    float steppers;
    bool yuh = false;
    public bool diedied= false;
    // Start is called before the first frame update
    void Start()
    {
         movetothis = transform.position;
               //new Vector3(0f, 0.35f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        if(yuh){
        steppers += 700*Time.deltaTime/9.009f;
         movetothis = transform.position;
                Vector3 ra = new Vector3(movetothis.x - 0.3f, movetothis.y + 0.3f, movetothis.z);
        RaycastHit down;

        if (Physics.Raycast(ra, transform.TransformDirection(Vector3.forward), out down, steppers)&&!diedied)
        {
            Debug.DrawRay(ra, transform.TransformDirection(Vector3.forward) * down.distance, Color.yellow);
            down.collider.gameObject.GetComponent<pointout>().enabled=true;
            Destroy(gameObject);
        }
        else
        {
            if(!diedied){
            Debug.DrawRay(ra, transform.TransformDirection(Vector3.forward) * steppers, Color.white);
            }
        }
        if(diedied){
            Destroy(gameObject);
        }
        }
        if(Input.GetMouseButtonDown(0)){
             GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            yuh = true;
        }
    }
}
