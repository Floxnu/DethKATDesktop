using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WorldMovement : MonoBehaviour {
    //Stablishing tweening and variables for moving the world.
    public Vector3 endPosition;
    private bool canJump = false;
    private bool goingDown = false;

    public float duration;
    public Ease easeType;
    Tweener moveTween;

    public TriggerDetector onBeatCheck;

    private bool inputPressed = false;

    private void Start()
    {
        moveTween.SetRelative(true);
        moveTween.SetEase(easeType);
    }


    void Update()
    {
        //Check if the player hasn't missed the note already.
        if (onBeatCheck.alreadyMissed == false && ScoreManager.instance.isFighting == false)
        {
            //Various if Statements for actions that happen with specific inputs.
            //Movement
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (ScoreManager.instance.goingDown == true) //when on a ledge
                {
                    endPosition = new Vector3(transform.position.x - 3, transform.position.y + 3, 0);
                }
                else
                {
                    endPosition = new Vector3(transform.position.x - 3, transform.position.y, 0);
                }
                moveTween = transform.DOMove(endPosition, .3f);
            }
            //Jumping
            else if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && ScoreManager.instance.canJump == true)
            {
                endPosition = new Vector3(transform.position.x - 3, transform.position.y - 3, 0);
                moveTween = transform.DOMove(endPosition, .3f);
            }
            //Three different attacks
            //vertical
            else if(Input.GetKeyDown(KeyCode.J))
            {
                endPosition = new Vector3(transform.position.x - 3, transform.position.y, 0);
                moveTween = transform.DOMove(endPosition, .3f);
                print("Vertical");
            }
            //Horizontal
            else if(Input.GetKeyDown(KeyCode.K))
            {
                endPosition = new Vector3(transform.position.x - 5, transform.position.y, 0);
                moveTween = transform.DOMove(endPosition, .3f);
                print("Horizontal");
            }
            //Low
            else if(Input.GetKeyDown(KeyCode.L))
            {
                endPosition = new Vector3(transform.position.x - 5, transform.position.y, 0);
                moveTween = transform.DOMove(endPosition, .3f);
                print("Low");
            }


        } 
    }

    //Public fail function to be called from TriggerDetector
    public void Fail()
    {
        if (ScoreManager.instance.requiredInput == KeyCode.D)
        {
            endPosition = new Vector3(transform.position.x - 5, transform.position.y, 0);
            moveTween = transform.DOMove(endPosition, .3f);
        }
        else if (ScoreManager.instance.requiredInput == KeyCode.Space)
        {
            endPosition = new Vector3(transform.position.x - 3, transform.position.y - 3, 0);
            moveTween = transform.DOMove(endPosition, .1f);
        }
        else if (ScoreManager.instance.goingDown == true)
        {

        }
    }
    
    
}
