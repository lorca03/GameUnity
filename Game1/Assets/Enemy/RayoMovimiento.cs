using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayoMovimiento : MonoBehaviour
{
    public int i_daño = 10;
    public float f_speed = 8f;
    public float f_destroyAfterDistance = 20f;
    float f_puntoSalida;
    public Vector3 destino;

    // Start is called before the first frame update
    void Start()
    {
        f_puntoSalida = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - f_puntoSalida) >= f_destroyAfterDistance)
        {
            Destroy(gameObject);
        }
        transform.Translate(destino * f_speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().i_vida -= i_daño;
        }
    }
}
