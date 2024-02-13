using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBoss : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetComponentInChildren<BoomerangController>().b_teleport == false)
        {
            Debug.Log("Player hit by sword");
            other.GetComponent<PlayerController>().Restar_Vida(20);
        }
    }
}
