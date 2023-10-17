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
    RaycastHit hitInfo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputPlayer = GetComponent<PlayerInput>();
        inputPlayer.actions["Jump"].started += RB_Movimiento_started;

    }

    private void RB_Movimiento_started(InputAction.CallbackContext obj)
    {
        if (hitInfo.transform.name == "Suelo")
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);

            
        }
    }

    private void Update()
    {

        Debug.Log(rb.velocity.y);
        Physics.Raycast(transform.position, Vector3.down, out hitInfo, 3);

        Debug.DrawRay(transform.position, Vector3.down * 3, Color.green);
        Input();
        movedirection = new Vector3(Input().x * speed , rb.velocity.y, 0);
       // Debug.Log(hitInfo.transform.name);
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
