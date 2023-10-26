using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    CharacterController chc;

    public float speed;
    public float jump_speed;
    public float gravity;

    Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        chc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        moveDirection.x = horizontalInput * speed;

        if (chc.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jump_speed;
            }
        }
        else
        {
            
        }

        if (horizontalInput != 0)
        {
            float xScale = Mathf.Abs(transform.localScale.x);
            transform.localScale = new Vector3(horizontalInput < 0 ? -xScale : xScale, transform.localScale.y, transform.localScale.z);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        chc.Move(moveDirection * Time.deltaTime );
    }
}
