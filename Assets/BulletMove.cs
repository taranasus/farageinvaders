using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // Configurable speed for the bullet movement
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        // Move the bullet forward along its Y axis
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}