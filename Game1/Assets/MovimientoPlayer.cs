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
    public float jump_speed;
    public float gravity;
    float horizontalInput;

    Vector3 moveDirection = Vector3.zero;
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
        Input();
        horizontalInput = Input().x;
        moveDirection.x = horizontalInput * f_speed;

        if (horizontalInput != 0)
        {
            animator.SetBool("isRunning", true);
            float xScale = Mathf.Abs(transform.localScale.x);
            transform.localScale = new Vector3(horizontalInput < 0 ? -xScale : xScale, transform.localScale.y, transform.localScale.z);
        }
        else
            animator.SetBool("isRunning", false);

        if (chc.isGrounded && moveDirection.y < 0)
            animator.SetBool("isJumping", false);
        else
        {
            animator.SetBool("isJumping", true);
            moveDirection += Physics.gravity * gravity * Time.deltaTime;
        }

        if (transform.position.y < -30)
            ResetPosition();
        else
            chc.Move(moveDirection * Time.deltaTime);

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
            moveDirection.y = jump_speed;
        }
    }

    private void ResetPosition()
    {
        transform.position = v3_posicio_inicial;
        horizontalInput = 0;
    }
}
