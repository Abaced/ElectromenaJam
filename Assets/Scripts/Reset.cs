using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{

    public GameObject PanelJ1;
    public GameObject PanelJ2;
    public Player Player1;
    public Player Player2;
    private float vieJ1 = 100;
    private float vieJ2 = 100;
    //public AudioSource Musiquefin;
    public GameObject Musique;

    // Start is called before the first frame update
    void Start()
    {
        vieJ1 = Player1.CurrentLife;
        vieJ2 = Player2.CurrentLife;
        StartCoroutine(Musiqueloop());
    }

    // Update is called once per frame
    void Update()
    {
        vieJ1 = Player1.GetComponent<Player>().CurrentLife;
        vieJ2 = Player2.GetComponent<Player>().CurrentLife;

        if (vieJ1 <= 0)
        {
            //Musiquefin.Play();
            Musique.SetActive(false);
            PanelJ2.SetActive(true);
            if (Input.GetKey("a"))
            {
                SceneManager.LoadScene(0);
            }
            StartCoroutine(Menu());

        }

        if (vieJ2 <= 0)
        {
            //Musiquefin.Play();
            Musique.SetActive(false);
            PanelJ1.SetActive(true);
            if (Input.GetKey("a"))
            {
                SceneManager.LoadScene(0);
            }
            StartCoroutine(Menu());

        }
    }

    IEnumerator Menu()
    {
        yield return new WaitForSeconds(52f);
        SceneManager.LoadScene(0);
    }

    IEnumerator Musiqueloop()
    {
        yield return new WaitForSeconds(4f);
        Musique.SetActive(true);
    }
}
