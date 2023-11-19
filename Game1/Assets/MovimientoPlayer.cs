using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoPlayer : MonoBehaviour
{
    CharacterController chc;
    public Animator animator;
    private PlayerInput inputPlayer;

    public float f_speed;
    public float f_jump_speed;
    public float f_gravity;
    float f_horizontalInput;

    Vector3 v3_moveDirection = Vector3.zero;
    Vector3 v3_posicio_inicial = Vector3.zero;
    void Start()
    {
        v3_posicio_inicial = transform.position;
        chc = GetComponent<CharacterController>();
        inputPlayer = GetComponent<PlayerInput>();
        inputPlayer.actions["Jump"].performed += Chc_Jump;
    }

    void Update()
    {
        if (chc.GetComponent<PlayerController>().b_Muerto) return;
        Input();
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
            animator.SetBool("isJumping", false);
        else
        {
            animator.SetBool("isJumping", true);
            v3_moveDirection += Physics.gravity * f_gravity * Time.deltaTime;
        }

        if (transform.position.y < -30)
            ResetPosition();
        else
            chc.Move(v3_moveDirection * Time.deltaTime);

    }

    private Vector2 Input()
    {
        return inputPlayer.actions["Movment"].ReadValue<Vector2>();
    }

    private void Chc_Jump(InputAction.CallbackContext obj)
    {
        if (chc.isGrounded)
        {
            animator.SetBool("isJumping", true);
            v3_moveDirection.y = f_jump_speed;
        }
    }

    public void ResetPosition()
    {
        transform.position = v3_posicio_inicial;
        f_horizontalInput = 0;
        GameObject camara = GameObject.Find("Main Camera");
        camara.transform.Find("Muerto").gameObject.SetActive(false);
    }
}