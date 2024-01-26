using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlafatormaSuelta : MonoBehaviour
{
    private float esperarParaCaer = 0f;
    private float esperarParaDestruir = 2f;
    private float esperarParaReaparecer = 2f;
    private Vector3 antiguaPosicion;
    private Rigidbody rb;
    private Animator animacion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        antiguaPosicion = transform.position;
        animacion = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Caida());
        }
    }

    private IEnumerator Caida()
    {
        yield return new WaitForSeconds(esperarParaCaer);
        rb.useGravity = enabled;
        yield return new WaitForSeconds(esperarParaDestruir);
        gameObject.SetActive(false);
        Invoke("Reaparecer", esperarParaReaparecer);
    }

    private void Reaparecer()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = antiguaPosicion;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        animacion.SetBool("Reaparece", true);
    }
}
