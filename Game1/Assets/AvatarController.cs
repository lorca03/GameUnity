using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    void EventoLanzar()
    {
        transform.root.GetComponent<PlayerController>().CloneBoobmerag();
    }
}
