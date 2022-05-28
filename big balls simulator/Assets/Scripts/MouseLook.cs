using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [Tooltip("The maximum angle from the horizon the player can rotate, in degrees")]
    [SerializeField] private float maxVerticalAngleFromHorizon;

    public float sensitivity = .5f; //sensitivity multiplier
    public Transform player_body;
    float x_rotation = 0f;

    public Vector2 turn;
    private Vector2 rotation;

    private float ClampVerticalAngle(float angle)
    {
        return Mathf.Clamp(angle, -maxVerticalAngleFromHorizon, maxVerticalAngleFromHorizon);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //locks cursor
        //Vector3 newVec = new Vector3(0f, 0f, 0f);
        //newVec.y = angle;
        //transform.eulerAngles = newVec;


    }

    // Update is called once per frame
    void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; //get x val
        float mouse_y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime; //get y val

        x_rotation -= mouse_y;
        x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);

        rotation.y = ClampVerticalAngle(rotation.y);

        transform.localRotation = Quaternion.Euler(x_rotation, rotation.y, 0f); //convert mouse pos to camera movement
        player_body.Rotate(Vector3.up * mouse_x); // rotates the player based on camera
        
    }
}
