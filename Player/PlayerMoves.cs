using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private float player_velocity;
    public bool is_facing_right = true;


    //Jump
    public LayerMask what_is_ground;
    public Transform check_ground;
    public bool is_grounded;
    private float ground_radius = .1f;
    public float jump_force;

    //Attack BASIC

    public GameObject fire_point;
    public float fire_rate;
    private float last_shot = 0f;

    //ATTACK PROJECTILE BASIC
    //public GameObject player_projectile; 
    private GameManager game_manager;
    private Animator animator;



    void Start()
    {
        gameObject.SetActive(true);
        rb2d = GetComponent<Rigidbody2D>();
        game_manager = GetComponent<GameManager>();
        //game_manager.LoadGameDatas();
        animator = GetComponent<Animator>();
        
    }

    private void FixedUpdate()
    {
        player_velocity = Input.GetAxisRaw("Horizontal") * speed * Time.fixedDeltaTime;
        //Check player is grounded
        is_grounded = Physics2D.OverlapCircle(check_ground.position, ground_radius, what_is_ground);
    }

    // 60fps
    void Update()
    {
        if(player_velocity > 0f)
        {
            rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
            is_facing_right = true;
            FlipSprite();
        }else if(player_velocity < 0f)
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            is_facing_right = false;
            FlipSprite();
        }
        else
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        }

        //Attack
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > fire_rate + last_shot)
            {
                //Instantiate(player_projectile, fire_point.transform.position, fire_point.transform.rotation);
                animator.SetBool("Attack", true);
                Invoke("StopAttackAnimation", 0.3f);
            }
            last_shot = Time.time;
        }

        //Jump
        if (Input.GetButtonDown("Jump") && is_grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump_force);
        }

        animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
    }

    /**************************************METHODES***********************************/
    public void FlipSprite()
    {
        if (is_facing_right)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    /*************************************ANIMATIONS************************************/
    public void StopAttackAnimation()
    {
        animator.SetBool("Attack", false);
    }

    /**************************************TRIGGER***************************************/
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = collision.transform;
        }
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = null;
        }
    }
}
