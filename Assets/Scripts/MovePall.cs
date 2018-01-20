using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovePall : MonoBehaviour {

    //sets up variables for tweening.
    public Vector3 endPosition;


    public float duration;
    public LoopType loops;
    public Ease easeType;
    Tweener moveTween;



    private void Start()
    {
        //Begins the tweening at Start
        moveTween = transform.DOMove(endPosition, duration);
        moveTween.SetRelative(true);
        moveTween.SetEase(easeType);
    }



}
