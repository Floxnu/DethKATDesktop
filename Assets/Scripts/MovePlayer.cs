using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePlayer : MonoBehaviour {

    private Rigidbody2D _RB;

    public float Velocity;

	// Use this for initialization
	void Start ()
    {
        _RB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        _RB.velocity = new Vector2(Velocity, _RB.velocity.y);
	}
}
