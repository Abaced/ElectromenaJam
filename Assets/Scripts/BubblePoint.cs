using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePoint : MonoBehaviour
{
    private Vector2 Startpos;
    public float X;

    // Start is called before the first frame update
    void Start()
    {
        //Startpos = transform.localPosition;
        X = transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        Startpos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localPosition = new Vector2(-X, 0);
        X = transform.localPosition.x;
    }

}
