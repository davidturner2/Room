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
    private bool anotherboolean = true;
    private float um;
    private Vector3 movetothis;

    public GameObject win;
    public GameObject lose;

    // Start is called before the first frame update
    void Start()
    {

  

        movetothis = new Vector3(0f,0.035f,0f);
        StartCoroutine("begining");
    }

    // Update is called once per frame
    void Update()
    {
        if (start==true){
            if (transform.position.y>-0.5){
            um = 5.01f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,movetothis,um);
            }
            if (transform.position == movetothis){
                start = false;
                trol = true;
            }      
        }
        if (trol && anotherboolean){



            if (Input.GetKeyDown("up")) {
            movelol(new Vector3(1f,0f,0f));

            }
              if (Input.GetKeyDown("down")) {
            movelol(new Vector3(-1f,0f,0f));

            }
              if (Input.GetKeyDown("left")) {
            movelol(new Vector3(0f,0f,1f));

            }
              if (Input.GetKeyDown("right")) {
            movelol(new Vector3(0f,0f,-1f));
            }
       
          if (transform.position.y <= -2){
            anotherboolean = false;
            lose.SetActive(true);
            StartCoroutine("restart");
        }
        }
      
           
    }
    private void movelol(Vector3 a){
    movetothis = movetothis + a;
            start = true;
            //trol = false;
    }

    IEnumerator begining(){
        yield return new WaitForSeconds(1);
       start = true;
    }


     IEnumerator restart(){
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(0);
}

    private void OnTriggerEnter(Collider other){
        if(other.tag == "win"){
            win.SetActive(true);
            Destroy(gameObject);

        }

    }
}
