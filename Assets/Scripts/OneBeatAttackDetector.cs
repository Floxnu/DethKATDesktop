using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OneBeatAttackDetector : MonoBehaviour {

    //setting up variables
    public KeyCode[] attackKey;

    public GameObject inputDisplay;

    private GameObject[] inputsList = {null, null, null};

    private TriggerDetector playerCheck = null;

    private bool hasAnimated = false;
    private bool hasEntered = false;

    private int beats;


    private void Start()
    {
        beats = attackKey.Length;
        BeatUX();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
      //check if the player entes the attack area
        if (other.tag == "Player")
        {
            //makes the player have to press the correct attack key.
            playerCheck = FindObjectOfType<TriggerDetector>();
            hasEntered = true;
            ScoreManager.instance.isFighting = true;
            Debug.Log("EnteredBox");
           
            
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //Returns key requirements to normal.
        if (other.tag == "Player")
        {
            ScoreManager.instance.requiredInput = KeyCode.D;
            ScoreManager.instance.optionalInput = KeyCode.D;
            ScoreManager.instance.isFighting = false;
            hasEntered = false;
        }

    }

    private void Update()
    {
        if (hasEntered == true)
        {
            //Triggers failure state, will be replaced with Anim.
            if(beats > 0)
            {
                ScoreManager.instance.requiredInput = attackKey[beats - 1];
                ScoreManager.instance.optionalInput = attackKey[beats - 1];
            }


            if (playerCheck.failed == true && hasAnimated == false)
            {
                ScoreManager.instance.HurtSound.Play();
                transform.Translate(-5, 0, 0);
                ScoreManager.instance.shakeDuration = .1f;
                hasAnimated = true;
                ScoreManager.instance.requiredInput = KeyCode.D;
                ScoreManager.instance.optionalInput = KeyCode.D;
            }
            //Success State Kills the enemy.
            if (playerCheck.succeded == true)
            {
                ScoreManager.instance.HitSound.Play();
                ScoreManager.instance.shakeDuration = .1f;
                Destroy(inputsList[beats-1]);
                --beats;
                if(beats == 0) {
                ScoreManager.instance.isFighting = false;
                Destroy(gameObject);
                    
                }
            }
        }
        
    }

    private void BeatUX()
    {
        for (int i = 0; i < beats; ++i)
        {

            inputsList[i] = Instantiate(inputDisplay);
            inputsList[i].transform.SetParent(gameObject.transform);
            if (attackKey[i] == KeyCode.J)
            {
                inputsList[i].GetComponent<SpriteRenderer>().color = Color.green;
            }
            else if (attackKey[i] == KeyCode.K)
            {
                inputsList[i].GetComponent<SpriteRenderer>().color = Color.cyan;
            }
            else if (attackKey[i] == KeyCode.L)
            {
                inputsList[i].GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }

        switch (beats)
        {
            case 1:
                inputsList[0].transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f, -1);
                break;
            case 2:
                inputsList[1].transform.position = new Vector3(transform.position.x - .4f, transform.position.y - 1.5f, -1);
                inputsList[0].transform.position = new Vector3(transform.position.x + .5f, transform.position.y - 1.5f, -1);
                break;
            case 3:
                inputsList[2].transform.position = new Vector3(transform.position.x - .9f, transform.position.y - 1.5f, -1);
                inputsList[1].transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f, -1);
                inputsList[0].transform.position = new Vector3(transform.position.x + .9f, transform.position.y - 1.5f, -1);
                break;
            default:
                break;
        }
    }

    
}
