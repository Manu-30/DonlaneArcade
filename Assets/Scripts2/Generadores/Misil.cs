using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour
{
    public float timer = 2;
    public float velocidad = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoBala();
    }


    void MovimientoBala()
    {

        timer -= Time.deltaTime;

        
        transform.position += new Vector3(-velocidad * Time.deltaTime, 0, 0);

        if (timer <= 0)
        {
            Destroy(gameObject);
        }

    }
}
