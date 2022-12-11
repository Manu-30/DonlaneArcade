using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController2Jugadores : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("Juego");
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GlobalVar.dosJugadores = true;
            }
        }
    }
}
