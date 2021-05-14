using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //camera will only move side to side, and will stop at certain values.


    //stop moving here
    float negMax = -6.9f;
    float posMax = 32.1f;

    //deadzone size
    float deadzone = 2.4f;
    
    float lastPlayerPosition;
    float playerPositionDiff = 0f;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        lastPlayerPosition = player.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        playerPositionDiff = player.position.x - lastPlayerPosition;
        lastPlayerPosition = player.position.x;

        //has the player gone outside of our deadzone?
        if((player.position.x > transform.position.x + deadzone && transform.position.x + playerPositionDiff < posMax
        && playerPositionDiff > 0f) || 
        (player.position.x < transform.position.x - deadzone && transform.position.x + playerPositionDiff > negMax
        && playerPositionDiff < 0f)) {
            transform.Translate(Vector3.right * playerPositionDiff);

        }
        
    }
}
