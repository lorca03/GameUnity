using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampasController : MonoBehaviour
{
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
        if (other.gameObject.tag == "Player")
        {
            transform.Find("Trampa").gameObject.SetActive(true);
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("ey2");
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("ey2");
    //    }
    //}
}
