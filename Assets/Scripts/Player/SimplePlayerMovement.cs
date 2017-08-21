﻿using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimplePlayerMovement : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField]
    private Animator animator;
    private float currentSpeed;

    private void Start()
    {

    }

    private void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            currentSpeed = moveDirection.magnitude;
            if (Input.GetButtonDown("Jump"))
                animator.SetTrigger("Jump");
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        if (Input.GetMouseButtonDown(0))
            animator.SetTrigger("Punch");
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        animator.SetFloat("Speed", currentSpeed);
    }
}