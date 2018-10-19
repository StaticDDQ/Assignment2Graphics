﻿using UnityEngine;

// Must have rigidbody for the player
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    private new Rigidbody rigidbody;
    private Transform cam;
    
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;

    public Vector3 moveDir = Vector3.zero;
    private float distToGround;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void Update()
    {

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigidbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDir = cam.TransformDirection(moveDir);
        moveDir.y = 0f;

        if (Input.GetKey(KeyCode.LeftShift) && IsGrounded())
        {
            moveSpeed = 8f;
        }
        else
        {
            moveSpeed = 5f;
        }
        rigidbody.MovePosition(rigidbody.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
