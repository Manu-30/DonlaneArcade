using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MGameOver : MonoBehaviour
{
    public float velocidad = 5;
    public float timer = 3;

    public GameObject prefabBoss;
    
    public GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(prefabBoss==null)
        {
            gameController.tag = "muerto";
            Velocidad();
        }
        
    }

    void Velocidad()
    {
        if (transform.position.y >= 1)
            transform.position += new Vector3(0, -velocidad * Time.deltaTime, 0);
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene("Título");
                }

            }
        }
    }
}
