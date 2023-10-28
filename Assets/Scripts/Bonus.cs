using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] GameObject[] bonusPrefab;

    [SerializeField] float secondSpawn = 0.5f;

    [SerializeField] float minTras;

    [SerializeField] float maxTras;


    void Start()
    {
        StartCoroutine(BonusSpawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator BonusSpawn()
    {
        while(true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(bonusPrefab[Random.Range(0, bonusPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }

    }
}
