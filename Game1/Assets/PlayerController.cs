using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int i_vidaMaxima = 100;
    public int i_vida = 0;

    private PlayerInput inputPlayer;
    public BoomerangController boomerangController;

    // Start is called before the first frame update
    void Start()
    {
        i_vida = i_vidaMaxima;
        inputPlayer = GetComponent<PlayerInput>();
        inputPlayer.actions["Disparar"].performed += Disparar;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Disparar(InputAction.CallbackContext obj)
    {
        boomerangController.Lanzar();
    }


}
