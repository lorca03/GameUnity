using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController_2 : MonoBehaviour
{
    void EventoLanzar()
    {
        transform.root.GetComponent<PlayerController_2>().CloneBoobmerag();
    }
}
