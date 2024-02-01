using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PrincipioController : MonoBehaviour
{
    public GameObject player;
    PlayerInput playerInput;
    PlayerController playerController;

    void Start()
    {
        playerInput = player.GetComponent<PlayerInput>();
        playerController = player.GetComponent<PlayerController>();
    }

    public void EmpezarJuego()
    {
        Debug.Log("empieza");
        playerInput.SwitchCurrentActionMap("InputsPlayer");
        Camera.main.GetComponent<AudioSource>().mute = false;
        StartCoroutine(playerController.Contador());
    }
}
