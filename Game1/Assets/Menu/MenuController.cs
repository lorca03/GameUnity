using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject MenuPausa;
    public bool b_pausa = false;
    public PlayerInput inputPlayer;
    public GameObject botonAtras;

    void Start()
    {
        if (inputPlayer != null)
            inputPlayer.actions["Pausa"].performed += Pausa;
    }

    private void Pausa(InputAction.CallbackContext obj)
    {
        if (b_pausa == false)
        {
            CursorActiv(true);
            MenuPausa.SetActive(true);
            MenuPausa.transform.Find("Botones").gameObject.SetActive(true);
            b_pausa = true;
            Time.timeScale = 0;
        } else if(b_pausa)
            Reanudar();
    }

    public void Reanudar()
    {
        if (b_pausa)
        {
            CursorActiv(false);
            MenuPausa.SetActive(false);
            GetComponent<ObjetosGlobales>().MostrarOpciones(false);
            botonAtras.SetActive(false);
            b_pausa = false;
            Time.timeScale = 1;
        }
    }

    void CursorActiv(bool activar) 
    { 
        if (activar) 
            Cursor.lockState = CursorLockMode.None; 
        else 
            Cursor.lockState = CursorLockMode.Locked;
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
