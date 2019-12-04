using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int velocityMagnitude = 1;

    public GameObject bulletPrefab;

    public Rigidbody2D rb;

    public float fireOffset = 0.3f;

    float lastShotTime;
    public float fireRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            movement += new Vector2(0, 1);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            movement += new Vector2(0, -1);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            movement += new Vector2(-1, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            movement += new Vector2(1, 0);
        }

        rb.position += movement * velocityMagnitude * Time.deltaTime;

       
        if (Input.GetMouseButton(0) && lastShotTime + fireRate < Time.time) {
            Fire();
            lastShotTime = Time.time;
        }
    }

    void Fire()
    {
        var aimTransform = transform.Find("Aim");
        var aimAngle = aimTransform.eulerAngles.z * Mathf.Deg2Rad;
        var fireDirection = new Vector2(Mathf.Cos(aimAngle), Mathf.Sin(aimAngle));
        
        var bullet = Instantiate(bulletPrefab, transform.position.ToVector2() + (fireDirection * fireOffset), Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = fireDirection * 5;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var tag = collision.gameObject.tag;
        if(tag == "Enemy") {
            GameFlags.GameOver = true;
        }
    }
}
