using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conen : MonoBehaviour
{
public bool connected = false;


private void OnTriggerEnter(Collider other){
    if (other.tag == "Player"){
    if (GetComponentInParent<whattheheck>().followLoop == false){
    connected = true;
    GetComponentInParent<whattheheck>().asdf(other);
    }
    }
}

private void OnTriggerExit(Collider other){
    connected = false;
}
}
