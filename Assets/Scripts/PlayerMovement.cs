using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Yarn.Unity {
public class PlayerMovement : MonoBehaviour
{

    //code initially copied from flatgame project

    static float SPEED = 3.5f;
    static float SPEED_DIAG = SPEED * Mathf.Sin(Mathf.PI / 4) + 0.002f;

    static Vector3 faceright = new Vector3(1, 1, 1);
    static Vector3 faceleft = new Vector3(-1, 1, 1);

    //declaring here making a guess about memory management- 
    //4 booleans ever rather than making new local ones in the method every tick and
    //having them constantly getting garbage collected 
    //this is a guess tho, idk if the compiler would handle local ones better
    bool up, down, left, right = false;
    float effectivespeed;

    Rigidbody2D myRigidBody2D;

    Vector2 moveVector;

    Quaternion noRotation; 

    void Start() {

        myRigidBody2D = gameObject.GetComponent<Rigidbody2D>();

        noRotation = transform.rotation; 

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //don't rotate.... wtf
        transform.rotation = noRotation;

        //don't allow movement if we're in dialogue 
        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true) {
            return;
        }

        //only check key once
        up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        down = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        //if no keys are pressed we don't need to do any of this 
        if(!(up || down || left || right)) {
            return;
        }

        //same speed when diagonal
        if((up || down ) && (left || right)) {
            effectivespeed = SPEED_DIAG;
        } else {
            effectivespeed = SPEED;
        }

        //reset vector
        moveVector = Vector2.zero;

        if(up) {
            moveVector += new Vector2(0f, effectivespeed);
        }
        if(down) {
            moveVector += new Vector2(0f, -effectivespeed);
        }
        if(left) {
            moveVector += new Vector2(-effectivespeed, 0f);
        }
        if(right) {
            moveVector += new Vector2(effectivespeed, 0f);
        }

        //move 
        myRigidBody2D.MovePosition(myRigidBody2D.position + moveVector * Time.fixedDeltaTime);

        //flip sprite 
        if(right) {
            transform.localScale = faceright;
        } else if(left) {
            transform.localScale = faceleft;
        }

    }
}

}