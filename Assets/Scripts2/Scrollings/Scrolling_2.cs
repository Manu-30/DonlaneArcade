using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Movimiento();
        CamiodePosicion();
    }

    void Movimiento()
    {
        transform.position += new Vector3(-velocidad * Time.deltaTime, 0, 0);
    }

    void CamiodePosicion()
    {
        if (transform.position.x <= -6.5359)
        {
            transform.position = new Vector3(17.4289f, 1.041f, -4f);
            
        }
    }
}
