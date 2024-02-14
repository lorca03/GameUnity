using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SalaLLaveController : MonoBehaviour
{
    public GameObject llavePrefab;
    public GameObject textoEntrada;
    private bool accionRealizada = false;
    private bool textoUnavez = false;
    private Vector3 ultimaPosicionEnemy;
    public GameObject textoLlaveConse;


    private void Start()
    {
        if (!accionRealizada)
        {
            StartCoroutine(HandleSalaLogicCoroutine());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!textoUnavez)
            {
                textoEntrada.SetActive(true);
                textoUnavez = true;
            }
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
        textoEntrada.SetActive(false);
    }

    private IEnumerator<WaitForSeconds> HandleSalaLogicCoroutine()
    {
        while (!accionRealizada)
        {
            Transform[] hijos = GetChildrenWithName("enemy");

            if (hijos.Length == 1)
            {
                ultimaPosicionEnemy = hijos[0].position;
            }

            if (hijos.Length == 0)
            {
                SoltarLlave(ultimaPosicionEnemy);
                accionRealizada = true;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private Transform[] GetChildrenWithName(string name)
    {
        return transform.Cast<Transform>()
            .Where(hijo => hijo.name.ToLower().Contains(name))
            .ToArray();
    }

    void SoltarLlave(Vector3 positionLlave)
    {
        Debug.Log("¡Llave liberada!");
        Instantiate(llavePrefab, new Vector3(positionLlave.x - 1.5f, positionLlave.y, positionLlave.z), Quaternion.identity);
        textoLlaveConse.SetActive(true);
        StartCoroutine(QuitarTextoConse());
    }

    IEnumerator QuitarTextoConse()
    {
        yield return new WaitForSeconds(2f);
        textoLlaveConse.SetActive(false);
    }
}
