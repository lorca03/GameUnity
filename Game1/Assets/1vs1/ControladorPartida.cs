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
            jugador1.GetComponent<PlayerController>().i_vida = 100;
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
            //ReiniciarPosiciones();
            jugador2.GetComponent<PlayerController>().i_vida = 100;
        }
    }

    void ReiniciarPosiciones()
    {
        Debug.Log("Reiniciando posiciones");
        jugador1.transform.position = Vector3.MoveTowards(jugador1.transform.position, new Vector3(-31, 14f, 45.2f), Time.deltaTime * 30);
        //jugadores[0].transform.position = new Vector3(-31, 14f, 45.2f); Debug.Log(jugadores[0].transform.position);
        //jugadores[1].transform.position = new Vector3(-1.68f, 14f, 45.2f);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
