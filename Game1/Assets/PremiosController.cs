using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremiosController : MonoBehaviour
{
    private string[] premios = {"BoomerangTeleport", "Cura"};
    private List<string> premiosPersonaje = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AñadirHabilidad(int habilidad)
    {
        premiosPersonaje.Add(premios[habilidad]);
        Debug.Log(string.Join(", ", premiosPersonaje));
    }
}
