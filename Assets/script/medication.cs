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
        medcap.GetComponentInChildren<Animator>().Play("none");
    }
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
            a.enabled = true;
            medcap.GetComponentInChildren<Animator>().Play("open");
            if(evil){
                spawning = true;
                StartCoroutine("endlessenemies");
            }else{
                other.GetComponent<movement>().moveback();

                 Destroy(GetComponent<BoxCollider>());

            }
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.tag == "Player" && evil){
            spawning = false;
        }
    }
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
