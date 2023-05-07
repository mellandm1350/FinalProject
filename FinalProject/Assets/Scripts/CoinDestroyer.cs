using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player)
        {
            //Debug.Log("Is player");
            Destroy(this.gameObject);
        }
    }
}
