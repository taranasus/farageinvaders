using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Record the starting position of the bullet
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Check the distance from the starting position
        if (Vector3.Distance(transform.position, startingPosition) > 200f)
        {
            // Self-destruct if the bullet is more than 200 units away
            Destroy(gameObject);
        }
    }

    // Handle collision detection
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is an "Enemy"
        if (collision.gameObject.name == "Enemy")
        {
            // Destroy both the bullet and the enemy
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        OnCollisionEnter(collision);

    }
}