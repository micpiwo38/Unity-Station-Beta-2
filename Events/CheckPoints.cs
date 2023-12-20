using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoints : MonoBehaviour
{
  
    private Animator animator;
    private GameManager game_manager;
    public GameObject save_text;
    private GameObject player;

    public string the_scene_name_to_load;

    void Start()
    {
        game_manager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
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
            game_manager.SaveGameDatas();
            player.SetActive(false);
            Instantiate(save_text, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);       
            animator.SetBool("IsOn", true);
            Invoke("StopSaveAnimation", 1f);
        }
    }

    void StopSaveAnimation()
    {
        animator.SetBool("IsOn", false);
        SceneManager.LoadScene(the_scene_name_to_load);    
    }
}
