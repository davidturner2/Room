using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class medication : MonoBehaviour
{
    public blastoff a;
    public bool evil = false;
    public GameObject evilspawn;
    public GameObject medcap;
    private bool spawning = false;
    // Start is called before the first frame update
    void Start()
    {
        // stop animtaion
        medcap.GetComponentInChildren<Animator>().Play("none");
    }

    //when you enter the trigger zone
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
            // enable the script for blasting off
            a.enabled = true;
            //play the aniation
            medcap.GetComponentInChildren<Animator>().Play("open");
            if(evil){
                // if this is an evil medication start spawning enemies
                spawning = true;
                StartCoroutine("endlessenemies");
            }else{
                // move back to previous spot for seeing animation on regulare medication
                other.GetComponent<movement>().moveback();
                //destroy collider
                 Destroy(GetComponent<BoxCollider>());

            }
        }
    }

    // disable spawning on exit
    private void OnTriggerExit(Collider other){
        if(other.tag == "Player" && evil){
            spawning = false;
        }
    }
    //start spawning enemies every 5 seconds
    IEnumerator endlessenemies(){
        Instantiate(evilspawn,transform.GetChild(0).transform.position,evilspawn.transform.rotation);
        yield return new WaitForSeconds(5);
        if (spawning){
        StartCoroutine("endlessenemies");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
