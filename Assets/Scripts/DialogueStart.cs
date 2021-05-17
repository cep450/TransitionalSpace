using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yarn.Unity {
public class DialogueStart : MonoBehaviour
{

    //colliders and triggers and whatever need a rigidbody which i don't want to deal w physics...
    //so i'm just doing the math manually like "is the distance between the player and the NPC whatever"
    float playerNearbyRadius = 2.5f;
    public Transform playerTransform;

    bool indicatorDisplayed = false;


    public MyNPC target;

    // Update is called once per frame
    void Update()
    {

        //don't do this if we're talking to someone
        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true) {
            return;
        }

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
                Renderer [] renderers = GetComponentsInChildren<Renderer>();
                foreach(Renderer r in renderers) {
                    if(r.tag.Equals("TalkIndicator")) {
                        r.enabled = false;
                    }
                }
                indicatorDisplayed = false;

                //open up the dialogue window and start!
                Debug.Log("hello!");
                FindObjectOfType<DialogueRunner> ().StartDialogue (target.talkToNode);

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

}
