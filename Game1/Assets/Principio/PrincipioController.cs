using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PrincipioController : MonoBehaviour
{
    public GameObject player;
    PlayerInput playerInput;
    PlayerController playerController;
    public GameObject controlesAndroid;

    void Start()
    {
        playerInput = player.GetComponent<PlayerInput>();
        playerController = player.GetComponent<PlayerController>();
        controlesAndroid.SetActive(false);
    }

    public void EmpezarJuego()
    {
        playerInput.SwitchCurrentActionMap("InputsPlayer");
        Camera.main.GetComponent<AudioSource>().mute = false;
        StartCoroutine(playerController.Contador());
        if (Input.touchSupported)
        {
            controlesAndroid.SetActive(true);
        }
    }
}
