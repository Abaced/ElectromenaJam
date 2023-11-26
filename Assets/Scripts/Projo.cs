using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projo : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public float lifeTime = 5.0f;
    private int id;

    private int rebondCount = 0;
    public int nbRebond;
    public bool rebond;
    private Vector2 bulletDirection;
    Vector3 lastVelocity;

    [HideInInspector] public int idBullet;
    public bool shield;

    // Start is called before the first frame update
    void Start()
    {
        nbRebond = 3;
        Destroy(gameObject, lifeTime);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player Player = collision.GetComponent<Player>();

        if (Player != null)
        {
            int id = collision.GetComponent<Player>().idPlayer;
            Debug.Log(id);

            if (id == idBullet && shield == false)
            {
                Player.TakeDamage(20);
                Destroy(gameObject);
            }
            shield = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        rebondCount = rebondCount + 1;

        if (rebond == true && rebondCount < nbRebond)
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0f);
            Debug.Log(rebondCount);

        }
        else if (rebondCount >= nbRebond)
        {
            Destroy(gameObject);
        }
        else if (rebond == false)
        {
            Destroy(gameObject);
        }
    }
}