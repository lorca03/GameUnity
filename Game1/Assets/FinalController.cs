using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalController : MonoBehaviour
{
    [SerializeField] PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.ActivarFinish();
        }
    }
}
