using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLetras : MonoBehaviour
{
    public float velocidad = 2;
    public float timer = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Velocidad();
    }

    void Velocidad()
    {
        if (transform.position.x >= 0.15)
            transform.position += new Vector3(-velocidad * Time.deltaTime, 0, 0);
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    
}
