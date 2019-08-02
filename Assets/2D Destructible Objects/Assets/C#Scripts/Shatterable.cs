using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatterable : MonoBehaviour, IHittable
{
    public List<Spawner> spawnPoints;

    private SpriteRenderer render;
    private Rigidbody2D rigi;
    [SerializeField] private CircleCollider2D cColli;
    [Range(0.0f, 5.0f), SerializeField] private float radius;
    // Use this for initialization
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        rigi = GetComponent<Rigidbody2D>();
        rigi.gravityScale = 0;
        cColli.radius = 0.1f;
    }

    public void HitReceived()
    {
        Die();
    }

    public void Die()
    {
        render.enabled = false;

        foreach (Spawner spawn in spawnPoints)
        {
            spawn.Spawn();
        }

        Destroy(gameObject,0.1f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                rigi.gravityScale = 1;
            }
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            Enemy.searchTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            rigi.gravityScale = 0;
            Die();
            cColli.radius = radius;
        }
        /*else if(collision.gameObject.tag == "Enemy")
        {
            Enemy.searchTrigger = true;
            
        }*/
    }
    
}
