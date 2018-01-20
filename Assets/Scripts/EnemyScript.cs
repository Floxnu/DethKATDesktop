using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public KeyCode[] Inputs;
    private TriggerDetector player = null;

    private int beat = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Entered");
            beat = Inputs.Length;
            player = other.gameObject.GetComponent<TriggerDetector>();
        }
    }

    private void Update()
    {
            while (beat > 0)
            {
                ScoreManager.instance.requiredInput = Inputs[beat -1];
                ScoreManager.instance.optionalInput = Inputs[beat -1];
                if(player.succeded == true)
                {
                    --beat;
                }
            }
            if(beat<= 0)
            {
                Destroy(gameObject);
            }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player"){ 
        ScoreManager.instance.requiredInput = KeyCode.D;
        ScoreManager.instance.optionalInput = KeyCode.D;
        }
    }
}
