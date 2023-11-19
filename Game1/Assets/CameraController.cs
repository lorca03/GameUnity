using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject Player;
    private Vector3 v3_Posicion;

    public float f_Velocidad;
    public float f_xAjustePosicion;
    public float f_yAjustePosicion;
    public float f_Zoom;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<MovimientoPlayer>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        v3_Posicion = new Vector3(Player.transform.position.x + f_xAjustePosicion, Player.transform.position.y + f_yAjustePosicion, f_Zoom);

        transform.position = Vector3.Lerp(transform.position, v3_Posicion, f_Velocidad * Time.deltaTime);
    }
}
