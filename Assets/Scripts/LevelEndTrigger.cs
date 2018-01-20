using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other)
    {
        //triggers level end in the Score Manager
        if (other.tag == "Player")
        {
            ScoreManager.instance.levelSuccess = true;
        }

    }

}
