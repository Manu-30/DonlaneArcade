using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class P2_Player : MonoBehaviour
{
    public float velocidad = 3;
    public float timer = 0.1f;
    public int vida = 3;

    public bool rotacionD = false;
    public bool rotacionU = false;
    
    Animator anim;
    Rigidbody2D rb;
   
    public GameObject prefabBala;
    public GameObject prefabExplosion;
    public GameObject soundBala;
    public GameObject soundExplosion;
    public Transform puntoDisparo;

    
    void Start()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }


    void Update()
    {
        MovimientoPersonaje();
        SpawnBala();
        
    }


    void MovimientoPersonaje()
    {

        float y = Input.GetAxis("Vertical1"); //GetAxis para movimiento vertical
        float x = Input.GetAxis("Horizontal1");//GetAxis para movimiento horizontal

        rb.velocity = new Vector2(x * velocidad, y * velocidad); //Asignamos la velocidad a cada vector


        if (Input.GetKey(KeyCode.W))
        {
            rotacionU = true;
            anim.SetBool("up", rotacionU);
        
        }
        else
        {
            rotacionU = false;
            anim.SetBool("up", rotacionU);
        }


        if (Input.GetKey(KeyCode.S))
        {
            rotacionD = true;
            anim.SetBool("down", rotacionD);

        }
        else
        {
            rotacionD = false;
            anim.SetBool("down", rotacionD);
        }
    }
    

    void SpawnBala()
    {
        if (Input.GetKey(KeyCode.U))
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Instantiate(soundBala);
                GameObject clon;
                clon = Instantiate(prefabBala);
                clon.transform.position = puntoDisparo.transform.position;
                clon.tag = "bala2";

                timer = 0.1f;
            }
            puntoDisparo.gameObject.SetActive(true); 
        }
        else
        {
            puntoDisparo.gameObject.SetActive(false);
        }  
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("mina") || collision.CompareTag("balaene") || collision.CompareTag("misil"))
        {
            vida--;
            Destroy(collision.gameObject);

            if (vida <= 0)
            {
                Destroy(gameObject);

                GlobalVar.puntuacion2 -= 1000;
                if (GlobalVar.puntuacion2 <= 0)
                {
                    GlobalVar.puntuacion2 = 0;
                }
                Instantiate(soundExplosion);
                GameObject clon = Instantiate(prefabExplosion);
                clon.transform.position = transform.position;

            }

        }
    }
}
