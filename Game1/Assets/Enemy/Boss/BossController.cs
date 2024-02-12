using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    GameObject player;
    public bool b_inRange = false;

    private float cooldownAtaque1 = 3f; 
    private float cooldownAtaque2 = 4f;
    private float cooldownAtaque3 = 6f;

    private float tiempoUltimoAtaque = 0f;
    private int tipoUltimoAtaque = 0;

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
            // Mira hacia el jugador
            Vector3 direction = player.transform.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 5f); // Puedes ajustar la velocidad de rotaci�n

            // Genera un n�mero aleatorio para determinar el ataque
            if (Time.time - tiempoUltimoAtaque > ObtenerCooldown())
            {
                // Genera un n�mero aleatorio para determinar el ataque
                float randomAttack = Random.Range(0f, 100f);

                // Determina cu�l ataque ejecutar en base al n�mero aleatorio
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

                // Actualiza el tiempo del �ltimo ataque y el tipo de �ltimo ataque
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
        // L�gica del primer ataque
        Debug.Log("Ataque 1");
    }

    void Ataque2()
    {
        // L�gica del segundo ataque
        Debug.Log("Ataque 2");
    }

    void Ataque3()
    {
        // L�gica del tercer ataque
        Debug.Log("Ataque 3");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            b_inRange = true;
        }
    }
}
