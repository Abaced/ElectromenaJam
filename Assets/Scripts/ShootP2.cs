using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootP2 : MonoBehaviour
{

    public Transform ShootingPoint;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    private bool reloading;
    //private float munition;
    //private float munition2;
    //public float maxmun =10;
    //public float maxmun2 =10;
    //public float relmun;

    public Player Player;
    public float reloadTime;

    private float fire;
    private float ice;

    //public Text Mun;
    //public Text Mun2;

    // Start is called before the first frame update
    void Start()
    {
        //    munition = maxmun;
        //    munition2 = maxmun2;
        //    Mun.text = munition.ToString();
        //    Mun2.text = munition2.ToString();
        fire = 0;
        ice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey("d") && !reloading && munition >= 1)
        {
            Instantiate(bulletPrefab, ShootingPoint.position, ShootingPoint.transform.rotation);
            munition -= 1;
            reloading = true;
            Player.Recul();
            Mun.text = munition.ToString();
            StartCoroutine(waitShoot());
        }

        if (Input.GetKey("b") && !reloading && munition2 >= 1)
        {
            Instantiate(bulletPrefab, ShootingPoint.position, ShootingPoint.transform.rotation);
            munition2 -= 1;
            reloading = true;
            Player.Recul();
            Mun2.text = munition2.ToString();
            StartCoroutine(waitShoot());
        }

        if (Input.GetKey("d") && munition <= 0 )
        {
            munition2 = maxmun;
            Mun2.text = munition2.ToString();
        }

        if (Input.GetKey("b") && munition2 <= 0)
        {
            munition = maxmun;
            Mun.text = munition.ToString();

        }*/

        if (Input.GetKey("d"))
        {
            Instantiate(bulletPrefab, ShootingPoint.position, ShootingPoint.transform.rotation);
            reloading = true;
            Player.Recul();

            if(fire != 2)
            {
                fire += 1;
            }
        }
        if (Input.GetKey("b"))
        {
            Instantiate(bulletPrefab2, ShootingPoint.position, ShootingPoint.transform.rotation);
            reloading = true;
            Player.Recul();

            if(ice != 2)
            {
                ice += 1;
            }
        }
        if (ice ==2 && fire == 2)
        {
            Player.Burst(30);
            ice = 0;
            fire = 0;
        }

    }

    IEnumerator waitShoot()
    {
        yield return new WaitForSeconds(reloadTime);
        reloading = false;                           
    }

}
