using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject Player;
    CharacterController Chc;
    public float Speed;
    public float DistanciaAtaque;
    public float gravedad;
    Vector3 moveDirection = Vector3.zero;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Chc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Player = FindObjectOfType<MovimientoPlayer>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
