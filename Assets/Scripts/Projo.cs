using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projo : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public float lifeTime = 5.0f;
    private int id;
    

    private bool rebond;
    private Vector2 bulletDirection;
    Vector3 lastVelocity;

    [HideInInspector] public int idBullet;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(bulletDirection.x * speed, bulletDirection.y * speed);
        lastVelocity = rb.velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player Player = collision.GetComponent<Player>();

        if (Player != null)
        {
            int id = collision.GetComponent<Player>().idPlayer;
            Debug.Log(id);

            if (id == idBullet)
            {
                Player.TakeDamage(20);
            }
        }
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(rebond == true)
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);
            bulletDirection = direction;
        }
        
    }
}