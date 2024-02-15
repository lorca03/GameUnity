using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPartida : MonoBehaviour
{
    [SerializeField] int muertes1 = 0;
    [SerializeField] int muertes2 = 0;
    public GameObject jugador1;
    public GameObject jugador2;

    public int Muertes1 
    { 
        get => muertes1; 
        set 
        {
            muertes1 = value; 
            if (muertes1 == 3)
            {
                Debug.Log("Gana el jugador 2");
            }
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
            muertes2 = value;
            if (muertes2 == 3)
            {
                Debug.Log("Gana el jugador 1");
            }
            ReiniciarPosiciones();
            jugador2.GetComponent<PlayerController_2>().i_vida = 100;
            jugador2.GetComponent<PlayerController_2>().Actualizar_Barra();
        }
    }

    void ReiniciarPosiciones()
    {
        Debug.Log("Reiniciando posiciones");
        jugador1.transform.position = new Vector3(-31, 14f, 45.2f);
        jugador2.transform.position = new Vector3(-1.68f, 14f, 45.2f);
    }    
}
