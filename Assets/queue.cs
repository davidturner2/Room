using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class queue : MonoBehaviour
{
    public Transform sd;
    public bool has_clicked = false;
    public AudioSource ahh1;
    public AudioSource ahh2;
    Vector3 leaveFirst = new Vector3(348.6013f,126.2976f,-294.03f);
    Queue<Vector3> people = new Queue<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        // add the children to the queue
        for (int i =0; i<transform.childCount; i++){
            people.Enqueue(transform.GetChild(i).GetComponent<enemy>().goal);
            print(people.ToArray()[i]);

        }
        for (int i =0; i<transform.childCount; i++){
            people.Enqueue(transform.GetChild(i).GetComponent<enemy>().goal);
            print(people.ToArray()[i]);

        }
            }
    void poop(){
        //deque one and add to the start for offseting the queue
       people.Enqueue(people.Dequeue());
       

        for (int i =0; i<transform.childCount; i++){
            //start moving the enemy
                                                        transform.GetChild(i).GetComponent<enemy>().aaa = false;

            if(Vector3.Distance(transform.GetChild(i).GetComponent<enemy>().goal,leaveFirst)<=1){
                transform.GetChild(i).GetComponent<enemy>().n = true;
                                transform.GetChild(i).GetComponent<enemy>().aaa = true;
                //start rujnning these corutotines
        StartCoroutine("old");
        StartCoroutine("oldman");

            }

                            transform.GetChild(i).GetComponent<enemy>().n = true;

        }
       // transform.GetChild(0).GetComponent<enemy>().goal = 
     
         for(int i = 0; i<transform.childCount; i++){
            print(i + " "+ transform.GetChild(i).name);
        }
    }
    // Update is called once per frame
    void Update()
    {
                for (int i =0; i<transform.childCount; i++){
                    //for the person thats close to the front of the line
                   if(Vector3.Distance(transform.GetChild(i).GetComponent<enemy>().goal,leaveFirst)<=1){
                    if (has_clicked == false){
                    // set the child that needs to be clicked to have a red material
                    transform.GetChild(i).GetChild(0).GetChild(1).GetComponent<Renderer>().material.color =new Vector4(1f,0,0,1);
                    }
                   }else{
                                        transform.GetChild(i).GetChild(0).GetChild(1).GetComponent<Renderer>().material.color =new Vector4(1,1,1);

                   }
                }
        
        Ray asadsfdg = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit lskdljf = new RaycastHit();
        if(Physics.Raycast(asadsfdg, out lskdljf)){
            // if pointing to the person near the front of the line and click run functions and set has clicked to true so you gotta wait until its false again.
            if (lskdljf.collider.gameObject.tag == "person" && Input.GetMouseButtonDown(0)){
                if (Vector3.Distance(lskdljf.collider.gameObject.GetComponent<enemy>().goal,leaveFirst) <= 1 && has_clicked == false){
                    //print("Asdfff");
                    ahh1.Play();
                    ahh2.Play();
                    poop();
               has_clicked = true;
                }

            }
        }
          
    }

    // make a new queue but pause inbetween and wait until the front of the line person is close to the back to set the new goals for the people
    IEnumerator old(){
for (int i = 0; i<transform.childCount; i++){
                transform.GetChild(i).GetComponent<enemy>().goal=people.Dequeue();
}
                  people.Clear();

        yield return new WaitForSeconds(3.0f);
        for (int i =0; i<transform.childCount; i++){
            people.Enqueue(transform.GetChild(i).GetComponent<enemy>().goal);
        }
        cmon();
    }
     IEnumerator oldman(){
        yield return new WaitForSeconds(1.2f);
        for (int i =0; i<transform.childCount; i++){
                                transform.GetChild(i).GetComponent<enemy>().aaa = true;
            }
    }
    public void cmon(){
          for (int i =0; i<transform.childCount; i++){
                transform.GetChild(i).GetComponent<enemy>().n = true;
                                transform.GetChild(i).GetComponent<enemy>().aaa = false;

            }
          //set has click to false at the end of this
            has_clicked = false;
                
    }
  

}
