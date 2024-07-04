using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public float speed = 1f; // Configurable starting speed
    public float speedIncrease = 0.1f; // Speed increase each time the enemy moves down
    public float moveDownDistance = 1f; // Distance to move down on the Z axis

    private bool movingRight = true; // Direction flag
    private Vector3 startingPosition;

    Transform player;

    void Start()
    {
        startingPosition = transform.position;
        player = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {

        if (transform != null && player != null)
        {
            if (transform.position.z < player.position.z - 2)
            {
                FindObjectOfType<WinConditionMonitor>().IsLoose = true;
            }
        }
    }

    void Move()
    {
        // Move the enemy left or right based on the direction flag using world coordinates
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.fixedDeltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.fixedDeltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Right Border" || collision.gameObject.name == "Left Border" || collision.gameObject.name == "Enemy")
        {
            // Reverse direction
            movingRight = !movingRight;

            // Move down on the Z axis using world coordinates
            transform.position += Vector3.back * moveDownDistance;

            // Increase speed
            speed += speedIncrease;
        }

        if (collision.gameObject.name == "Player")
        {
            // Set as loose
            FindObjectOfType<WinConditionMonitor>().IsLoose = true;
        }
    }
}