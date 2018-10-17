using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidmover : MonoBehaviour {
    public float speed;
    public float tumble;
    private Rigidbody2D rBody;
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = transform.right * speed;
        rBody.angularVelocity = Random.value * tumble;
	}
}
