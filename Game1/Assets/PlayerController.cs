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

    // Start is called before the first frame update
    void Start()
    {
        i_vida = i_vidaMaxima;
        inputPlayer = GetComponent<PlayerInput>();
        inputPlayer.actions["Disparar"].performed += LanzarBoomerang;
    }

    void Update()
    {
        if (b_lanzar)
        {
            GameObject clone;
            Vector3 v3_posCreacion = new Vector3 (go_manoJugador.transform.position.x, go_manoJugador.transform.position.y + .2f, go_manoJugador.transform.position.z);
            clone = Instantiate(BoomerangPrefab, v3_posCreacion, BoomerangPrefab.transform.rotation) as GameObject;
            clone.GetComponent<BoomerangController>().b_clone = true;
            b_lanzar = false;
        }
    }

    private void LanzarBoomerang(InputAction.CallbackContext obj)
    {
        animator.SetBool("isAttacking", true);
    }


}
