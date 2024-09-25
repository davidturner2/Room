using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class whattheheck : MonoBehaviour
{
    Quaternion l;
    float um;
    public bool followLoop = false;
    GameObject player;
    int cool;
    List<GameObject> s = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        print("cool "+cool);
        um = 15.01f * Time.deltaTime;

        if (followLoop)
        {
            player.transform.position = Vector3.Lerp(player.transform.position,s[cool].transform.GetChild(0).transform.position, um);
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, s[cool].transform.rotation, um);

            if (Input.GetKeyDown("right"))
            {
                if (cool >= gameObject.transform.childCount-2)
                {
                    player.GetComponent<movement>().stopdetecting = false;
                    player.transform.rotation = l;
                    player.GetComponent<movement>().movetothis = new Vector3(Mathf.RoundToInt(player.transform.position.x), 0.35f, Mathf.RoundToInt(player.transform.position.z));
                    player.GetComponent<movement>().movelol(new Vector3(0f, 0f, -1f));
                    followLoop = false;
                    player.GetComponent<Rigidbody>().useGravity = true;
                }
                else
                {
                    cool++;
                }
            }
            if (Input.GetKeyDown("left"))
            {
                if (cool <= 0)
                {
                    player.GetComponent<movement>().stopdetecting = false;
                    player.transform.rotation = l;
                      player.GetComponent<movement>().movetothis = new Vector3(Mathf.RoundToInt(player.transform.position.x), 0.35f, Mathf.RoundToInt(player.transform.position.z));
                    player.GetComponent<movement>().movelol(new Vector3(0f, 0f, 1f));
                    followLoop = false;
                    player.GetComponent<Rigidbody>().useGravity = true;

                }
                else
                {
                    cool--;
                }
            }
        }
    }

    // Start is called before the first frame update


    public void asdf(Collider other)
    {
         print(gameObject.transform.childCount);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            //print(i);
            //print(gameObject.transform.GetChild(i).gameObject.name);
            s.Add(gameObject.transform.GetChild(i).gameObject);
        }
        player = other.gameObject;
        l = other.transform.rotation;
        other.gameObject.GetComponent<movement>().stopdetecting = true;
                    player.GetComponent<Rigidbody>().useGravity = false;

        followLoop = true;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (s[i].GetComponent<conen>().connected == true)
            {
                cool = i;

            }
        }
        other.transform.rotation = s[cool].transform.rotation;

    }
}
