using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectorDown : MonoBehaviour {

    //Function for triggers to set the motion of the player with a downward angle.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ScoreManager.instance.goingDown = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ScoreManager.instance.goingDown = false;
        }

    }
}
