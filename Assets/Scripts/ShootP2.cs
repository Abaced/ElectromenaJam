using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR;

public class ShootP2 : MonoBehaviour
{

    public Transform ShootingPoint;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    private bool reloading;

    public Player Player;
    public float reloadTime;

    private float fire;
    private float ice;

    public UnityEvent OnShoot;

    private int ajoutRebond;

    private bool bounce;
    private bool munSpeed;
    private bool crit;


    private int randomNumber;
    private int critChance;
    private int projospeed;
    private int critDmg;

    // Start is called before the first frame update
    void Start()
    {
        fire = 0;
        ice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") && !reloading) //FIRE
        {
            Projo projo = Instantiate(bulletPrefab, ShootingPoint.position, ShootingPoint.transform.rotation).GetComponent<Projo>();
            projo.idBullet = 2;

            if (bounce == true)
            {
                projo.rebond = true;
                projo.nbRebond = ajoutRebond;
            }
            if (munSpeed == true)
            {
                projo.speed = projospeed;
            }
            if (crit == true)
            {
                randomNumber = Random.Range(0, 10);
                if (randomNumber <= critChance)
                {
                    Debug.Log("Crit");
                    projo.critdmg = critDmg;
                }
            }

            reloading = true;
            Player.Recul();
            StartCoroutine(waitShoot());
            OnShoot.Invoke();

            if (fire != 2)
            {
                fire += 1;
            }
        }

        if (Input.GetKey("b") && !reloading) //ICE
        {
            Projo projo = Instantiate(bulletPrefab, ShootingPoint.position, ShootingPoint.transform.rotation).GetComponent<Projo>();
            projo.idBullet = 2;

            if (bounce == true)
            {
                projo.rebond = true;
                projo.nbRebond = ajoutRebond;
            }
            if (munSpeed == true)
            {
                projo.speed = projospeed;
            }
            if (crit == true)
            {
                randomNumber = Random.Range(0, 10);
                if (randomNumber <= critChance)
                {
                    Debug.Log("Crit");
                    projo.critdmg = critDmg;
                }
            }

            reloading = true;
            Player.Recul();
            StartCoroutine(waitShoot());
            OnShoot.Invoke();

            if (ice != 2)
            {
                ice += 1;
            }
        }

        if (ice ==2 && fire == 2) // 2FIRE + 2ICE
        {
            Player.Burst(30);
            ice = 0;
            fire = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
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
