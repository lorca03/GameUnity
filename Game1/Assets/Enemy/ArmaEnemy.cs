using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArmaEnemy : MonoBehaviour
{
    Vector3 PosicionOnda;
    public GameObject Onda;

    public void LanzarOnda(Vector3 v3_lookEnemy) 
    {
        PosicionOnda = new Vector3(transform.position.x + (v3_lookEnemy.x > transform.position.x ? 1 : -1), transform.position.y - 3f, 44f - 1.33f);
        GameObject bullet = Instantiate(Onda, PosicionOnda, v3_lookEnemy.x > transform.position.x ? Quaternion.identity : Quaternion.Euler(0f, 180f, 0f));
        bullet.GetComponent<OndaMovimiento>().destino = Vector3.right;
    }
    
}
