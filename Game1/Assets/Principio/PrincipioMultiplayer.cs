using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PrincipioMultiplayer : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    PlayerInput playerInput;
    PlayerInput playerInput2;

    void Start()
    {
        playerInput = player1.GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("NoMove");
        playerInput2 = player2.GetComponent<PlayerInput>();
        playerInput2.SwitchCurrentActionMap("NoMove");
    }

    public void EmpezarJuego()
    {
        playerInput.SwitchCurrentActionMap("InputsPlayer");
        playerInput2.SwitchCurrentActionMap("InputsPlayer1");
        //Camera.main.GetComponent<AudioSource>().mute = false;
    }
}
