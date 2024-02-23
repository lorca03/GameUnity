using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosGlobales : MonoBehaviour
{
    public GameObject objetosEscenas;
    public GameObject objetoOpciones;
    // Start is called before the first frame update
    void Start()
    {
        objetosEscenas = GameObject.FindGameObjectWithTag("ObjetosEscenas");
        objetoOpciones = objetosEscenas.transform.Find("Canvas").Find("BotonesOpciones").gameObject;
    }

    public void MostrarOpciones(bool muestra)
    {
        objetoOpciones.SetActive(muestra);
    }
}
