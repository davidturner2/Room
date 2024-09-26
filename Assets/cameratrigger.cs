using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cameratrigger : MonoBehaviour
{
    public bool forward;
    private cameramove Camera;
    // Start is called before the first frame update
    void Start()
    {
    Camera = GameObject.FindWithTag("MainCamera").GetComponent<cameramove>();

    }
    private void OnTriggerEnter (Collider other){
        if (other.tag == "Player")
        {

            print(Mathf.Ceil(other.transform.position.x));
            if (forward)
            {
                Camera.lvl = Mathf.CeilToInt(other.transform.position.x) / 5;
            }
            else
            {
                Camera.lvl = (Mathf.CeilToInt(other.transform.position.x) + 1) / 5 - 1;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
