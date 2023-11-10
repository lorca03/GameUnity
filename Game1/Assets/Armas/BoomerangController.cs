using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangController : MonoBehaviour
{
    public Transform alcance;
    Rigidbody rb;
    public float f_force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lanzar()
    {
        //Animator animator = GetComponentInParent<Animator>();
        //animator.StopPlayback();
        Debug.Log("Lanzar");
        Debug.Log(rb);
        rb.AddRelativeForce(alcance.position * f_force);
        //transform.position = alcance.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("");
        }
    }
}
