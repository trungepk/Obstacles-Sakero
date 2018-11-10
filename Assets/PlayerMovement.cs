﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] float speed = 2000f;
    [SerializeField] float sidewaySpeed = 1000f;
    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        if (!GameControl.instance.isGameOver)
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
            var sideMovement = Input.GetAxis("Horizontal") * sidewaySpeed;
            rb.AddForce(sideMovement * Time.deltaTime, 0, 0);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            GameControl.instance.Lose();
        }
    }
}
