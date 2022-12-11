using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float timer = 2;
    public float velocidad = 6;

   
    void Start()
    {

    }


    void Update()
    {
        MovimientoBala();
    }


    void MovimientoBala()
    {

        timer -= Time.deltaTime;

        transform.position += new Vector3(velocidad * Time.deltaTime, 0, 0);

        if (timer <= 0)
        {
            Destroy(gameObject);
        }

    }

}
