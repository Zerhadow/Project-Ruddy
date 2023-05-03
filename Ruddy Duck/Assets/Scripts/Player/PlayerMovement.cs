using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 90f;
    Animator anim;

    CharacterController characterController;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = transform.forward * vertical + transform.right * horizontal;
        anim.SetFloat("Velocity", direction.magnitude);
        // Debug.Log(direction.magnitude);

        if (direction != Vector3.zero)
        {
            characterController.SimpleMove(direction * speed);
            // Debug.Log("Moving: " + direction * speed);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
