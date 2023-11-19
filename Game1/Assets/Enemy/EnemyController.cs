using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject Player;
    Animator animator;
    CharacterController Chc;

    public float f_Speed = 6;
    public float f_DistanciaAtaque = 4;
    public float f_gravedad = 20f;
    public bool b_inRange = false;
    public int i_vidaMaxima = 100;
    public int i_vida = 0;
    bool b_isDead = false;

    Vector3 v3_moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        i_vida = i_vidaMaxima;
        Chc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Player = FindObjectOfType<MovimientoPlayer>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (b_isDead) return;
        if (b_inRange)
        {
            Vector3 lookEnemy = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
            transform.LookAt(lookEnemy);
            float dist = Vector3.Distance(transform.position, lookEnemy);
            if (f_DistanciaAtaque < dist)
            {
                if (transform.position.x > Player.transform.position.x)
                    v3_moveDirection = Vector3.left;
                else
                    v3_moveDirection = Vector3.right;

                v3_moveDirection *= f_Speed;
                animator.SetBool("isWalking", true);
                animator.SetBool("isAttacking", false);
            }
            else
            {
                animator.SetBool("isAttacking", true);
                animator.SetBool("isWalking", false);
                v3_moveDirection = Vector3.zero;
            }
        }
        else
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isWalking", false);
            v3_moveDirection = Vector3.zero;
        }

        v3_moveDirection.y -= f_gravedad * Time.deltaTime;
        Chc.Move(v3_moveDirection * Time.deltaTime);
    }

    public void RestarVida(int i_daño)
    {
        Debug.Log(i_daño);
        if (i_vida - i_daño <= 0)
        {
            animator.SetTrigger("Dead");
            b_isDead = true;
            Destroy(gameObject, 2);
        }
        i_vida -= i_daño;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            b_inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            b_inRange = false;
        }
    }
}
