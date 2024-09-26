using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ultimatetroll : MonoBehaviour
{
    public TextMeshProUGUI troll;
    GameObject player;
    float timer = 0;
    bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        troll.text = "";
    }

    private void OnTriggerEnter(Collider other){
        if ( other.tag=="Player"){
            player = other.gameObject;
            start = true;
            
        }
    }
    private void OnTriggerExit(Collider other){
        if ( other.tag=="Player"){
            start = false;
            timer = 0;
                    troll.text = "";

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(start && GameObject.FindWithTag("Player")!= null){
                timer += Time.deltaTime;
                troll.text = "Stand here for: "+(7-Mathf.RoundToInt(timer))+" seconds to get the real ending!\U0001F947\U0001F480\U0001F480\U0001F480\U0001F480\U0001F480\U0001F480";

        }else{
            troll.text = "";
             if (Input.GetKeyDown("space")&& GameObject.FindWithTag("Player")== null)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

}
