using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawncameras : MonoBehaviour
{
    public GameObject cameras;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<5; i++){
           Instantiate(cameras,new Vector3(transform.position.x+i*5,1,0),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
