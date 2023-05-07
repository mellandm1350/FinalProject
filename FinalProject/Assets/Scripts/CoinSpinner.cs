using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpinner : MonoBehaviour
{
    public float minSpeed = 2f; // minimum spin speed
    public float maxSpeed = 5f; // maximum spin speed

    void Start()
    {
        // Find all GameObjects in the scene with the "Coin" tag
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        // Loop through each coin and give it a random spin speed along the y-axis
        foreach (GameObject coin in coins)
        {
            // Calculate a random spin speed between minSpeed and maxSpeed
            float spinSpeed = Random.Range(minSpeed, maxSpeed);

            // Apply the spin speed to the coin's Rigidbody component
            Rigidbody coinRigidbody = coin.GetComponent<Rigidbody>();
            if (coinRigidbody != null)
            {
                coinRigidbody.angularVelocity = new Vector3(0f, spinSpeed, 0f);
            }
        }
    }
}