using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    public GameObject target;
    private SpriteRenderer spriteRender;
    public float enemyHealth = 3f;
    public Sprite damage1;
    public Sprite damage2;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public GameObject enemyProjectile;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;

    }

    private void Update()
    {
        Vector2 lookTarget = target.transform.position - transform.position;
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance &&
                 Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            if (enemyHealth == 1)
            {
                Destroy(this.gameObject);
            }
            else if (enemyHealth == 2)
            {
                spriteRender.sprite = damage2;
            }
            else if (enemyHealth == 3)
            {
                spriteRender.sprite = damage1;
            }

            enemyHealth--;
        }

    }
}


