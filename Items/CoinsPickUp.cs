using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPickUp : MonoBehaviour
{
    //Coin manager
    private GameManager coinScript;

    //Son
    public AudioClip coinSound;
    public GameObject plus_un;

    void Start()
    {
        coinScript = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            coinScript.addCoins();
            Instantiate(plus_un, new Vector3(collision.transform.position.x + 1f, collision.transform.position.y + 1f, transform.position.z), transform.rotation);
            if (coinSound)
            {
                AudioSource.PlayClipAtPoint(coinSound, transform.position);
            }
            Destroy(gameObject);
        }
    }
}
