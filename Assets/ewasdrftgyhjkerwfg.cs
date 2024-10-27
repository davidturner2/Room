using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ewasdrftgyhjkerwfg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray asadsfdg = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit lskdljf = new RaycastHit();
        if(Physics.Raycast(asadsfdg, out lskdljf)){
            if (Input.GetMouseButtonDown(0)){
                Destroy(lskdljf.collider.gameObject);
            }
        }
    }
}
