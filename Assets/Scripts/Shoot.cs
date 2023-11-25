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

    // Start is called before the first frame update
    void Start()
    {
        munition = maxmun;
        Mun.text = munition.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") && !reloading && munition >= 1)
        {

            Projo projo = Instantiate(bulletPrefab, ShootingPoint.position, ShootingPoint.transform.rotation).GetComponent<Projo>();
            projo.idBullet = 1;
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
            bulletPrefab.GetComponent<Projo>().rebond = true;
            bulletPrefab.GetComponent<Projo>().nbRebond += 1 ;
        }
        if (other.gameObject.tag == "vitesseTir")
        {

        }
        if (other.gameObject.tag == "shield")
        {

        }
        if (other.gameObject.tag == "tripleTir")
        {

        }
        if (other.gameObject.tag == "critique")
        {

        }
    }

    IEnumerator waitShoot()
    {
        yield return new WaitForSeconds(reloadTime);
        reloading = false;                           
    }

}
