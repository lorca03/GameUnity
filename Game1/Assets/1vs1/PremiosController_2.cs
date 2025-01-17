using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremiosController_2 : MonoBehaviour
{
    public List<string> habilidadesPersonaje = new List<string>();
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void AņadirHabilidad(string habilidad)
    {
        habilidadesPersonaje.Add(habilidad);
        Debug.Log(string.Join(", ", habilidadesPersonaje));
    }

    public void Curacion(int vida)
    {
        playerController.i_vida += vida;
        playerController.Actualizar_Barra();
        if (playerController.i_vida > playerController.i_vidaMaxima)
            playerController.i_vida = playerController.i_vidaMaxima;
    }
}
