using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Canvi_color_text_button : MonoBehaviour
{

    public TMP_Text textMeshPro;
    Color color;

    private void Start()
    {
        color = textMeshPro.color;
    }

    public void Color_Neon()
    {
        textMeshPro.color = new Color(0,253,255);
    }

    public void Color_White()
    {
        textMeshPro.color = Color.white;
    }

    public void Color_Origirnal()
    {
        textMeshPro.color = color;
    }


}
