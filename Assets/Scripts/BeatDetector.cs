using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDetector : MonoBehaviour {

    //Stablishing and declaring vaiables
    private bool onBeat = false;

    bool startBeats = false;

    private GameObject current;

    public bool alreadyMissed = false;
    public bool inputPressed = false;

    public bool succeded = false;
    public bool failed = false;

    private bool songStarted = false;

    public float beatErrorCheck;

    //starts the song and beats corutines
    private void Start()
    {

    }

    private void Update()
    {


        //checks input, if player hasn't missed note already and if it is on the beat.
        if (onBeat && (Input.GetKeyDown(ScoreManager.instance.requiredInput) || Input.GetKeyDown(ScoreManager.instance.optionalInput)) && alreadyMissed == false)
        {

            Debug.Log("True");
            StartCoroutine(Success());
            GetComponent<SpriteRenderer>().color = Color.green;
            Destroy(current.gameObject);
        }
        else if (alreadyMissed == true)
        {
            return;
        }
        else if (InputCheck())
        {
            Missed();
            alreadyMissed = true;
        }


    }



    //checks if a note is inside the beat trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("onBeat");
        onBeat = true;
        current = other.gameObject;

    }

    //checks if a note has left the beat trigger and destroys the note
    private void OnTriggerExit2D(Collider2D other)
    {
        if (InputCheck())
        {
            alreadyMissed = false;
            onBeat = false;
            return;
        }
        else if (alreadyMissed == false)
        {
            Missed();
        }
        onBeat = false;
        alreadyMissed = false;

        Destroy(other.gameObject, 0.1f);
    }

    //General cover all input checks in case they are wrong
    private bool InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
        {
            return true;
        }
        else { return false; }
    }

    //Function for when notes are missed
    private void Missed()
    {
        alreadyMissed = true;
        Debug.Log("missed");
        GetComponent<SpriteRenderer>().color = Color.red;
        ScoreManager.instance.barEnergy -= 30;
        StartCoroutine(Failure());
    }

    //corutine for when notes are hit (for enemy anims)
    IEnumerator Success()
    {
        succeded = true;
        ScoreManager.instance.Score += 50 * ScoreManager.instance.ScoreMult;
        ScoreManager.instance.barEnergy += 10;
        yield return null;
        succeded = false;
    }


    //corutine for when notes are missed (for enemy anims)
    IEnumerator Failure()
    {
        ScoreManager.instance.shakeDuration = .1f;

        failed = true;
        yield return null;
        failed = false;
    }



}

