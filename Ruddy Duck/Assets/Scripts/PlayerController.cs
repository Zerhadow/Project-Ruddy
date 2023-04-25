using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 6f;
    public float rotateSpeed = 15f;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight = 1.8f;
    public LayerMask groundLayer;
    bool grounded;
    
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private KeyCode UnitList = KeyCode.Tab;

    public int gold = 100;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        // rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);

        MyInput();

        //handle drag
        if (grounded) {
            rb.drag = groundDrag;
        } else {
            rb.drag = 0f;
        }

    }

    private void FixedUpdate() {
        Move();

        if(Input.GetKeyDown(UnitList)) {
            Debug.Log("Unit List");
        }
    }

    private void MyInput() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void Move() {
        moveDirection = (orientation.forward * verticalInput) + (orientation.right * horizontalInput);
        rb.velocity = moveDirection * speed;
        transform.Rotate(0f, horizontalInput * rotateSpeed * Time.deltaTime, 0f);
    }

    private void SpeedControl() {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if (flatVel.magnitude > speed) {
            rb.velocity = flatVel.normalized * speed + new Vector3(0f, rb.velocity.y, 0f);
        }
    }
}
