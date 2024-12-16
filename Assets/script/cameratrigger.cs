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
    private cameramove Camera2;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindWithTag("MainCamera").GetComponent<cameramove>();
        Camera2 = GameObject.FindWithTag("asdf").GetComponent<cameramove>();

    }
    private void OnTriggerEnter(Collider other)
    {
        // get estimate of player position to move the cameras in whole numbers in the vertical or horizontal directions

        if (other.tag == "Player")
        {
            if (sideways == false)
            {

                if (forward)
                {
                    Camera.lvl = Mathf.CeilToInt(other.transform.position.x) / 5;
                    Camera2.lvl = Mathf.CeilToInt(other.transform.position.x) / 5;

                }
                else
                {

                    Camera.lvl = (Mathf.CeilToInt(other.transform.position.x) + 1) / 5 - 1;
                    Camera2.lvl = (Mathf.CeilToInt(other.transform.position.x) + 1) / 5 - 1;

                }

            }
            else
            {
                if (forward)
                {
                    Camera.hlvl = Mathf.FloorToInt(other.transform.position.z) / 8;
                    Camera2.hlvl = Mathf.FloorToInt(other.transform.position.z) / 8;

                }
                else
                {
                    Camera.hlvl = (Mathf.FloorToInt(other.transform.position.z) + 1) / 8;
                    Camera2.hlvl = (Mathf.FloorToInt(other.transform.position.z) + 1) / 8;

                }
            }
        }
    }
  
  
}
