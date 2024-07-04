using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Reference to the bullet prefab
    public GameObject bulletPrefab;

    // Bullet spawn point offset
    public Vector3 bulletSpawnPoint = new Vector3(0, 0, 5);

    // Frequency of shooting in seconds
    public float shootFrequencyInSeconds = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Start the shooting coroutine
        StartCoroutine(ShootCoroutine());
    }

    // Coroutine to handle shooting at regular intervals
    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(shootFrequencyInSeconds);
        }
    }

    // Method to instantiate a bullet
    void Shoot()
    {
        // Calculate the bullet spawn position
        Vector3 spawnPosition = transform.position + bulletSpawnPoint;

        // Instantiate the bullet at the calculated position with the same rotation as the player
        Instantiate(bulletPrefab, spawnPosition, bulletPrefab.transform.rotation);
    }
}