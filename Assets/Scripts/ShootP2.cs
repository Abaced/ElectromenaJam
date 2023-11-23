using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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

    IEnumerator waitShoot()
    {
        yield return new WaitForSeconds(reloadTime);
        reloading = false;                           
    }

}
