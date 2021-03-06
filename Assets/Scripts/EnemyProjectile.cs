﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Transform player;

    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }

    private void OnCollision2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            DestroyProjectile();
        }

        if (other.gameObject.tag == "wall")
        {
            DestroyProjectile();
        }
    }
}