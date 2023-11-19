using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    void EventoLanzar()
    {
        PlayerController pc_Script = transform.root.GetComponent<PlayerController>();
        pc_Script.b_lanzar = true;
    }
}
