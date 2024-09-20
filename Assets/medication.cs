using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class medication : MonoBehaviour
{
    public blastoff a;
    public GameObject medcap;
    // Start is called before the first frame update
    void Start()
    {
        medcap.GetComponentInChildren<Animator>().Play("none");
    }
    private void OnTriggerEnter(Collider other){
        other.GetComponent<movement>().moveback();
        a.enabled = true;
        medcap.GetComponentInChildren<Animator>().Play("open");
        Destroy(GetComponent<BoxCollider>());
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
