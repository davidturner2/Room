using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detecter : MonoBehaviour
{
    public imgonnakillyoutoo o;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // detect if in collider or outside of collider for the imgonnakillyou to set startpooping to true.
       void OnTriggerEnter(Collider other){
    if (other.tag=="Player"){
        o.startpooping = true;
    }
   }

   void OnTriggerExit(Collider other){
    if (other.tag=="Player"){
        o.startpooping = false;
    }
   }
}
