using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBoxes : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "JumpBox")
        {
            ScoreManager.instance.canJump = true;
        }
        if (other.gameObject.CompareTag("DownBox"))
        {
            ScoreManager.instance.goingDown = true;
        }
    }
        private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "JumpBox")
        {
            ScoreManager.instance.canJump = false;
        }
        if (other.gameObject.CompareTag("DownBox"))
        {
            ScoreManager.instance.goingDown = false;
        }
    }

}
