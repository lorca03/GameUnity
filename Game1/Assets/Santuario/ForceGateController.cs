using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ForceGateController : MonoBehaviour
{
    public GameObject textoLlave;
    public PremiosController premiosController;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (premiosController.habilidadesPersonaje.Contains("Llave"))
            {
                animator.enabled = true;
            }
            else
            {
                textoLlave.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !premiosController.habilidadesPersonaje.Contains("Llave"))
        {
            StartCoroutine(QuitarTexto());
        }
    }

    IEnumerator QuitarTexto()
    {
        yield return new WaitForSeconds(2f);
        textoLlave.SetActive(false);
    }
}
