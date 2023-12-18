using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasadizoController : MonoBehaviour
{
    bool b_activo = true;
    GameObject trampa;
    float intervalo = 1f;

    // Start is called before the first frame update
    void Start()
    {
        trampa = transform.Find("Trampa").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("CambiarVisibilidad", 0, intervalo);
        }
    }

    void CambiarVisibilidad()
    {
        Debug.Log(b_activo);
        b_activo = !b_activo;
        trampa.SetActive(b_activo);
        Debug.Log(b_activo);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CancelInvoke("CambiarVisibilidad");
            b_activo = true;
        }
    }
}