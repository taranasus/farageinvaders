using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Configurable speed for the player movement
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in screen space
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Create a ray from the camera through the mouse position
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);

        // Create a plane at the player's Y position
        Plane plane = new Plane(Vector3.up, new Vector3(0, transform.position.y, 0));

        // Find the point where the ray intersects the plane
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 mouseWorldPosition = ray.GetPoint(distance);

            // Calculate the direction from the player to the mouse position
            Vector3 direction = (mouseWorldPosition - transform.position).normalized;

            // Move the player towards the mouse position at a constant speed
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}