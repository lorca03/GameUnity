using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BoomerangController : MonoBehaviour
{
    public bool b_clone = false;
    public bool b_teleport = false;
    int i_da�o;
    bool b_go;
    GameObject player;
    GameObject boomerang;
    Vector3 v3_locationInFrontOfPlayer;
    Animator animator;

    void Start()
    {
        b_go = false;
        i_da�o = 25;

        player = GameObject.Find("Chc_Personaje");
        boomerang = GameObject.Find("boomerang");
        animator = GameObject.Find("Ch44_nonPBR").GetComponent<Animator>();

        Vector3 direccion = player.transform.root.localScale.x == 1 ? Vector3.right : Vector3.left;

        if (b_clone)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject hijo = boomerang.transform.GetChild(i).gameObject;
                hijo.GetComponent<MeshRenderer>().enabled = false;
            }

            v3_locationInFrontOfPlayer = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z) + direccion * 15f;
            StartCoroutine(Boom());
        }
    }

    IEnumerator Boom()
    {
        b_go = true;
        yield return new WaitForSeconds(.6f);Debug.Log(b_teleport);
        if (b_teleport)
            IrHaciaBoomerang();
        else
            b_go = false;
    }

    public void IrHaciaBoomerang()
    {
        StartCoroutine(MoverHaciaBoomerang());
        
    }

    IEnumerator MoverHaciaBoomerang()
    {
        player.GetComponent<MovimientoPlayer>().f_gravity = 0;
        while (Mathf.FloorToInt(player.transform.position.x) != Mathf.FloorToInt(transform.position.x))
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, Time.deltaTime * 25);
            yield return null;
        }
        player.GetComponent<MovimientoPlayer>().f_gravity = 15;
        b_go = false;
    }

    void Update()
    {
        if (b_clone)
        {
            if (b_go)
            {
                transform.position = Vector3.MoveTowards(transform.position, v3_locationInFrontOfPlayer, Time.deltaTime * 25);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Time.deltaTime * 25); //Return To Player
            }

            if (!b_go && Vector3.Distance(player.transform.position, transform.position) < 1.5)
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject hijo = boomerang.transform.GetChild(i).gameObject;
                    hijo.GetComponent<MeshRenderer>().enabled = true;
                }
                Destroy(this.gameObject);
            }
            animator.SetBool("isAttacking", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && b_clone)
        {
            other.GetComponent<EnemyController>().RestarVida(i_da�o);
        }
    }
}
