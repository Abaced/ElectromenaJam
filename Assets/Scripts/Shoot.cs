using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Shoot : MonoBehaviour
{

    public Transform ShootingPoint;
    public GameObject bulletPrefab;
    private bool reloading;
    private float munition;
    public float maxmun;
    public float relmun;
    public Text Mun;

    public Player Player;
    public float reloadTime;

    public UnityEvent OnShoot;

    private int ajoutRebond;

    private bool bounce;
    private bool munSpeed;
    private bool crit;


    private int randomNumber;
    public int critChance;
    private int projospeed;
    public int critDmg;
    private int dmgTotal;

    // Start is called before the first frame update
    void Start()
    {
        bounce = false;
        munSpeed = false;
        crit = false;
        munition = maxmun;
        Mun.text = munition.ToString();
        ajoutRebond = 0;
        critChance = 0;
        projospeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") && !reloading && munition >= 1)
        {

            Projo projo = Instantiate(bulletPrefab, ShootingPoint.position, ShootingPoint.transform.rotation).GetComponent<Projo>();
            projo.idBullet = 1;

            if (bounce == true)
            {
                projo.rebond = true;
                projo.nbRebond = ajoutRebond;
            }
            if (munSpeed == true)
            {
                projo.speed = projospeed ;
            }
            if (crit == true)
            {
                randomNumber = Random.Range(0, 10);
                if (randomNumber <= critChance)
                {
                    Debug.Log("Crit");
                    projo.critdmg =  critDmg;
                }
            }
            OnShoot.Invoke();
            munition -= 1;
            reloading = true;
            Player.Recul();
            Mun.text = munition.ToString();
            StartCoroutine(waitShoot());
        }

        if (Input.GetKey("c") && munition != maxmun )
        {
            munition += 1;
            Mun.text = munition.ToString();
        }
    }
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "rebond")
        {
            bounce = true;
            ajoutRebond += 1;
            projospeed += 5;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "vitesseTir")
        {
            munSpeed = true;
            reloadTime = -0.2f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "critique")
        {
            crit = true;
            critChance += 2;
            critDmg += 3;
            Destroy(other.gameObject);
        }
    }

    IEnumerator waitShoot()
    {
        yield return new WaitForSeconds(reloadTime);
        reloading = false;                           
    }
}
