using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    private bool Player1Ready;
    private bool Player2Ready;
    public Image Titre;
    public Image Gaufre;
    public Image Toast;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            Player1Ready = true;
            Toast.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }

        if (Input.GetKey("b"))
        {
            Player2Ready = true;
            Gaufre.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }

        if (Player1Ready == true && Player2Ready == true)
        {
            StartCoroutine(Title());

        }

        if ((Input.GetKey("a")) && Player1Ready == true && Player2Ready == true)
        {
            StartCoroutine(Launch());
        }
    }

    IEnumerator Title()
    {
        yield return new WaitForSeconds(1f);
        Titre.GetComponent<Image>().color = new Color32(255, 255, 225, 250);
    }

    IEnumerator Launch()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }

}
