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
    public GameObject BoomerangPrefab;
    public GameObject go_manoJugador;
    public Animator animator;
    public bool b_lanzar = false;
    MovimientoPlayer movPlayer;
    public bool b_Muerto = false;

    // Start is called before the first frame update
    void Start()
    {
        i_vida = i_vidaMaxima;
        inputPlayer = GetComponent<PlayerInput>();
        movPlayer = GetComponent<MovimientoPlayer>();
        inputPlayer.actions["Disparar"].performed += LanzarBoomerang;
    }

    void Update()
    {
        if (b_Muerto) return;

        Muerte();
    }
    void Muerte()
    {
        if (i_vida <= 0 && !b_Muerto)
        {
            GameObject camara = GameObject.Find("Main Camera");
            camara.transform.Find("Muerto").gameObject.SetActive(true);
            b_Muerto = true;
            animator.SetBool("Death", true);
            StartCoroutine(Resetear_Juego());
        }
    }

    public void CloneBoobmerag()
    {
        GameObject clone;
        Vector3 v3_posCreacion = new Vector3(go_manoJugador.transform.position.x, go_manoJugador.transform.position.y + .2f, go_manoJugador.transform.position.z);
        clone = Instantiate(BoomerangPrefab, v3_posCreacion, BoomerangPrefab.transform.rotation) as GameObject;
        clone.GetComponent<BoomerangController>().b_clone = true;
        b_lanzar = false;
    }

    IEnumerator Resetear_Juego()
    {
        yield return new WaitForSeconds(5f);
        animator.SetBool("Death", false);
        i_vida = i_vidaMaxima;
        movPlayer.ResetPosition();
        b_Muerto = false;
    }

    private void LanzarBoomerang(InputAction.CallbackContext obj)
    {
        animator.SetBool("isAttacking", true);
    }


}
