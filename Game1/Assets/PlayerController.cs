using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int i_vidaMaxima = 100;
    public int i_vida = 0;
    public bool b_teleport = false;

    public TMP_Text timerText;
    private float timerTime;
    private int minutes,seconds,cents;
    [SerializeField] GameObject menufinal;
    [SerializeField] TMP_Text score;

    private PlayerInput inputPlayer;
    public BoomerangController boomerangController;
    public GameObject BoomerangPrefab;
    public GameObject go_manoJugador;
    public Animator animator;
    public bool b_lanzar = false;
    MovimientoPlayer movPlayer;
    public bool b_Muerto = false;
    public bool b_finish = false;
    public Image barraVida;
    public GameObject menumuerto;
    public bool b_empezarJuego = false;
    public bool enemigoBonificacionTiempo = false;
    public GameObject quitarSegundos;
    public VidasMulti vidasMulti;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        i_vida = i_vidaMaxima;
        inputPlayer = GetComponent<PlayerInput>();
        movPlayer = GetComponent<MovimientoPlayer>();
        inputPlayer.actions["Disparar"].performed += LanzarBoomerang;
        inputPlayer.actions["IrBoomerang"].performed += IrBoomerang;
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (b_Muerto) 
        {
            Cursor.lockState = CursorLockMode.None;
            return ;
        };

        Muerte();
    }


    public IEnumerator Contador()
    {
        while (!b_Muerto && !b_finish)
        {
            timerTime += Time.deltaTime;
            if(enemigoBonificacionTiempo)
            {
                quitarSegundos.SetActive(true);
                timerTime -= 5f;
                enemigoBonificacionTiempo = false;
            }
            minutes = (int)(timerTime / 60f);
            seconds = (int)(timerTime - minutes * 60f);
            cents = (int)((timerTime - (int)timerTime) * 100f);
            cents = cents % 60;
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);
            yield return null;
        }
    }

    public void ActivarFinish() 
    {
        score.text = timerText.text;
        menufinal.SetActive(true);
        b_finish = true;
    }

    void Muerte()
    {
        if (i_vida <= 0 && !b_Muerto)
        {
            b_Muerto = true;
            inputPlayer.SwitchCurrentActionMap("NoMovimiento");
            animator.SetBool("Death", true);
            StartCoroutine(Animacion_Muerte());
        }
    }

    IEnumerator Animacion_Muerte()
    {
        yield return new WaitForSeconds(5f);
        animator.SetBool("Death", false);
        menumuerto.SetActive(true);
    }


    public void CloneBoobmerag()
    {
        if (!b_finish)
        {
            GameObject clone;
            Vector3 v3_posCreacion = new Vector3(go_manoJugador.transform.position.x, go_manoJugador.transform.position.y + .2f, go_manoJugador.transform.position.z - 0.1f);
            clone = Instantiate(BoomerangPrefab, v3_posCreacion, BoomerangPrefab.transform.rotation) as GameObject;
            clone.GetComponent<BoomerangController>().b_clone = true;
            if (b_teleport)
                clone.GetComponent<BoomerangController>().b_teleport = true;
            b_lanzar = false;
        }
    }

    public void Restar_Vida(int i_da�o)
    {
        i_vida -= i_da�o;
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
            if (GetComponentInParent<PremiosController>().habilidadesPersonaje.Contains("IrBoomerang"))
            {
                b_teleport = true;
                animator.SetBool("isAttacking", true);
            }
        }        
    }

}
