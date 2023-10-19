using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment_Personatge : MonoBehaviour
{
    public float f_limit_vida_vertical = -20f;
    public float f_velocitat = 1f;
    public float f_sensibilitat_gir = 1f;
    public float f_bot = 1f;
    public float f_friccio_aire = 1f;

    Vector3 v3_l_velocitat_vertical = Vector3.zero;
    Vector3 v3_l_velocitat_horitzontal = Vector3.zero;

    CharacterController characterController;

    Vector3 v3_posicio_inicial = Vector3.zero;

  

    private void Start()
    {
        v3_posicio_inicial = transform.position;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        
        //si toque piso velocitat vertical es zero
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo,characterController.height/2 + 0.2f  ))
        {
            GetComponent<Renderer>().material.color = Color.red;

            //v3_l_velocitat_horitzontal = Vector3.zero;
            v3_l_velocitat_vertical = Vector3.zero;

            //if (Input.GetKey(KeyCode.UpArrow))
            //    v3_l_velocitat_horitzontal += Vector3.forward;
            //if (Input.GetKey(KeyCode.DownArrow))
            //    v3_l_velocitat_horitzontal += Vector3.back;
            if (Input.GetKey(KeyCode.LeftArrow))
                v3_l_velocitat_horitzontal += Vector3.left;
            if (Input.GetKey(KeyCode.RightArrow))
                v3_l_velocitat_horitzontal += Vector3.right;
            
            v3_l_velocitat_horitzontal =
                Vector3.ProjectOnPlane(v3_l_velocitat_horitzontal,
                transform.InverseTransformVector(hitInfo.normal)).normalized 
                * f_velocitat;

            if (Input.GetMouseButton(1))
                v3_l_velocitat_vertical += Vector3.up * f_bot;
            
            //Gir
            //float f_gir_vertical = Input.GetAxis("Mouse X")
            //    * f_sensibilitat_gir * Time.deltaTime;

            //transform.Rotate(new Vector3(0, f_gir_vertical, 0),
            //Space.Self);
        }
        else if ((characterController.collisionFlags & CollisionFlags.Above) != 0)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            v3_l_velocitat_vertical = Physics.gravity * 45f * Time.deltaTime;
            v3_l_velocitat_horitzontal /= 1.01f;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;

            //velocitat vertical gravetat
            v3_l_velocitat_vertical += Physics.gravity * Time.deltaTime;

            //Possible error amb un bot molt llarg
            v3_l_velocitat_horitzontal +=
            -v3_l_velocitat_horitzontal.normalized * f_friccio_aire *
            Time.deltaTime;
        }

        if (transform.position.y < f_limit_vida_vertical)
        {
            transform.position = v3_posicio_inicial;
            v3_l_velocitat_horitzontal = Vector3.zero;
            v3_l_velocitat_vertical = Vector3.zero;
        }
        else
            characterController.Move(transform.TransformVector(
                v3_l_velocitat_horitzontal + v3_l_velocitat_vertical 
                + new Vector3(0f,0f,0.001f))
                 * Time.deltaTime);        
    }
}
