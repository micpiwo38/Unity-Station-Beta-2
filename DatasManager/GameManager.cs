using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameDatas: ThirtySec.Serializable<GameDatas>
{
    public int coins;
    public int health;

   
    public int scenes_number;
    public float pos_x;
    public float pos_y;
    public float pos_z;
}


public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public int player_coins = 0;
    public int player_health = 6;
    public int player_scenes_number;

    public TMP_Text coins_text;
    public Sprite[] health_sprite_array;
    public Image health_image;

    void Start()
    {
        
    }

    public void SaveGameDatas()
    {
        player_scenes_number = SceneManager.GetActiveScene().buildIndex;

        GameDatas.instance.coins = player_coins;
        GameDatas.instance.health = player_health;
        GameDatas.instance.scenes_number = player_scenes_number;

    }

    public void LoadGameDatas()
    {
        player_coins = GameDatas.instance.coins;
        player_health = GameDatas.instance.health;

        //Invoke("LoadSavedScene", 1f);
     
    }

    public void LoadSavedScene()
    {
        SceneManager.LoadScene(player_scenes_number);
    }

    // Update is called once per frame
    void Update()
    {
        //Test Load
        if (Input.GetKey(KeyCode.L))
        {
            LoadGameDatas();
        }
        //Test Write
        if (Input.GetKey(KeyCode.K))
        {
            SaveGameDatas();        
        }
        
        coins_text.text = "X" + player_coins;
        health_image.sprite = health_sprite_array[player_health];
        
    }


    /**********************MEHODES PAR ITEMS************************/
    public void addCoins()
    {
        player_coins++;
    }
}
