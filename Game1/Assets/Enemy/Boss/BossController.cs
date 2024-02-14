using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    public bool b_inRange = false;

    private float cooldownAtaque1 = 3f;
    private float cooldownAtaque2 = 4f;
    private float cooldownAtaque3 = 5f;

    public int i_vida = 0;
    public int i_vidaMaxima = 100;
    public Image barraVidaEnemy;
    public bool b_isDead = false;

    private float tiempoUltimoAtaque = 0f;
    private int tipoUltimoAtaque = 0;
    public Animator animator;
    public float dashTime;
    [SerializeField] bool atacando = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MovimientoPlayer>().gameObject;
        rb = GetComponent<Rigidbody>();
        i_vida = i_vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        if (b_inRange)
        {
            if (!atacando)
            {
                float xScale = Mathf.Abs(transform.localScale.x);
                transform.localScale = new Vector3(transform.position.x < player.transform.position.x ? -xScale : xScale, transform.localScale.y, transform.localScale.z);
            }

            // Genera un número aleatorio para determinar el ataque
            if (Time.time - tiempoUltimoAtaque > ObtenerCooldown())
            {
                // Genera un número aleatorio para determinar el ataque
                float randomAttack = Random.Range(0f, 100f);
                atacando = true;
                if (randomAttack <= 20f)
                {
                    StartCoroutine(Dash());
                    tipoUltimoAtaque = 4; 
                }
                else if (randomAttack <= 60f)
                {
                    if (randomAttack <= 45f)
                    {
                        Ataque1();
                        tipoUltimoAtaque = 1;
                    }
                    else
                    {
                        Ataque2();
                        tipoUltimoAtaque = 2;
                    }
                }
                else
                {
                    Ataque3();
                    tipoUltimoAtaque = 3;
                }
                tiempoUltimoAtaque = Time.time;
            }

        }
    }

    public void RestarVida(int i_daño)
    {
        if (i_vida - i_daño <= 0)
        {
            animator.SetTrigger("Dead");
            b_isDead = true;
            Destroy(transform.gameObject, 1f);
        }
        i_vida -= i_daño;
        barraVidaEnemy.fillAmount = (float)i_vida / i_vidaMaxima;
    }

    private void OnDestroy()
    {
        try
        {
            GetComponentInParent<SalaController>().Liberar();
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        animator.SetBool("Dash", true);
        Vector3 dashDirection = new Vector3(((player.transform.position - transform.position).normalized).x, 0f, 0f);

        while (Time.time < startTime + dashTime)
        {
            rb.MovePosition(transform.position + dashDirection * 30 * Time.deltaTime);
            yield return null;
        }
        animator.SetBool("Dash", false);
        atacando = false;
    }

    float ObtenerCooldown()
    {
        switch (tipoUltimoAtaque)
        {
            case 1:
                return cooldownAtaque1;
            case 2:
                return cooldownAtaque2;
            case 3:
                return cooldownAtaque3;
            case 4:
                return 2f;
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

    public void FinAtaque()
    {
        atacando = false;
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
