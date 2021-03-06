﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour {

    //Stablishing and declaring vaiables
    private bool onBeat = false;
    public GameObject beat;
    public Transform spawnLocation;
    public float beatTime;
    private int i = 0;

    bool startBeats = false;

    public AudioSource music;

    private GameObject current;

    public bool alreadyMissed = false;
    public bool inputPressed = false;

    public bool succeded = false;
    public bool failed = false;

    private bool songStarted = false;

    public float beatErrorCheck;

    private bool optionaBeat = false;

    private GameObject currentOptional;

    public bool optionalSuccess = false;

    public SpriteRenderer SuccessMask;
    public SpriteRenderer FailMask;

    private Color maskColor = Color.white;

    private bool HasFailureMask;
    private bool HasSuccessMask;

    //starts the song and beats corutines
    private void Start()
    {
        music.Play();
    }

    private void Update()
    {
        if (HasFailureMask || HasSuccessMask)
        {
            maskColor.a-= 0.1f;
            if (HasSuccessMask)
            {
                SuccessMask.color = maskColor;
            }else
            {
                FailMask.color = maskColor;
            }
        }


        //checks input, if player hasn't missed note already and if it is on the beat.
        if (optionaBeat && CombatInputCheck() && ScoreManager.instance.isFighting)
        {
            StartCoroutine(OptionalSuccess());
            Destroy(currentOptional);
        }
        else if (onBeat && (Input.GetKeyDown(ScoreManager.instance.requiredInput) || Input.GetKeyDown(ScoreManager.instance.optionalInput)) && alreadyMissed == false)
        {

            Debug.Log("True");
            StartCoroutine(Success());
            HasFailureMask = false;
            HasSuccessMask = true;
            maskColor.a = 1;
            Destroy(current.gameObject);
        }
        else if (alreadyMissed == true)
        {
            return;
        }
        else if (InputCheck())
        {
            Missed();
            HasSuccessMask = false;
            HasFailureMask = true;
            maskColor.a = 1;
            alreadyMissed = true;
        }

    }



    //checks if a note is inside the beat trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        { 
        print("onBeat");
        onBeat = true;
        current = other.gameObject;
        }
        else if (other.CompareTag("Optional"))
        {
            print("optional");
            optionaBeat = true;
            currentOptional = other.gameObject;
        }
    }

    //checks if a note has left the beat trigger and destroys the note
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
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
        } else if (other.CompareTag("Optional"))
        {
            optionaBeat = false;
            Destroy(other.gameObject, 0.1f);
        }
    }

    //General cover all input checks in case they are wrong
    private bool InputCheck()
    {
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
        {
            return true;
        } else { return false; }
    }

    private bool CombatInputCheck()
    {
        if(Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    //Function for when notes are missed
    private void Missed()
    {
        alreadyMissed = true;
        Debug.Log("missed");
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
        ScoreManager.instance.barEnergy -= 30;
        failed = true;
        yield return null;
        failed = false;
    }

    IEnumerator OptionalSuccess()
    {
        optionalSuccess = true;
        yield return null;
        optionalSuccess = false;
    }

}
