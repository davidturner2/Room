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
    private Racer trolls;
    // Start is called before the first frame update

    public void Awake()
    {
        trolls = new Racer();

        trolls.PCtrolls.jump.performed += ctx => aump();

    }

    private void OnEnable()
    {
        trolls.PCtrolls.Enable();
    }
    private void OnDisable()
    {
        trolls.PCtrolls.Disable();
    }


    void Start()
    {
        

        troll.text = "";
    }

// set start to teue
    private void OnTriggerEnter(Collider other){
        if ( other.tag=="Player"){
            player = other.gameObject;
            start = true;
            
        }
    }
    // when exit reset timer to zero and remove all text
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
        //start counting down and displaying the text with the timer when start is true else if the player doesnt exist remove all text
        if(start && GameObject.FindWithTag("Player")!= null){
                timer += Time.deltaTime;
                troll.text = "Stand here for: "+(7-Mathf.RoundToInt(timer))+" seconds to get the real ending!\U0001F947\U0001F480\U0001F480\U0001F480\U0001F480\U0001F480\U0001F480";

        }else{
            troll.text = "";
             
        }
    }
    // when player is deleted load scene 2
    void aump()
    {
        if (GameObject.FindWithTag("Player") == null)
        {
            SceneManager.LoadScene(2);
        }
    }

}
