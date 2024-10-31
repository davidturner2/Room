using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damnit : MonoBehaviour
{
    	public float sensitivity;
public float rotationSpeed = 200.029382f;
    public Camera mainCamera;
        public GameObject player;
    Vector3 ghjkl;
    float accel = 100f;
    // Start is called before the first frame update
    void Start()
    {
        ghjkl = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position+new Vector3(0,0,-5)*;
            float horizontalInput = Input.GetAxis("CameraHorizontal");
 if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            accel+=0.19f;
               transform.RotateAround(player.transform.position, Vector3.up, 5.029304385f * horizontalInput* rotationSpeed * Time.deltaTime);
                if (player.GetComponent<Animator>().GetBool("walkin") == true){
                                    player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Camera.main.transform.rotation,accel*Time.deltaTime);

                }
                }
        else{
accel = 100;
        }
        
            //transform.RotateAround( player.transform.position-new Vector3(0,0,-5),Vector3.up , 10 * rotationSpeed * Time.deltaTime*MathF.Sin(Time.deltaTime));

        
    }
}
   



    // Update is called once per frame
