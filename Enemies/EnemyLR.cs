using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLR : MonoBehaviour
{
    float startPosition;
    float endPosition;
    public float moveSpeed;
    public bool moveRight = true;
    public int unitToMove;

    private PlayerMoves player;
 
    //KnockBack Fx

    void Start()
    {

        player = FindObjectOfType<PlayerMoves>();
        startPosition = transform.position.x;
        endPosition = startPosition + unitToMove;
    }


    void Update()
    {
        EnemyMove();

    }
    void EnemyMove()
    {
        if (moveRight && unitToMove >= 1)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (transform.position.x >= endPosition && unitToMove >= 1)
        {
            moveRight = false;
        }
        if (!moveRight && unitToMove >= 1)
        {
            transform.position -= Vector3.right * moveSpeed * Time.deltaTime;

        }
        if (transform.position.x <= startPosition && unitToMove >= 1)
        {
            moveRight = true;
        }
    }
}
