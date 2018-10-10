using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}
public class PlayerMove : MonoBehaviour {

    //Variable Declarations
    public float speed = 8.0f;
    public Boundary boundary;
    //public float xMin, xMax, yMin, yMax;
    public GameObject PlayerLaser;
    public GameObject topLaserSpawn;
    public GameObject botLaserSpawn;
    public float fireRate = 0.5f;
    private Rigidbody2D rBody;
    private float myTime = 0.0f;
    //Declare Rigidbody as private, call once in start.
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Time.deltaTime);
        myTime += Time.deltaTime;
        if (Input.GetButton("Fire1") && myTime > fireRate)
        {
            Instantiate(PlayerLaser, topLaserSpawn.transform.position, topLaserSpawn.transform.rotation);
            Instantiate(PlayerLaser, botLaserSpawn.transform.position, botLaserSpawn.transform.rotation);
            myTime = 0.0f;
        }
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
            Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rBody.position.y, boundary.yMin, boundary.yMax)
            );
        //Debug.Log("x: " + horz +", y: " + vert);
    }
}
