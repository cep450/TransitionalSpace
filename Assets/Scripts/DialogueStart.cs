using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStart : MonoBehaviour
{

    //colliders and triggers and whatever need a rigidbody which i don't want to deal w physics...
    //so i'm just doing the math manually like "is the distance between the player and the NPC whatever"
    float playerNearbyRadius = 2f;
    public Transform playerTransform;


    /* Start is called before the first frame update
    void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {

        //when the player presses [interact key] (E, space, click, enter.... all of these)
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E)) {

            //are they in our circle?
            if(Vector3.Distance(playerTransform.position, transform.position) <= playerNearbyRadius){

                //open up the dialogue window and start!
                Debug.Log("hello!");
                //TODO 

            }
        }
    }
}
