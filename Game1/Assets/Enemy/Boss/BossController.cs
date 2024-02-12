using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    GameObject player;
    public bool b_inRange = false;

    private float cooldownAtaque1 = 4f; 
    private float cooldownAtaque2 = 5f;
    private float cooldownAtaque3 = 6f;

    private float tiempoUltimoAtaque = 0f;
    private int tipoUltimoAtaque = 0;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MovimientoPlayer>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (b_inRange)
        {
            float xScale = Mathf.Abs(transform.localScale.x);
            transform.localScale = new Vector3(transform.position.x < player.transform.position.x ? -xScale : xScale, transform.localScale.y, transform.localScale.z);

            // Genera un número aleatorio para determinar el ataque
            if (Time.time - tiempoUltimoAtaque > ObtenerCooldown())
            {
                // Genera un número aleatorio para determinar el ataque
                float randomAttack = Random.Range(0f, 100f);

                // Determina cuál ataque ejecutar en base al número aleatorio
                if (randomAttack <= 45f)
                {
                    Ataque1();
                    tipoUltimoAtaque = 1;
                }
                else if (randomAttack <= 85f)
                {
                    Ataque2();
                    tipoUltimoAtaque = 2;
                }
                else
                {
                    Ataque3();
                    tipoUltimoAtaque = 3;
                }

                // Actualiza el tiempo del último ataque y el tipo de último ataque
                tiempoUltimoAtaque = Time.time;
            }
        }
    }

    float ObtenerCooldown()
    {
        // Devuelve el cooldown correspondiente al tipo de ataque
        switch (tipoUltimoAtaque)
        {
            case 1:
                return cooldownAtaque1;
            case 2:
                return cooldownAtaque2;
            case 3:
                return cooldownAtaque3;
            default:
                return 0f;
        }
    }

    void Ataque1()
    {
        animator.SetTrigger("Atacar");
        Debug.Log("Ataque 1");
    }

    void Ataque2()
    {
        animator.SetTrigger("Atacar2");
        Debug.Log("Ataque 2");
    }

    void Ataque3()
    {
        animator.SetTrigger("AtacarCombo");
        Debug.Log("Ataque 3");
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
