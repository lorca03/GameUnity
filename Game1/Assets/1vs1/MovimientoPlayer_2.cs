using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoPlayer_2 : MonoBehaviour
{
    CharacterController chc;
    public Animator animator;
    private PlayerInput inputPlayer;
    PlayerController_2 playerController;

    public float f_speed;
    public float f_jump_speed;
    public float f_gravity;

    float f_horizontalInput;
    float profundidad;

    [HideInInspector] public Vector3 v3_moveDirection = Vector3.zero;
    Vector3 v3_posicio_inicial = Vector3.zero;
    void Start()
    {
        v3_posicio_inicial = transform.position;
        chc = GetComponent<CharacterController>();
        inputPlayer = GetComponent<PlayerInput>();
        inputPlayer.actions["Jump"].performed += Chc_Jump;
        playerController = GetComponent<PlayerController_2>();
        profundidad = transform.position.z;
        Application.targetFrameRate = 60;
    }


    void Update()
    {
        if (playerController.b_Muerto)
            return;

        f_horizontalInput = Input().x;
        v3_moveDirection.x = f_horizontalInput * f_speed;

        if (f_horizontalInput != 0)
        {
            animator.SetBool("isRunning", true);
            float xScale = Mathf.Abs(transform.localScale.x);
            transform.localScale = new Vector3(f_horizontalInput < 0 ? -xScale : xScale, transform.localScale.y, transform.localScale.z);
        }
        else
            animator.SetBool("isRunning", false);

        if (chc.isGrounded && v3_moveDirection.y < 0)
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
            v3_moveDirection.y -= f_gravity * Time.deltaTime;
        }

        if (transform.position.y < -30)
        {
            playerController.i_vida = 0;
        }
        else
        {
            chc.Move(v3_moveDirection * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, profundidad);
        }
    }

    private Vector2 Input()
    {
        return inputPlayer.actions["Movment"].ReadValue<Vector2>();
    }

    private void Chc_Jump(InputAction.CallbackContext obj)
    {
        if (chc != null)
        {
            if (chc.isGrounded)
            {
                animator.SetBool("isJumping", true);
                v3_moveDirection.y = f_jump_speed;
            }
        }

    }
}
