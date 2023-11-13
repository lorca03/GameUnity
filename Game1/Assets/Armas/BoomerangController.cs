using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BoomerangController : MonoBehaviour
{
    public Transform alcance;
    public GameObject manoJugador;
    public GameObject boomerang;
    GameObject boomerangClone;
    Vector3 direccion;
    public float f_force;
    bool armaEnAire;
    public Animator animator;
    public bool b_lanzar = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Lanzar()
    {
        while (!b_lanzar) {
            yield return new WaitForSeconds(.05f);
        }
        direccion = manoJugador.transform.root.localScale.x == 1 ? Vector3.right : Vector3.left;
        boomerang.SetActive(false);
        boomerangClone = Instantiate(gameObject, transform.position, transform.rotation);
        boomerangClone.SetActive(true);
        boomerangClone.transform.Rotate(Time.deltaTime * 500, 0, 0);
        Vector3 locationInFrontOfPlayer = new Vector3(manoJugador.transform.position.x + 4f, manoJugador.transform.position.y + 1, manoJugador.transform.position.z) + direccion * 3f;
        Debug.Log(locationInFrontOfPlayer);
        Debug.Log(Time.deltaTime);
        boomerangClone.transform.position = Vector3.MoveTowards(transform.position, locationInFrontOfPlayer, Time.deltaTime * 5f);
        Debug.Log(boomerangClone.transform.position);
        //transform.parent = null;
        //float distanciaRecorrida = 0f;
        //float distanciaMaxima = 10f;

        //while (distanciaRecorrida < distanciaMaxima)
        //{
        //    float movimiento = f_force * Time.deltaTime;
        //    transform.Translate(direccion * movimiento, Space.World);
        //    distanciaRecorrida += movimiento;

        //    yield return null;
        //}

        yield return new WaitForSeconds(5f);
        animator.SetBool("isAttacking", false);
        //StartCoroutine(RegresarBoomerang());
        b_lanzar = false;
    }

    IEnumerator RegresarBoomerang()
    {
        float distancia = Vector3.Distance(transform.position, manoJugador.transform.position);

        float velocidadRetorno = 3f;

        while (distancia > 0f)
        {
            //Debug.Log(manoJugador.position);
            transform.position = Vector3.Lerp(transform.position, manoJugador.transform.position, velocidadRetorno * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, manoJugador.transform.rotation, velocidadRetorno * Time.deltaTime);
            distancia = Vector3.Distance(transform.position, manoJugador.transform.position);
            yield return null;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("");
        }
    }
}
