using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Micro : MonoBehaviour
{
    public Transform End;

    void OnTriggerEnter2D(Collider2D truc)
    {
        if (truc.tag == "Player")
        {
            truc.transform.position = End.position;
        }
    }
}
