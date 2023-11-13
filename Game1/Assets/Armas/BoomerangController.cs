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
    Vector3 direccion;
    public float f_force;
    bool armaEnAire;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Lanzar()
    {
        direccion = manoJugador.transform.root.localScale.x == 1 ? Vector3.right : Vector3.left;
        StartCoroutine(LanzarBoomerang());
    }

    IEnumerator LanzarBoomerang()
    {
        //transform.parent = null;
        float distanciaRecorrida = 0f;
        float distanciaMaxima = 10f;

        while (distanciaRecorrida < distanciaMaxima)
        {
            float movimiento = f_force * Time.deltaTime;
            transform.Translate(direccion * movimiento, Space.World);
            distanciaRecorrida += movimiento;

            yield return null;
        }

        yield return new WaitForSeconds(.5f);

        StartCoroutine(RegresarBoomerang());
        
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
