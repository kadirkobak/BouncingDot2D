using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Top : MonoBehaviour
{

    private Rigidbody2D topRb;
    private SpriteRenderer topRenderer;
    public float ziplamaGucu;
    public Color color1, color2, color3, color4, color5, color6;
    public Text skorYazisi,rekorYazisi;
    private int skor,rekor;


    void Start()
    {
        topRb = GetComponent<Rigidbody2D>();
        topRenderer = GetComponent<SpriteRenderer>();
        

        if (PlayerPrefs.HasKey("rekor"))
        {
            rekor = PlayerPrefs.GetInt("rekor");
            rekorYazisi.text ="Rekor: "+rekor.ToString();
        }
        else
        {
            rekor = 0;
        }

    }


    private void OnCollisionEnter2D(Collision2D temas)
    {

        if (temas.gameObject.tag=="Zemin")
        {
            topRb.AddForce(Vector2.up * ziplamaGucu/2, ForceMode2D.Impulse);
        }


        
        if (temas.gameObject.tag=="Kenar")
        {

            topRb.AddForce(Vector2.up * ziplamaGucu, ForceMode2D.Impulse);
            

            if (topRenderer.color == temas.gameObject.GetComponent<SpriteRenderer>().color)
            {
                GetComponent<AudioSource>().Play();
                skor+= Random.Range(5, 15);
                skorYazisi.text ="Skor: "+skor.ToString();

                if (skor > rekor)
                {
                    rekor = skor;
                    rekorYazisi.text ="Rekor: "+rekor.ToString();
                    PlayerPrefs.SetInt("rekor", rekor);
                }

            }
            else if (topRenderer.color != temas.gameObject.GetComponent<SpriteRenderer>().color)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }


    }




    private void OnTriggerEnter2D(Collider2D temast)
    {

        if (temast.gameObject.tag=="RenkDegistirici")
        {
            RenkDegistir();
        }


    }

    private void RenkDegistir()
    {

        int rastgele = Random.Range(1, 7);

        switch (rastgele)
        {
            case 1:
                topRenderer.color = color1;
                break;
            case 2:
                topRenderer.color = color2;
                break;
            case 3:
                topRenderer.color = color3;
                break;
            case 4:
                topRenderer.color = color4;
                break;
            case 5:
                topRenderer.color = color5;
                break;
            case 6:
                topRenderer.color = color6;
                break;
        }

    }


}
