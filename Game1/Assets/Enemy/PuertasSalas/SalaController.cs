using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            if (gameObject.name == "SalaBoss")
            {
                GameObject.Find("FondoBarraVidaBoss").GetComponent<Image>().enabled = true;
                GameObject.Find("BarraVidaBoss").GetComponent<Image>().enabled = true;
                Camera.main.GetComponent<CameraController>().f_Velocidad = 10;
                Camera.main.GetComponent<CameraController>().f_Zoom = 15;
                Camera.main.GetComponent<CameraController>().f_yAjustePosicion = 8;
            }
        }
    }

    public void Liberar()
    {
        animator1.SetBool("atrapar", false);
        animator2.SetBool("atrapar", false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name == "SalaBoss")
        {
            GameObject.Find("FondoBarraVidaBoss").GetComponent<Image>().enabled = false;
            GameObject.Find("BarraVidaBoss").GetComponent<Image>().enabled = false;
            Camera.main.GetComponent<CameraController>().f_Velocidad = 20;
            Camera.main.GetComponent<CameraController>().f_Zoom = 20;
            Camera.main.GetComponent<CameraController>().f_yAjustePosicion = 6;
        }
    }
}
