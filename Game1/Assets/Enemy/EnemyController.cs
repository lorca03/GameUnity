using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject Player;
    Animator animator;
    CharacterController Chc;

    public float Speed = 6;
    public float DistanciaAtaque = 4;
    public float gravedad = 20f;
    public bool inRange = false;

    Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Chc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Player = FindObjectOfType<MovimientoPlayer>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(animator.GetBool("isWalking"));
        if (inRange)
        {
            Vector3 lookEnemy = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
            transform.LookAt(lookEnemy);
            float dist = Vector3.Distance(transform.position, lookEnemy);
            if (DistanciaAtaque < dist)
            {
                if (transform.position.x > Player.transform.position.x)
                    moveDirection = Vector3.left;
                else
                    moveDirection = Vector3.right;

                moveDirection *= Speed;
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
                moveDirection = Vector3.zero;
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
            moveDirection = Vector3.zero;
        }
        
        moveDirection.y -= gravedad * Time.deltaTime;
        Chc.Move(moveDirection * Time.deltaTime);
    }
}
