using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform ground_check;
    [SerializeField] private LayerMask playerMask;

    private bool jump;
    private float horizontal_in;
    private float backnforth_in;
    private Rigidbody rigid_body;
    private bool is_grounded;
    public CharacterController controller;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float ground_distance = 0.4f;
    public LayerMask ground_mask;
    public float jump_height = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        is_grounded = Physics.CheckSphere(ground_check.position, ground_distance, ground_mask); // checks if the player is on the ground
        if (is_grounded && velocity.y < 0)
        {
            velocity.y = -2f; // resets the velocity to the ground if the player is not going up
        }

        horizontal_in = Input.GetAxis("Horizontal");    
        backnforth_in = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal_in + transform.forward * backnforth_in; // defines a vector3 for movement based on input
        controller.Move(move * speed * Time.deltaTime); // does the actual movement

        if (Input.GetButton("Jump") && is_grounded) // if u are jumping and are on the ground
        {
            velocity.y = Mathf.Sqrt(jump_height * -2 * gravity); // jump and gravity
        }
        velocity.y += gravity * Time.deltaTime; // gravity
        controller.Move(velocity * Time.deltaTime); // gravity movement
    }
}
 