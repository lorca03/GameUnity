using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RB_Movimiento : MonoBehaviour
{
    private Vector3 movedirection;
    private Rigidbody rb;
    public float speed;
    private PlayerInput inputPlayer;
    public float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputPlayer = GetComponent<PlayerInput>();
        inputPlayer.actions["Jump"].started += RB_Movimiento_started;
    }

    private void RB_Movimiento_started(InputAction.CallbackContext obj)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Update()
    {
        Input();
        movedirection = new Vector3(Input().x * speed , rb.velocity.y, 0);
    }

    void FixedUpdate()
    {
        rb.velocity = movedirection;
    }

    private Vector2 Input()
    {
        return inputPlayer.actions["Movment"].ReadValue<Vector2>();
    }
}
