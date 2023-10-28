using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowbowl : MonoBehaviour
{

    public GameObject snowball;
    public Transform snowPoint;
    private bool snow;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e") && snow != false)
        {
            Instantiate(snowball, snowPoint.position, snowPoint.transform.rotation);
            snow = false;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);
        snow = true;
    }
}
