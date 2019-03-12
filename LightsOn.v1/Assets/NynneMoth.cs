using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NynneMoth : MonoBehaviour {

    // public variables for; speed, player gameObject, something for identifying light, range (max and min dist)

	// Use this for initialization
	void Start () {
		// Call idle function
	}
	
	// Update is called once per frame
	void Update () {

        // If no light on and player is out of reach, call Idle()

        // If light is on, call FollowLight()

            // If min dist is small enough, i.e. the moths have found the light, While light is on, call idle() 

        // If light is not on and player is in reach, call FollowPlayer()

        // If the moth collide with the player, print death message


    }

    void FollowPlayer()
    {

    }

    void FollowLight()
    {
        
    }

    void Idle()
    {

    }

}
