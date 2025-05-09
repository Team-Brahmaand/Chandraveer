using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrantuRoversingh : MonoBehaviour
{
    public float speed = 3.0f; // Adjust this to control the movement speed.

    void Update()
    {
        // Get input from the arrow keys (or WASD keys).
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the new position based on input and speed.
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput) * speed * Time.deltaTime;

        // Apply the movement to the GameObject's position.
        transform.Translate(movement);
    }
}
