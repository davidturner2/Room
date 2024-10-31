using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rapper : MonoBehaviour
{
    public bool rappeer = false;
    // Start is called before the first frame update
    void Start()
    {
        if (rappeer){
GetComponent<Animator>().SetBool("walkin",true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
