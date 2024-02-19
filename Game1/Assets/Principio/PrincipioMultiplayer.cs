using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PrincipioMultiplayer : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    PlayerInput playerInput;
    PlayerInput playerInput2;

    void Start()
    {
        playerInput = player1.GetComponent<PlayerInput>();
        playerInput2 = player2.GetComponent<PlayerInput>();
        if (Input.touchSupported)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void EmpezarJuego()
    {
        playerInput2.SwitchCurrentActionMap("InputsPlayer1");
        playerInput.SwitchCurrentActionMap("InputsPlayer");
        Camera.main.GetComponent<AudioSource>().mute = false;
    }
}
