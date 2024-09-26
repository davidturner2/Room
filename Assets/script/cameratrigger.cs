using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cameratrigger : MonoBehaviour
{
    public bool sideways;
    public bool forward;
    private cameramove Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindWithTag("MainCamera").GetComponent<cameramove>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (sideways == false)
            {

                //print(Mathf.Ceil(other.transform.position.x));
                if (forward)
                {
                    Camera.lvl = Mathf.CeilToInt(other.transform.position.x) / 5;
                }
                else
                {
                    Camera.lvl = (Mathf.CeilToInt(other.transform.position.x) + 1) / 5 - 1;
                }
            }
            else
            {
                if (forward)
                {
                    Camera.hlvl = Mathf.FloorToInt(other.transform.position.z) / 8;
                }
                else
                {
                    Camera.hlvl = (Mathf.FloorToInt(other.transform.position.z) + 1) / 8;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
