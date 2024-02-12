using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VidasMulti : MonoBehaviour
{
    public GameObject controladorPartida;
    ControladorPartida contrPartida;

    // Start is called before the first frame update
    void Start()
    {
        contrPartida = controladorPartida.GetComponent<ControladorPartida>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MuerteMulti(int i_vida, GameObject player)
    {
        if (i_vida <= 0)
        {
            player.GetComponent< PlayerInput>().SwitchCurrentActionMap("NoMove");
            if (player.name == "Chc_Personaje")
            {
                contrPartida.Muertes1++;
            }
            else if (player.name == "Chc_Personaje2")
            {
                contrPartida.Muertes2++;
            }
            //animator.SetBool("Death", true);
            //StartCoroutine(Animacion_Muerte());
        }
    }

    //IEnumerator Animacion_Muerte()
    //{
    //    yield return new WaitForSeconds(5f);
    //    animator.SetBool("Death", false);
    //    menumuerto.SetActive(true);
    //}
}
