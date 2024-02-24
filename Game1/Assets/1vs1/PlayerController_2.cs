using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController_2 : MonoBehaviour
{
    public int i_vidaMaxima = 100;
    public int i_vida = 0;
    public bool b_teleport = false;

    private PlayerInput inputPlayer;
    public BoomerangController boomerangController;
    public GameObject BoomerangPrefab;
    public GameObject go_manoJugador;
    public Animator animator;
    public bool b_lanzar = false;
    MovimientoPlayer_2 movPlayer;
    public bool b_Muerto = false;
    public bool b_finish = false;
    public Image barraVida;
    public bool b_empezarJuego = false;
    public VidasMulti vidasMulti;

    // Start is called before the first frame update
    void Start()
    {
        i_vida = i_vidaMaxima;
        inputPlayer = GetComponent<PlayerInput>();
        movPlayer = GetComponent<MovimientoPlayer_2>();
        inputPlayer.actions["Disparar"].performed += LanzarBoomerang;
        inputPlayer.actions["IrBoomerang"].performed += IrBoomerang;
    }

    void Update()
    {
        if (b_Muerto) return;

        vidasMulti.MuerteMulti(i_vida, gameObject);
    }


    public void CloneBoobmerag()
    {
        GameObject clone;
        Vector3 v3_posCreacion = new Vector3(go_manoJugador.transform.position.x, go_manoJugador.transform.position.y + .2f, go_manoJugador.transform.position.z - 0.2f);
        clone = Instantiate(BoomerangPrefab, v3_posCreacion, BoomerangPrefab.transform.rotation) as GameObject;
        clone.GetComponent<BoomerangController_2>().b_clone = true;
        clone.GetComponent<BoomerangController_2>().i_numeroJugador = gameObject.name == "Chc_Personaje" ? 1 : 2;
        if (b_teleport)
            clone.GetComponent<BoomerangController_2>().b_teleport = true;
        b_lanzar = false;
    }

    public void Restar_Vida(int i_daño)
    {
        i_vida -= i_daño;
        Actualizar_Barra();
    }

    public void Actualizar_Barra()
    {
        barraVida.fillAmount = (float)i_vida / i_vidaMaxima;
    }

    public void Resetear_Juego()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LanzarBoomerang(InputAction.CallbackContext obj)
    {
        if (animator != null)
        {
            animator.SetBool("isAttacking", false);
            b_teleport = false;
            animator.SetBool("isAttacking", true);
        }
    }
    private void IrBoomerang(InputAction.CallbackContext obj)
    {
        if (animator != null)
        {
            if (GetComponentInParent<PremiosController_2>().habilidadesPersonaje.Contains("IrBoomerang"))
            {
                b_teleport = true;
                animator.SetBool("isAttacking", true);
            }
        }
    }
}
