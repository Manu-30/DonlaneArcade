using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestruirExplosion();
    }

    void DestruirExplosion()
	{
        timer -= Time.deltaTime;

		if (timer <= 0)
		{
            Destroy(gameObject);
		}
	}
}
