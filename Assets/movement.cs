using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    private bool start = false;
    private bool trol = false;
    private float um;

    public GameObject win;
    public GameObject lose;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("begining");
    }

    // Update is called once per frame
    void Update()
    {
        if (start==true){
            um+=0.01f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(0f,0.035f,0f),um);
            if (transform.position == new Vector3(0f,0.035f,0f)){
                start = false;
                trol = true;
            }      
        }
        if (trol){
            if (Input.GetKeyDown("up")) {
            transform.position += new Vector3(1f,0f,0f);
            }
              if (Input.GetKeyDown("down")) {
            transform.position += new Vector3(-1f,0f,0f);
            }
              if (Input.GetKeyDown("left")) {
            transform.position += new Vector3(0f,0f,1f);
            }
              if (Input.GetKeyDown("right")) {
            transform.position += new Vector3(0f,0f,-1f);
            }
       
        
        }
        if (transform.position.y <= -2){
            lose.SetActive(true);
        }
           
    }
    IEnumerator begining(){
        yield return new WaitForSeconds(1);
       start = true;
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "win"){
            win.SetActive(true);
            Destroy(gameObject);

        }

    }
}
