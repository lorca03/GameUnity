using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ForceGateController : MonoBehaviour
{
    public GameObject textoLLave;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            textoLLave.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(QuitarTexto());
        }
    }

    IEnumerator QuitarTexto()
    {
        yield return new WaitForSeconds(2f);
        textoLLave.SetActive(false);
    }
}
