using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float timerMina = 1;
    public float timerEspera = 5;
    public float timerRevivir_1 = 3;
    public float timerRevivir_2 = 3;
    public float timerEnemigo = 5;

    bool saved;

    


    public GameObject jugador2;
    public GameObject jugador1;
    public GameObject prefabMina;
    public GameObject prefabEnemigos;

    GameObject clon;
    GameObject clon2;
    GameObject clon3;
    GameObject clon4;

    public Image caritAzul;
    public Image bolitAzul1;
    public Image bolitAzul2;
    public Image bolitAzul3;

    public Text puntos1;
    public Text puntos2;
    public Text tabla;
    void Start()
    {
        GlobalVar.puntuacion1 = 0;
        GlobalVar.puntuacion2 = 0;

        caritAzul.enabled = true;
        bolitAzul1.enabled = true;
        bolitAzul2.enabled = true;
        bolitAzul3.enabled = true;
        puntos2.enabled = true;

        tag = "GameController";

        tabla.enabled = false;
        saved = false;

        if (GlobalVar.dosJugadores)
        {
             clon2 = Instantiate(jugador2);
            clon2.transform.position = new Vector3(-1.65f, -0.441f, -7.5f);
        }

        clon = Instantiate(jugador1);
        clon.transform.position = new Vector3(-1.65f,  0.632f, -7.5f);

        


    }

    // Update is called once per frame
    void Update()
    {
        if (tag != "muerto")
        {


            timerEspera -= Time.deltaTime;

            if (timerEspera <= 0)
            {
                SpawnerMina();
                SpawnerEnemigos();
                Revivir();

            }

            ReloadHUD();
        }
        else if (tag == "muerto" && !saved)
        {
            ReloadHUD();
            SaveData();
            TablaRecords();
            Destroy(clon3);
            Destroy(clon4);
        }

    }

    void SpawnerMina()
    {
        timerMina -= Time.deltaTime;

        if (timerMina <= 0)
        {
            float y = Random.Range(-1.5f, 1.5f);
            clon3 = Instantiate(prefabMina);

            clon3.transform.position = new Vector3(3, y, -18);
            timerMina = Random.Range(1, 2.5f);
        }

    }
    void SpawnerEnemigos()
    {
        timerEnemigo -= Time.deltaTime;
        if (timerEnemigo <= 0)
        {
            float y = Random.Range(-2.5f, 2.5f);
            clon4 = Instantiate(prefabEnemigos);
            timerEnemigo = Random.Range(5, 8);

        }
    }
    void ReloadHUD()
    {
        puntos1.text = "" + GlobalVar.puntuacion1;
        puntos2.text = "" + GlobalVar.puntuacion2;

        if (!GlobalVar.dosJugadores)
        {
            puntos2.enabled = false;
            caritAzul.enabled = false;
            bolitAzul1.enabled = false;
            bolitAzul2.enabled = false;
            bolitAzul3.enabled = false;
        }
    }
    void LoadData()
    {
        for (int i = 0; i < GlobalVar.records.Length; i++)
        {
            if (PlayerPrefs.HasKey("records" + i))
            {
                GlobalVar.records[i] = PlayerPrefs.GetInt("records" + i);
            }
            else
            {
                PlayerPrefs.SetInt("records" + i, GlobalVar.records[i]);
            }
        }

    }
    void SaveData()
    {
        
        for (int i = 0; i < GlobalVar.records.Length; i++)
        {
            if (GlobalVar.puntuacion1 > GlobalVar.records[i])
            {

                for (int e = 4; e > i; e--)
                {
                    GlobalVar.records[e] = GlobalVar.records[e - 1];
                }

                GlobalVar.records[i] = GlobalVar.puntuacion1;

                

                i = GlobalVar.records.Length;
            }
        }
        for (int i = 0; i < GlobalVar.records.Length; i++)
        {
            if (GlobalVar.puntuacion2 > GlobalVar.records[i])
            {

                for (int e = 4; e > i; e--)
                {
                    GlobalVar.records[e] = GlobalVar.records[e - 1];
                }

                GlobalVar.records[i] = GlobalVar.puntuacion2;

                

                i = GlobalVar.records.Length;
            }
        }


        for (int i = 0; i < GlobalVar.records.Length; i++)
        {
            PlayerPrefs.SetInt("records" + i, GlobalVar.records[i]);
        }
        //Print para comprobar
        for (int i = 0; i < GlobalVar.records.Length; i++)
        {
            print(GlobalVar.records[i]);
        }
        print(GlobalVar.puntuacion1);
        print(GlobalVar.puntuacion2);

        saved = true;
    }

    void Revivir()
    {
        
        if (clon == null)
        {
            timerRevivir_1-= Time.deltaTime;
            if (timerRevivir_1 <= 0)
            {
                clon = Instantiate(jugador1);

                clon.transform.position = new Vector3(-1.65f, 0.632f, -7.5f);
                timerRevivir_1 = 3;
            }
        }

        if (clon2 == null&&GlobalVar.dosJugadores)
        {
            timerRevivir_2 -= Time.deltaTime;
            if (timerRevivir_2 <= 0)
            {
                clon2 = Instantiate(jugador2);

                clon2.transform.position = new Vector3(-1.65f, -0.441f, -7.5f);
                timerRevivir_2 = 3;
            }
        }

    }
    void TablaRecords()
    {
        tabla.enabled = true;
        tabla.text = GlobalVar.records[0] + "\n"+ GlobalVar.records[1] + "\n"+GlobalVar.records[2] + "\n"+GlobalVar.records[3] + "\n"+GlobalVar.records[4] + "\n";
    }
}
