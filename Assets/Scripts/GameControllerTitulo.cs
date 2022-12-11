using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerTitulo : MonoBehaviour
{
    // Start is called before the first frame update
    public Image BotonStart;
    public Image BotonExit;
    public Image BotonCredits;
    public float contador;
    public float contadorInicio;
    public GameObject[] playerObjects1;
    public float parpadeoTiempo;
    public int seleccion;
    Animator anim;
    void Start()
    {
        contador = contadorInicio;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       seleccion = GlobalVar.botonSeleccionado;
       Selección();
       switch (GlobalVar.botonSeleccionado)

		{
            case 0:
               
                if (Input.GetKeyDown(KeyCode.Return))
				{
                    SceneManager.LoadScene("2Jugadores");
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Exit();
                }
               
                break;
            case 2:
                
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene("Creditos");
                }
                break;
            
		}
         


    }

   

    public void Selección()
	{
        
        if (Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow))
		{
            contador = contadorInicio;
            if (GlobalVar.botonSeleccionado < 2)
            {
                GlobalVar.botonSeleccionado++;
            }
            else if (GlobalVar.botonSeleccionado >= 2)
            {
                GlobalVar.botonSeleccionado = 0;
            }

        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
            if (GlobalVar.botonSeleccionado > 0)
            {
                GlobalVar.botonSeleccionado--;
            }
            else if (GlobalVar.botonSeleccionado <= 0)
            {
                GlobalVar.botonSeleccionado = 2;
            }
        }
    }
    void Exit()
    {
        Application.Quit();
    }
}
