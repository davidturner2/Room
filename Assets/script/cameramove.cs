using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public int lvl = 0;
    public int hlvl = 0;
    private float um;
    public bool asdfgfd;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        // move based on the lvl varibale that gets updated based on another script
        um = 5.01f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-4+5*lvl,transform.position.y,-2+8*hlvl), um);
        

    }
}
