using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.AI;

public class mathtest : MonoBehaviour
{
    public TMP_InputField answer;
    public TMP_Text questoion;
    Vector3 v1 = Vector3.zero;
    Vector3 v2 = Vector3.zero;
    float theAnswer = 0;
    // Start is called before the first frame update
    void Start()
    {
        v1 = new Vector3(Random.Range(0,10),Random.Range(0,10),Random.Range(0,10));
        v2 = new Vector3(Random.Range(0,10),Random.Range(0,10),Random.Range(0,10));
        theAnswer = Vector3.Dot(v1,v2);
        questoion.text = "What does Vector3.Dot("+v1+","+v2+") equal?";
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void test(){
        if (answer.text == ""){
                        fail();

        }else{
        if (float.Parse(answer.text) == theAnswer){
                SceneManager.LoadScene(1);
        }else{
            fail();
        }
        }
    }
      void fail()
        {
           
                SceneManager.LoadScene(4);
        }
}
