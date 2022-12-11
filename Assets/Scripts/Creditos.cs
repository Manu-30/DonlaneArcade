using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Texto;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }
    public void Movimiento()
	{
        Texto.transform.position += new Vector3(0, 40 * Time.deltaTime, 0);
    }
}
