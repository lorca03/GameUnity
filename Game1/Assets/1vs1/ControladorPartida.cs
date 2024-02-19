using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControladorPartida : MonoBehaviour
{
    [SerializeField] int muertes1 = 0;
    [SerializeField] int muertes2 = 0;
    public GameObject jugador1;
    public GameObject jugador2;
    public TextMeshProUGUI texto1;
    public TextMeshProUGUI texto2;
    public GameObject menuGanador;
    public TextMeshProUGUI textoGanador;

    public int Muertes1
    {
        get => muertes1;
        set
        {
            try
            {
                muertes1++;
                if (muertes1 == 3)
                {
                    Debug.Log("Gana el jugador 2");
                    textoGanador.text = "2";
                    textoGanador.color = Color.red;
                    menuGanador.SetActive(true);
                }
                texto2.text = muertes1.ToString();
                ReiniciarPosiciones();
                jugador1.GetComponent<PlayerController_2>().i_vida = 100;
                jugador1.GetComponent<PlayerController_2>().Actualizar_Barra();
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Error al reiniciar posiciones");
                throw;
            }
        }
    }
    public int Muertes2
    {
        get => muertes2;
        set
        {
            muertes2++;
            if (muertes2 == 3)
            {
                Debug.Log("Gana el jugador 1");
                textoGanador.text = "1";
                textoGanador.color = new Color(0, 247, 249);
                menuGanador.SetActive(true);
            }
            texto1.text = muertes2.ToString();
            ReiniciarPosiciones();
            jugador2.GetComponent<PlayerController_2>().i_vida = 100;
            jugador2.GetComponent<PlayerController_2>().Actualizar_Barra();
        }
    }

    void ReiniciarPosiciones()
    {
        CharacterController controller1 = jugador1.GetComponent<CharacterController>();
        if (controller1 != null)
        {
            controller1.enabled = false;
            jugador1.transform.position = new Vector3(-32.98f, 16f, 45.2f);
            jugador1.GetComponent<MovimientoPlayer_2>().v3_moveDirection.y = 0;
            controller1.enabled = true;
        }

        CharacterController controller2 = jugador2.GetComponent<CharacterController>();
        if (controller2 != null)
        {
            controller2.enabled = false;
            jugador2.transform.position = new Vector3(-2.98f, 16f, 45.2f);
            jugador2.GetComponent<MovimientoPlayer_2>().v3_moveDirection.y = 0;
            controller2.enabled = true;
        }
        ReiniciarBoomerangs();
    }

    void ReiniciarBoomerangs()
    {
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Boomerang");

        foreach (GameObject clone in clones)
        {
            if (clone.name.Contains("(Clone)"))
            {
                clone.GetComponent<BoomerangController_2>().AcabarBoomerang();
            }
        }
    }
}
