using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouse_sens = 100;
    public Transform player_body;
    float x_rotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float mouse_x = Input.GetAxis("Mouse X") * 80;
        float mouse_y = Input.GetAxis("Mouse Y") * 80;
        x_rotation -= mouse_y;
        x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
        player_body.Rotate(Vector3.up * mouse_x);
    }
}
