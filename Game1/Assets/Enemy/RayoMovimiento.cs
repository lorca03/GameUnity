using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayoMovimiento : MonoBehaviour
{
    public float f_speed = 1f;
    public float f_destroyAfterDistance = 10f;
    public Vector3 destino;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(destino * f_speed * Time.deltaTime);
    }
}
