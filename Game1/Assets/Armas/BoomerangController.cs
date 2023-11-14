using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BoomerangController : MonoBehaviour
{
    public bool b_clone = false;
    bool b_go;
    GameObject player;
    GameObject boomerang;
    Vector3 locationInFrontOfPlayer;
    Animator animator;

    void Start()
    {
        //Vector3 direccion = manoJugador.transform.root.localScale.x == 1 ? Vector3.right : Vector3.left;

        b_go = false;

        player = GameObject.Find("Chc_Personaje");
        boomerang = GameObject.Find("boomerang");
        animator = GameObject.Find("Ch44_nonPBR").GetComponent<Animator>();

        if (b_clone)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject hijo = boomerang.transform.GetChild(i).gameObject;
                hijo.GetComponent<MeshRenderer>().enabled = false;
            }

            locationInFrontOfPlayer = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z) + player.transform.right * 10f;

            StartCoroutine(Boom());
        }
    }

    IEnumerator Boom()
    {
        b_go = true;
        yield return new WaitForSeconds(.1f);
        b_go = false;
    }

    void Update()
    {
        if (b_clone)
        {

            if (b_go)
            {
                transform.position = Vector3.MoveTowards(transform.position, locationInFrontOfPlayer, Time.deltaTime * 40);           
            }

            if (!b_go)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Time.deltaTime * 30); //Return To Player
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
        if (other.tag == "Enemy")
        {
            Debug.Log("");
        }
    }
}
