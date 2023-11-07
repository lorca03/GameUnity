using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private PlayerInput inputPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inputPlayer = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Input();
        float horizontalInput = Input().x;
        float verticalInput = Input().y;

        rb.velocity = new Vector3(horizontalInput * speed, verticalInput * speed, 0);
    
    }

    private Vector2 Input()
    {
        return inputPlayer.actions["Move"].ReadValue<Vector2>();
    }
}
