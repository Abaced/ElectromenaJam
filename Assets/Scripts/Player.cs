using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public PlayerAttack[] Attacks;

    public float MaxLife;
    public float CurrentLife;

    public Player Ennemy;
    public Slider SliderPV;
    [SerializeField]private Material _lifeMaterial;
    private int _percentage = Shader.PropertyToID("_Slider");

    public Vector3 rotation;
    private int speed = 1;
    public int savespeed = 5;
    private Vector2 PlayerDirection;
    private Rigidbody2D rb;

    Vector3 lastVelocity;

    public GameObject recul;
    Vector3 reculDir;

    public float fast = 0.0001f;

    public float slimeFast = 0.5f;
    public float slimeFastSave =1f;
    public bool isBumping;
    public float hiverTime = 10f;
    
    private GameObject Frig;


    public UnityEvent OnTakeDamage;
    
    public int idPlayer; 
    
    void Awake()
    {
        speed = savespeed;
        CurrentLife = MaxLife;
        _lifeMaterial.SetFloat(_percentage, (float)CurrentLife / (float)MaxLife);

        rb = GetComponent<Rigidbody2D>();

        float directionY = 2;
        float directionX = 2;

        PlayerDirection = new Vector2(directionX, directionY).normalized;



    }

    void Update()
    {
        rb.velocity = new Vector2(PlayerDirection.x * speed, PlayerDirection.y * speed);
        transform.Rotate(rotation * 1 * Time.deltaTime);
        lastVelocity = rb.velocity;

        reculDir = recul.transform.position;
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

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "snowBall")
        {
            StartCoroutine(Winter());
        }
    }

    public void TakeDamage(float damage)
    {
        OnTakeDamage.Invoke();
        CurrentLife -= damage;
        _lifeMaterial.SetFloat(_percentage, (float)CurrentLife / (float)MaxLife);
        if (CurrentLife <= 0)
        {

            gameObject.SetActive(false);
        }
    }

    public void Burst(float burst)
    {
        CurrentLife -= burst;
        SliderPV.value = (float)CurrentLife / (float)MaxLife;
        if (CurrentLife <= 0)
        {

            gameObject.SetActive(false);
            SliderPV.value = (float)CurrentLife / (float)MaxLife;

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
        yield return new WaitForSeconds(fast);
        speed = savespeed;
    }

    IEnumerator Slimespeed()
    {

        slimeFast = slimeFastSave;
        speed = 25;
        if (isBumping == true)
        {
            slimeFast = slimeFast + 0.5f;
        }

        isBumping = true;
        yield return new WaitForSeconds(slimeFast);
        speed = savespeed;
        isBumping = false;
    }

    IEnumerator Winter()
    {
        speed = 1;
        this.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 224, 255);
        yield return new WaitForSeconds(hiverTime);
        this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        speed = savespeed;
        yield return new WaitForSeconds(10f);
        Frig.SetActive(true);
    }
}