using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject self;

    void OnCollisionEnter2D(Collision2D collision)
    {
        var tag = collision.gameObject.tag;
        if (tag == "Projectile" || tag == "Player") {
            Destroy(self);
        }
    }
}
