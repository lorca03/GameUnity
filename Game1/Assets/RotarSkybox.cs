using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarSkybox : MonoBehaviour
{
    public float velocidadRotacion = 1f;

    void Update()
    {
       // RenderSettings.skybox.SetFloat("_Rotation", Time.time * velocidadRotacion);
    }
}
