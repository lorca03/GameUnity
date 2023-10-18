using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RB_Movimiento : MonoBehaviour
{
    private Vector3 movedirection;
    private Rigidbody rb;
    public float speed;
    public float jumpForce;
    private PlayerInput inputPlayer;
    RaycastHit hitInfo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputPlayer = GetComponent<PlayerInput>();
        inputPlayer.actions["Jump"].performed += RB_Movimiento_started;
    }

    private void Update()
    {
        //Debug.Log(rb.velocity.y);
        Input();
        movedirection = new Vector3(Input().x * speed , rb.velocity.y, 0f);
    }

    void FixedUpdate()
    {
        rb.velocity = movedirection;
    }

    private void RB_Movimiento_started(InputAction.CallbackContext obj)
    {
        float altura = GetComponent<Renderer>().bounds.size.y / 2 + 0.2f;
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, altura))
        {
            Debug.Log(rb.velocity.y);
            Debug.Log("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private Vector2 Input()
    {
        return inputPlayer.actions["Movment"].ReadValue<Vector2>();
    }
}
