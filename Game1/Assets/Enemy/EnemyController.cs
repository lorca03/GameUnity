using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject Player;
    Animator animator;
    CharacterController Chc;
    GameObject go_player;

    public ArmaEnemy ArmaEnemy;
    public float f_Speed = 6;
    public float f_DistanciaAtaque = 4;
    public float f_gravedad = 20f;
    public bool b_inRange = false;
    public int i_vidaMaxima = 100;
    public int i_vida = 0;
    bool b_isDead = false;
    public Transform t_Punto1;
    public Transform t_Punto2;
    Transform t_PuntoIr;
    Vector3 v3_lookEnemy;

    Vector3 v3_moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        go_player = GameObject.Find("Chc_Personaje");
        i_vida = i_vidaMaxima;
        Chc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Player = FindObjectOfType<MovimientoPlayer>().gameObject;
        t_PuntoIr = t_Punto1;
    }

    void AndarRuta()
    {
        animator.SetBool("isWalking", true);
        if (transform.position.x == t_Punto1.position.x)
            t_PuntoIr = t_Punto2;
        else if (transform.position.x == t_Punto2.position.x)
            t_PuntoIr = t_Punto1;
        v3_lookEnemy = new Vector3(t_PuntoIr.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, t_PuntoIr.position, 2f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (b_isDead) return;
        if (b_inRange)
        {
            v3_lookEnemy = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
            float dist = Vector3.Distance(transform.position, v3_lookEnemy);
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
                //animator.SetTrigger("Atacar");
                if (go_player.GetComponent<PlayerController>().b_Muerto)
                {
                    animator.SetBool("isAttacking", false);
                }
                else
                {
                    animator.SetBool("isAttacking", true);
                }
                animator.SetBool("isWalking", false);
                v3_moveDirection = Vector3.zero;
            }
            Chc.Move(v3_moveDirection * 2f * Time.deltaTime);
        }
        else
        {
            AndarRuta();
        }
        transform.LookAt(v3_lookEnemy);
    }

    //IEnumerator Delay()
    //{
    //    Debug.Log("ey");       
    //    yield return new WaitForSeconds(5f);
    //}


    public void RestarVida(int i_daño)
    {
        Debug.Log(i_daño);
        if (i_vida - i_daño <= 0)
        {
            animator.SetTrigger("Dead");
            b_isDead = true;
            Destroy(gameObject, 1);
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

    private void LanzarRayo()
    {
        ArmaEnemy.LanzarRayo(v3_lookEnemy);
    }
}
