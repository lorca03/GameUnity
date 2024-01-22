using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaController : MonoBehaviour
{
    public Animator animator1;
    public Animator animator2;
    private bool atrapado = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !atrapado)
        {
            animator1.SetBool("atrapar", true);
            animator2.SetBool("atrapar", true);

            atrapado = true;
        }
    }

    public void Liberar()
    {
        animator1.SetBool("atrapar", false);
        animator2.SetBool("atrapar", false);
    }
}
