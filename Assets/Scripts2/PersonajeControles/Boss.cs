using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public float velocidad = 2;
    public float timerDisparo = 3;
    int vida=60;
    private float limitearriba = 1.9f;
    private float limiteabajo = -1.1f;

    public int caso;
    public float timer = 1.5f;
    private bool activado ;

    public GameObject soundExplosion;
    public GameObject prefabExplosion;
    public GameObject prefabMisiles;
    public Transform disparoPosicion;

    BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        bc.enabled = false;
        activado = false;
        if (GlobalVar.dosJugadores)
        {
            vida *= 2;
        }
    }

    // Update is called once per frame
    void Update()
    {

        ColocarPosicion();
    }

    void ColocarPosicion()
    {
        if (GlobalVar.puntuacion1 >= 12000 || GlobalVar.puntuacion2 >= 12000)
        {
            activado = true;
        }

        if (activado == true)
        {
            if (transform.position.x >= 1.3f)
            {

                transform.position += new Vector3(-velocidad * Time.deltaTime, 0, 0);



            }
            bc.enabled = true;
            Disparo();
            Movimiento();
        } 

    }

    void Disparo()
    {
        timerDisparo -= Time.deltaTime;
        disparoPosicion.gameObject.SetActive(false);

        if (timerDisparo <= 0)
        {
            disparoPosicion.gameObject.SetActive(true);

            GameObject clon = Instantiate(prefabMisiles);
            clon.transform.position = disparoPosicion.position;


            timerDisparo = Random.Range(0, 2f);

        }

    }

    void Movimiento()
    {
     
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
                transform.position += new Vector3(0, velocidad * Time.deltaTime, 0);

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
                    GlobalVar.puntuacion1 += 2000;
                }

                if (collision.CompareTag("bala2"))
                {
                    GlobalVar.puntuacion2 += 2000;
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
