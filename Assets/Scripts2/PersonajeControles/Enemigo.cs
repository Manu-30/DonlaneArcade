using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida = 7;
    public float velocidad = 3f;
    private float limitearriba = 1.7f;
    private float limiteabajo = -1.7f;
   
    public int caso;
    public float timer=1.5f;
    public float timerDisparo = 2;

    public GameObject soundController;
    public GameObject prefabBalaEnemiga;
    public GameObject prefabExplosion;
    public Transform disparoPosicion;
    public GameObject soundExplosion;
    
    void Start()
    {
		if (GlobalVar.dosJugadores)
		{
            vida *= 2;
		}
    }

    
    void Update()
    {
        IA();      
    }


    void ColocarPosicionInicial()
    {
        if (transform.position.x >= 1.7)
        {
            transform.position += new Vector3(-velocidad * Time.deltaTime, 0, 0);
        }
        else
        {

        }

    }


    void Disparo()
    {
        timerDisparo -= Time.deltaTime;
        disparoPosicion.gameObject.SetActive(false);

        if (timerDisparo <= 0)
        {
            disparoPosicion.gameObject.SetActive(true);

            GameObject clon = Instantiate(prefabBalaEnemiga);
            clon.transform.position = disparoPosicion.position;
            Instantiate(soundController);

            timerDisparo = Random.Range(0, 2f);
                               
        }
        
    }


    void IA()
    {
        ColocarPosicionInicial();

        Disparo();

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            caso = Random.Range(0, 3);
            timer = 1.5f;
        }

        switch (caso)
        {
            case 0: //Parado
                break;

            case 1: //Hacia arriba
                transform.position += new Vector3(0, velocidad *Time.deltaTime,0);

                if (limitearriba < transform.position.y)
                {
                    timer = 2;
                    caso = 2;
                }

                break;

            case 2: //Hacia abajo
                transform.position += new Vector3(0, -velocidad * Time.deltaTime, 0);

                if (limiteabajo > transform.position.y)
                {
                    timer = 1;
                    caso = 1;
                }
                break;
        } 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bala") || collision.CompareTag("bala2"))
        {
            vida--;
            Destroy(collision.gameObject);

            
            if (vida <= 0)
            {
                if (collision.CompareTag("bala"))
                {
                    GlobalVar.puntuacion1 += 200;
                }
                if (collision.CompareTag("bala2"))
                {
                    GlobalVar.puntuacion2 += 200;
                }
                Destroy(gameObject);

                Instantiate(soundExplosion);
                GameObject clon = Instantiate(prefabExplosion);
                clon.transform.position = transform.position;
            }
            else
            {
                if (collision.CompareTag("bala"))
                {
                    GlobalVar.puntuacion1 += 50;
                }
                if (collision.CompareTag("bala2"))
                {
                    GlobalVar.puntuacion2 += 50;
                }
            }
        }
    }
}
