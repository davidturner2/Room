using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blastoff : MonoBehaviour
{
    private bool asdfgrsguh = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider>().enabled = false;
        StartCoroutine("aaaaaa");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (asdfgrsguh){

        GetComponent<Rigidbody>().AddExplosionForce(20f, transform.position+Vector3.forward, 5, 3.0F);

    }
    }

    IEnumerator aaaaaa(){
        yield return new WaitForSeconds(1);
                GetComponent<BoxCollider>().enabled = true;
 GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        asdfgrsguh = true;
    }
}
