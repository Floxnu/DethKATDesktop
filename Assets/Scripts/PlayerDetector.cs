using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour {

    public bool requiredJump;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && requiredJump == true)
        {
            Debug.Log("EnteredBox");
            ScoreManager.instance.canJump = true;
            ScoreManager.instance.requiredInput = KeyCode.Space;
            ScoreManager.instance.optionalInput = KeyCode.Space;

        }
        //Detects if the player is inside an area to jump.
        else if (other.tag == "Player")
        {
            Debug.Log("EnteredBox");
            ScoreManager.instance.canJump = true;
            ScoreManager.instance.optionalInput = KeyCode.Space;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //Disables jump if the player is outside the area.
        if (other.tag == "Player")
        {
            ScoreManager.instance.canJump = false;
            ScoreManager.instance.requiredInput = KeyCode.D;
            ScoreManager.instance.optionalInput = ScoreManager.instance.requiredInput;
        }

    }
}
