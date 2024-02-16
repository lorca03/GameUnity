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
            muertes1++; 
            if (muertes1 == 3)
            {
                Debug.Log("Gana el jugador 2");
                textoGanador.text = "2";
                menuGanador.SetActive(true);
            }
            texto2.text = muertes1.ToString();
            ReiniciarPosiciones();
            jugador1.GetComponent<PlayerController_2>().i_vida = 100;
            jugador1.GetComponent<PlayerController_2>().Actualizar_Barra();
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
        try
        {
            Debug.Log("Reiniciando posiciones");
            jugador1.transform.position = new Vector3(-32.98f, 16f, 45.2f);
            jugador2.transform.position = new Vector3(-2.98f, 16f, 45.2f);
        }
        catch (System.Exception)
        {
            System.Console.WriteLine("Error al reiniciar posiciones");
            throw;
        }

        
    }    
}
