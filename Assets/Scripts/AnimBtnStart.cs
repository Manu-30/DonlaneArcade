using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBtnStart : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("seleccionado", GlobalVar.botonSeleccionado);
    }
}
