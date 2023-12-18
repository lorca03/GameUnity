using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampasController : MonoBehaviour
{
    public int i_da�o = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerController>().Restar_Vida(i_da�o);

        }
    }
}
