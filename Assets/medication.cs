using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medication : MonoBehaviour
{
    private blastoff a;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponentInChildren<blastoff>();
        GetComponentInChildren<Animator>().Play("none");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
