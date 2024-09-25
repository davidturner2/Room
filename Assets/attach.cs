using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attach : MonoBehaviour
{
    Quaternion l;
    public bool connected = false;
    // Start is called before the first frame update


   private void OnTriggerEnter (Collider other){
    connected = true;
            l = other.transform.rotation;
            other.transform.SetParent(gameObject.transform);
            //other.transform.rotation = gameObject.transform.rotation;
            //other.gameObject.GetComponent<movement>().stopdetecting = true;

   }

   //once object is on here then disable all movement and move to the objects vector 3 rotate towards?

      private void OnTriggerExit (Collider other){
        connected = false;
            other.transform.SetParent(GameObject.FindWithTag("Respawn").gameObject.transform);
           // other.gameObject.GetComponent<movement>().stopdetecting = false;
           // other.transform.rotation = l;


   }
}
