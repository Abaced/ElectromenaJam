using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public PlayerAttack[] Attacks;

    public float MaxLife;
    public float CurrentLife;

    public Player Ennemy;
    public Slider SliderPV;

    public Vector3 rotation;
    private int speed = 1;
    public int savespeed = 5;
    private Vector2 PlayerDirection;
    private Rigidbody2D rb;

    Vector3 lastVelocity;

    public GameObject recul;
    Vector3 reculdir;

    public float Fast = 0.0001f;

    public float SlimeFast = 0.5f;
    public float SlimeFastSave =1f;
    public bool Isbumping;
    public float HiverTime = 10f;
    
    private GameObject Frig;

    //private bool Hiver = false;


    void Awake()
    {
        speed = savespeed;
        CurrentLife = MaxLife;
        SliderPV.value = (float)CurrentLife / (float)MaxLife;

        rb = GetComponent<Rigidbody2D>();

        float directionY = 2;
        float directionX = 2;

        PlayerDirection = new Vector2(directionX, directionY).normalized;



    }

    void Update()
    {
        rb.velocity = new Vector2(PlayerDirection.x * speed, PlayerDirection.y * speed);
        this.transform.Rotate(rotation * 1 * Time.deltaTime);
        lastVelocity = rb.velocity;

        reculdir = recul.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Slime")
        {
            StartCoroutine(Slimespeed());

            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);
            PlayerDirection = direction;
            rb.velocity = direction * Mathf.Max(speed, 0f);
        }
        if (coll.gameObject.tag == "Frigo")
        {
            Frig = coll.gameObject;
            Frig.SetActive(false);
            StartCoroutine(Winter());
        }
        else //(Hiver == false)
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);
            PlayerDirection = direction;

            rb.velocity = direction * Mathf.Max(speed, 0f);
        }
        
    }

    /*public void TakeDamage(float damage)
    {
        this.SetLife(this.CurrentLife - damage);
    }*/
    public void TakeDamage(float damage)
    {
        CurrentLife -= damage;
        SliderPV.value = (float)CurrentLife / (float)MaxLife;
        if (CurrentLife <= 0)
        {

            gameObject.SetActive(false);
        }
    }


    private void SetLife(float life)
    {
        //this.CurrentLife = Mathf.Clamp(life, 0f, this.MaxLife);
        SliderPV.value = CurrentLife / MaxLife;
    }

    public void Recul()
    {
        PlayerDirection = recul.transform.position - transform.position;
        StartCoroutine(Speed());
    }

    IEnumerator Speed()
    {
        speed = 20;
        yield return new WaitForSeconds(Fast);
        speed = savespeed;
    }

    IEnumerator Slimespeed()
    {

        SlimeFast = SlimeFastSave;
        speed = 25;
        if (Isbumping == true)
        {
            SlimeFast = SlimeFast + 0.5f;
        }

        /*else
        {
            speed = 2;
        }*/
        Isbumping = true;
        yield return new WaitForSeconds(SlimeFast);
        speed = savespeed;
        Isbumping = false;
    }

    IEnumerator Winter()
    {
        speed = 1;
        this.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 224, 255);
        yield return new WaitForSeconds(HiverTime);
        this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        speed = savespeed;
        yield return new WaitForSeconds(10f);
        Frig.SetActive(true);
    }
}