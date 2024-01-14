using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremioBoomerang : MonoBehaviour
{
    public float rotationSpeed = 5f;
    private GameObject boomerang;

    // Start is called before the first frame update
    void Start()
    {
        boomerang = transform.Find("boomerangRotando").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        boomerang.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        boomerang.transform.rotation = Quaternion.Euler(new Vector3(-55f, boomerang.transform.rotation.eulerAngles.y, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PremiosController>().AñadirHabilidad("IrBoomerang");
            gameObject.SetActive(false);
        }
    }
}
