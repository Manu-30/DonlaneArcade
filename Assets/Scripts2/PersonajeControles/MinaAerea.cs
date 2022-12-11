using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaAerea : MonoBehaviour
{
    public float velocidad = 4;
    public int vida = 5;
    public float timer = 4;
 

    public GameObject prefabExplosion;
    public GameObject soundExplosion;

    void Start()
    {  
        
    }
   
    void Update()
    {
        MovimientoMina();
    }

    void MovimientoMina()
    {
        transform.position += new Vector3(-velocidad * Time.deltaTime, 0, 0);

        timer -= Time.deltaTime;

		if (timer <= 0)
		{
            Destroy(gameObject);
		}
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bala")|| (collision.CompareTag("bala2")))
        {
            vida--;
            Destroy(collision.gameObject);


            if (vida <= 0)
            {
                if (collision.CompareTag("bala"))
                {
                    GlobalVar.puntuacion1 += 100;
                }
                if (collision.CompareTag("bala2"))
                {
                    GlobalVar.puntuacion2 += 100;
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
