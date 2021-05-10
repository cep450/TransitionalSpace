using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStart : MonoBehaviour
{

    //colliders and triggers and whatever need a rigidbody which i don't want to deal w physics...
    //so i'm just doing the math manually like "is the distance between the player and the NPC whatever"
    float playerNearbyRadius = 2.5f;
    public Transform playerTransform;

    bool indicatorDisplayed = false;


    /* Start is called before the first frame update
    void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {

        //are they in our circle?
        if(Vector3.Distance(playerTransform.position, transform.position) <= playerNearbyRadius){

            //show that this person can be talked to! 
            //if not displayed, display
            if(!indicatorDisplayed) {
                //display the indicator
                Renderer [] renderers = GetComponentsInChildren<Renderer>();
                foreach(Renderer r in renderers) {
                    if(r.tag.Equals("TalkIndicator")) {
                        r.enabled = true;
                    }
                }
                indicatorDisplayed = true;
            }

            //when the player presses [interact key] (E, space, click, enter.... all of these)
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E)) {

                //stop showing the indicator
                //TODO

                //open up the dialogue window and start!
                Debug.Log("hello!");
                //TODO 

            }
        } else {
            
            //we're not in their circle 
            //if the indicator is displayed, stop displaying it.
            if(indicatorDisplayed) {
                Renderer [] renderers = GetComponentsInChildren<Renderer>();
                foreach(Renderer r in renderers) {
                    if(r.tag.Equals("TalkIndicator")) {
                        r.enabled = false;
                    }
                }
                indicatorDisplayed = false;
            }

        }
    }
}
