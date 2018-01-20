using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Rigidbody2D _RB;
    public float _Velocity;
    public TriggerDetector triggers;
    public float _JumpHeight;

    // Use this for initialization
    void Start () {
        _RB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        _RB.velocity = new Vector2(_Velocity, _RB.velocity.y);
	}
    private void LateUpdate()
    {
        if(triggers.succeded == true && Input.GetKeyDown(KeyCode.Space))
        _RB.velocity = new Vector2(_RB.velocity.x, _JumpHeight);
    }
}
