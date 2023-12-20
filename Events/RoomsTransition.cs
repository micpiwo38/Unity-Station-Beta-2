using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsTransition : MonoBehaviour
{
    public GameObject virtual_cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {
            virtual_cam.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {
            virtual_cam.SetActive(false);
        }
    }
}
