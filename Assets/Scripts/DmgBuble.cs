using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DmgBuble : MonoBehaviour
{
    public float dmgValue;
    private string dmgTxt;
    public TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dmgTxt = dmgValue.ToString();
        text.text = dmgTxt;
        StartCoroutine(Stop());

    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }

}
