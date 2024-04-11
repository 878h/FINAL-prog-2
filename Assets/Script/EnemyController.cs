using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{//Script to control enemy, making sure the enemy is following player.
    public float speed = 5f; //basic speed
    public float stoppingDistance = 1f;
    public Transform player;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
          //move to player
            Vector3 direction = (player.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

         //rotate enemy positioning to follow player
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, lookRotation, 360f * Time.fixedDeltaTime));
        }
    }
}

