using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoySmallCube : MonoBehaviour
{
    public GameObject smoke_fx;
    public AudioClip explode_sound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack_Trigger"))
        {
            Instantiate(smoke_fx, transform.position, transform.rotation);
            if (explode_sound)
            {
                AudioSource.PlayClipAtPoint(explode_sound, transform.position);
            }
            Destroy(gameObject);
        }
    }
}
