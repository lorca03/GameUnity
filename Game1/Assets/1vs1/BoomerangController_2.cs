using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangController_2 : MonoBehaviour
{
    public bool b_clone = false;
    public bool b_teleport = false;
    int i_daño;
    bool b_go;
    GameObject player;
    GameObject boomerang;
    Vector3 v3_locationInFrontOfPlayer;
    Animator animator;
    GameObject camera;
    public int i_numeroJugador = 1;

    void Start()
    {
        camera = FindObjectOfType<CameraController_2>().gameObject;
        b_go = false;
        i_daño = 10;
        if (i_numeroJugador == 1)
        {
            player = GameObject.Find("Chc_Personaje");
            boomerang = GameObject.Find("boomerang");
        }
        else if (i_numeroJugador == 2)
        {
            player = GameObject.Find("Chc_Personaje2");
            boomerang = GameObject.Find("boomerang2");
        }

        animator = player.transform.Find("Ch44_nonPBR").GetComponent<Animator>();

        Vector3 direccion = player.transform.root.localScale.x == 1 ? Vector3.right : Vector3.left;

        if (b_clone)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject hijo = boomerang.transform.GetChild(i).gameObject;
                hijo.GetComponent<MeshRenderer>().enabled = false;
            }

            v3_locationInFrontOfPlayer = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z) + direccion * 18f;
            StartCoroutine(Boom());
        }
    }

    IEnumerator Boom()
    {
        camera.GetComponent<CameraController_2>().b_boomerangSonido = true;
        b_go = true;
        yield return new WaitForSeconds(.6f);
        if (b_teleport)
            StartCoroutine(MoverHaciaBoomerang());
        else
            b_go = false;
    }

    IEnumerator MoverHaciaBoomerang()
    {
        player.GetComponent<MovimientoPlayer_2>().f_gravity = 0;
        player.GetComponent<MovimientoPlayer_2>().v3_moveDirection.y = 0;
        while (Mathf.FloorToInt(player.transform.position.x) != Mathf.FloorToInt(transform.position.x) && Mathf.FloorToInt(player.transform.position.y) != Mathf.FloorToInt(transform.position.y))
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, Time.deltaTime * 30);
            yield return null;
        }
        player.GetComponent<MovimientoPlayer_2>().f_gravity = 80;
        b_go = false;
    }

    void Update()
    {
        if (b_clone)
        {
            if (b_go)
            {
                transform.position = Vector3.MoveTowards(transform.position, v3_locationInFrontOfPlayer, Time.deltaTime * 35);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Time.deltaTime * 35);
            }

            if (!b_go && Vector3.Distance(player.transform.position, transform.position) < 1.5)
            {
                AcabarBoomerang();
            }
            animator.SetBool("isAttacking", false);
        }
    }

    public void AcabarBoomerang()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject hijo = boomerang.transform.GetChild(i).gameObject;
            hijo.GetComponent<MeshRenderer>().enabled = true;
        }
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player" && b_clone && i_numeroJugador==2)
        {
            other.GetComponent<PlayerController_2>().Restar_Vida(i_daño);
        }
        if (other.tag == "Player2" && b_clone && i_numeroJugador == 1)
        {
            other.GetComponent<PlayerController_2>().Restar_Vida(i_daño);
        }


    }
}
