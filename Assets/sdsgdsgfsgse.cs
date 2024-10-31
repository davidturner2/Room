using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class sdsgdsgfsgse : MonoBehaviour
{
        public TextMeshProUGUI troll;

    float timesd;
    public GameObject[] dancers;
    // Start is called before the first frame update
    void Start()
    {
                        int a = Mathf.RoundToInt(Random.Range(1,4));
for (int i = 0 ; i<dancers.Length; i++){
    dancers[i].GetComponent<Animator>().SetInteger("music",a);
}
troll.text = a.ToString();

     timesd = Random.Range(0,10);   
     StartCoroutine("dance");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator dance(){
                yield return new WaitForSeconds(timesd);
                int a = Mathf.RoundToInt(Random.Range(1,4));

for (int i = 0 ; i<dancers.Length; i++){
    dancers[i].GetComponent<Animator>().SetInteger("music",a);
}
troll.text = a.ToString();
     timesd = Random.Range(0,10);   
     StartCoroutine("dance");

    }
}
