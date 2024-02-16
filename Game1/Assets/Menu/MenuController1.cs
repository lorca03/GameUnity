using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuController1 : MonoBehaviour
{
    public GameObject MenuPausa;
    public bool b_pausa = false;
    public PlayerInput inputPlayer;

    void Start()
    {
        if (inputPlayer != null)
            inputPlayer.actions["Pausa"].performed += Pausa;
    }

    private void Pausa(InputAction.CallbackContext obj)
    {
        if (b_pausa == false)
        {
            MenuPausa.SetActive(true);
            b_pausa = true;
            Time.timeScale = 0;
        } else if(b_pausa)
            Reanudar();
    }

    public void Reanudar()
    {
        if (b_pausa)
        {
            MenuPausa.SetActive(false);
            b_pausa = false;
            Time.timeScale = 1;
        }
    }

    public void ElegirEscena(string escena)
    {
        Reanudar();
        SceneManager.LoadScene(escena);        
    }

    public void Jugar()
    {
        Reanudar();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
