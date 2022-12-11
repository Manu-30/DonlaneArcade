using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float velocidad =2;

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
        transform.position += new Vector3(-velocidad*Time.deltaTime,0,0);
    }

    void CamiodePosicion()
    {
        if (transform.position.x <= -6.85)
        {
            transform.position = new Vector3(6.85f, 0.21f, 0.55f);
        }
    }
}
