using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    void EventoLanzar() {
        BoomerangController bc_Script = GetComponentInChildren<BoomerangController>();
        bc_Script.b_lanzar = true;
    }
}
