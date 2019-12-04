using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public GameObject self;
    public int velocity;
    public Rigidbody2D rb;

    Vector2 spawnLocation;
    float range = 10f;

    void Start()
    {
        spawnLocation = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        var currPosition = new Vector2(transform.position.x, transform.position.y);
        if (Vector2.Distance(spawnLocation, currPosition) > range) {
            Destroy(self);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Projectile") {
            Destroy(self);
        }
    }
}
