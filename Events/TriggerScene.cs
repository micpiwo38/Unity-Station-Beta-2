using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerScene : MonoBehaviour
{
    public string the_scene_name_to_load;
    private GameManager gameManager;
    public GameObject player;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(the_scene_name_to_load);
            player.transform.position = new Vector3(-8, -3, 0);
        }
    }
}
