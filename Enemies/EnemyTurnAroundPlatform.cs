using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnAroundPlatform : MonoBehaviour
{
    public float move_speed;
    public GameObject[] points;
    public float distance_enemy_point;

    int next_point = 1;
    float distance_to_point; //Distance remaining between player and the next point
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        distance_to_point = Vector2.Distance(transform.position, points[next_point].transform.position);
        transform.position = Vector2.MoveTowards(transform.position, points[next_point].transform.position, move_speed * Time.deltaTime);
        if(distance_to_point < distance_enemy_point)
        {
            EnemyTurn();
        }
    }

    void EnemyTurn()
    {
        Vector3 current_rotation = transform.eulerAngles;
        current_rotation.z = points[next_point].transform.eulerAngles.z;
        transform.eulerAngles = current_rotation;
        ChooseNextPoint();
    }

    void ChooseNextPoint()
    {
        next_point++;
        if(next_point == points.Length)
        {
            next_point = 0;
        }
    }
}
