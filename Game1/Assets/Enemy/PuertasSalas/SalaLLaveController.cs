using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SalaLLaveController : MonoBehaviour
{
    public GameObject llavePrefab;
    private bool accionRealizada = false;
    private Vector3 ultimaPosicionEnemy;

    private void Start()
    {
        if (!accionRealizada)
        {
            StartCoroutine(HandleSalaLogicCoroutine());
        }
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
        Debug.Log("�Llave liberada!");
        Instantiate(llavePrefab, new Vector3(positionLlave.x - 1.5f, positionLlave.y, positionLlave.z), Quaternion.identity);
    }
}