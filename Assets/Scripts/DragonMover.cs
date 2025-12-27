using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMover : MonoBehaviour
{
    public float moveSpeed = 10f;       // forward/backward speed
    public float rotationSpeed = 100f;  // turning speed
    public float verticalSpeed = 7f;    // up/down speed

    void Update()
    {
        // FORWARD & BACKWARD
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }

        // ROTATION LEFT & RIGHT
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // MOVE UP (ENTER key)
        if (Input.GetKey(KeyCode.Return))   // Return = Enter key
        {
            transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
        }

        // MOVE DOWN (LEFT SHIFT)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(-Vector3.up * verticalSpeed * Time.deltaTime);
        }
    }
}
