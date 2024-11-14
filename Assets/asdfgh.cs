using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdfgh : MonoBehaviour
{
    public queue asdf;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other){
                    print(other);

        if (other.tag == "person"){
            print("asdf");
       asdf.cmon();
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
