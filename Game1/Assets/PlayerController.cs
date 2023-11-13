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
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        i_vida = i_vidaMaxima;
        inputPlayer = GetComponent<PlayerInput>();
        inputPlayer.actions["Disparar"].performed += LanzarBoomerang;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LanzarBoomerang(InputAction.CallbackContext obj)
    {
        animator.SetBool("isAttacking", true);
        StartCoroutine(boomerangController.Lanzar());
    }


}
