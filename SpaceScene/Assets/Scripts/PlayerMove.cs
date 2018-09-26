using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    //Variable Declarations
    public float speed = 8.0f;
    public float xMin, xMax, yMin, yMax;

    private Rigidbody2D rBody; 
    //Declare Rigidbody as private, call once in start.
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Fixed framerate update, used for physics
    private void FixedUpdate()
    {
        //Get input
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horz, vert);
        //Player movement
        rBody.velocity = movement * speed;
        //restrict player movement
        rBody.position = new Vector2(
            Mathf.Clamp(rBody.position.x, xMin, xMax),
            Mathf.Clamp(rBody.position.y, yMin, yMax)
            );
        //Debug.Log("x: " + horz +", y: " + vert);
    }
}
