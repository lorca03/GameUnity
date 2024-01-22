using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerController.Restar_Vida(40);
        }
    }
}
