using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirate : MonoBehaviour
{
    bool wiiii = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButton(0) || Input.GetMouseButton(1) &&!wiiii)
        {
wiiii = true;
        Destroy(gameObject,2f);
        }
    }
 
}
