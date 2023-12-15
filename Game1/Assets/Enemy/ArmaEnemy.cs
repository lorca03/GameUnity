using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArmaEnemy : MonoBehaviour
{
    Vector3 PosicionRayo;
    public GameObject Rayo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LanzarRayo(Vector3 v3_lookEnemy) 
    {
        PosicionRayo = new Vector3(transform.position.x + (v3_lookEnemy.x > transform.position.x ? 1 : -1), transform.position.y + (v3_lookEnemy.x > transform.position.x ? -2 : 0), -1.33f);
        GameObject bullet = Instantiate(Rayo, PosicionRayo, v3_lookEnemy.x > transform.position.x ? Quaternion.Euler(0f, 0f,-180f) : Quaternion.identity);
        bullet.GetComponent<RayoMovimiento>().destino = Vector3.left;
        //if (transform.position.z >= f_destroyAfterDistance)
        //{
        //    Destroy(gameObject);
        //}
    }

    
}
