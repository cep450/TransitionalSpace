using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour
{

    //when a key is pressed, move the camera down
    //then, fade away the grey thing 

    public Transform cameraTransform;
    public SpriteRenderer greySprite;

    bool hasPressedSpace = false;
    bool doMove = false;
    float moveAccel = 0.03f;
    float moveVel = 0;
    float cameraDestination = 2.07f;


    bool doFade = false;
    float transparencyCounter = 1f;
    float transparencyDecreasePerTick = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when player presses space for the first time, kick off the transition
        if(!hasPressedSpace) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                doMove = true;
            }
        } 
    }

    void FixedUpdate() {

        //if we're moving, move the camera
        if(doMove) {
            moveVel += moveAccel;
            cameraTransform.Translate(Vector3.down * moveVel);
            if(cameraTransform.position.y <= cameraDestination) {
                doMove = false; 
                doFade = true;
                cameraTransform.Translate(Vector3.down * (cameraTransform.position.y - cameraDestination));
            }

        }

        //if we're doing a fade, decrease transparency 
        if(doFade) {
            greySprite.color = new Color(1f, 1f, 1f, transparencyCounter);
            transparencyCounter -= transparencyDecreasePerTick;
            if(transparencyCounter <= 0) {
                doFade = false;
            }
        }
    }

}
