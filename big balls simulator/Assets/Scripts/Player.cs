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
    private float mouse_x;
    private float mouse_y;
    private Rigidbody rigid_body;
    private bool is_grounded;
    

    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }
        horizontal_in = Input.GetAxis("Horizontal");
        backnforth_in = Input.GetAxis("Vertical");
        mouse_x = Input.GetAxis("Mouse X");
        mouse_y = Input.GetAxis("Mouse Y");
    }

    private void FixedUpdate()
    {
        if (Physics.OverlapSphere(ground_check.position, 0.1f, playerMask).Length == 0)
        {
            is_grounded = false;
        } else
        {
            is_grounded = true;
        }

        if (jump && is_grounded == true)
        {
            rigid_body.AddForce(Vector3.up * 3, ForceMode.VelocityChange);
            jump = false;
        }
        rigid_body.velocity = new Vector3(horizontal_in, rigid_body.velocity.y, backnforth_in);
    }
}
 