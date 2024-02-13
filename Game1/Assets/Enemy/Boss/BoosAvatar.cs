using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosAvatar : MonoBehaviour
{
    BossController boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = GetComponentInParent<BossController>();
    }

    void FinAnimacion()
    {
        Debug.Log("Fin animacion");
        boss.FinAtaque();
    }
}
