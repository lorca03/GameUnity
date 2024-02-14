using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LlaveController : MonoBehaviour
{
    PremiosController premiosController;

    private void Start()
    {
        premiosController = GameObject.FindGameObjectWithTag("Player").GetComponent<PremiosController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            premiosController.AñadirHabilidad("Llave");
            
            Destroy(gameObject);
        }
    }
}
