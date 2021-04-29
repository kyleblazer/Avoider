using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public GameObject player;
    public bool coinHasBeenPickedUp = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            coinHasBeenPickedUp = true;
            Debug.Log("Coin has been picked up!");
            Destroy(this.gameObject);
        }
    }
}