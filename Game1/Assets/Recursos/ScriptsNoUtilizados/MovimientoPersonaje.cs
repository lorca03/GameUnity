using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoPersonaje : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;
    public float gravity = 20f;
    private Vector3 v3_posicio_inicial;

    private CharacterController chc;
    private Vector3 moveDirection;
    private bool isGrounded;
    RaycastHit hitInfo;

    void Start()
    {
        chc = GetComponent<CharacterController>();
        v3_posicio_inicial = transform.position;
    }

    void Update()
    {
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, out hitInfo, chc.height / 2 + 0.2f);

        float horizontalInput = Input.GetAxis("Horizontal");
        moveDirection = new Vector3(horizontalInput * speed, moveDirection.y, 0f);

        if (isGrounded)
        {
            GetComponent<Renderer>().material.color = Color.red;
            moveDirection.y = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (transform.position.y < -20)
        {
            transform.position = v3_posicio_inicial;
            moveDirection = Vector3.zero;
        }
        else
            chc.Move(moveDirection * Time.deltaTime);

    }
}
