using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject Player;
    private Vector3 Posicion;

    public float Velocidad;
    public float xAjustePosicion;
    public float yAjustePosicion;
    public float Zoom;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<MovimientoPlayer>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Posicion = new Vector3(Player.transform.position.x + xAjustePosicion, Player.transform.position.y + yAjustePosicion, Zoom);

        transform.position = Vector3.Lerp(transform.position, Posicion, Velocidad * Time.deltaTime);
    }
}
