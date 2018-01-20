using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour {

    public Vector3 endPosition;

    public float duration;
    public LoopType loops;
    public Ease easeType;
    Tweener moveTween;

    private void Start()
    {
        moveTween.SetRelative(true);
        moveTween.SetEase(easeType);
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            endPosition = new Vector3(transform.position.x + 5, transform.position.y, 0);
            moveTween = transform.DOMove(endPosition, .1f);
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            endPosition = new Vector3(transform.position.x + 5, transform.position.y + 3, 0);
            moveTween = transform.DOMove(endPosition, .1f);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            endPosition = new Vector3(transform.position.x + 5, transform.position.y, 0);
            moveTween = transform.DOMove(endPosition, .1f);
            print("Vertical");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            endPosition = new Vector3(transform.position.x + 5, transform.position.y, 0);
            moveTween = transform.DOMove(endPosition, .1f);
            print("Horizontal");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            endPosition = new Vector3(transform.position.x + 5, transform.position.y, 0);
            moveTween = transform.DOMove(endPosition, .1f);
            print("Low");
        }
    }
}
