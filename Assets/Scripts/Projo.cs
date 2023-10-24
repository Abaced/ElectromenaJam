using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projo : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public float lifeTime = 5.0f;

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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player Player = collision.GetComponent<Player>();

        if (Player != null)
        {
            Player.TakeDamage(20);
        }
        Destroy(gameObject);
    }
}
