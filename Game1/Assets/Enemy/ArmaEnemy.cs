using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaEnemy : MonoBehaviour
{
    public int i_daño = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().i_vida -= i_daño;
        }
    }
}
