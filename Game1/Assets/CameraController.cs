using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject Player;
    GameObject playercControl;
    private Vector3 v3_Posicion;

    public float f_Velocidad;
    public bool b_boomerangSonido;
    public float f_xAjustePosicion;
    public float f_yAjustePosicion;
    public float f_Zoom;
    public AudioClip boomerangAudio;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<MovimientoPlayer>().gameObject;
        playercControl = FindObjectOfType<PlayerController>().gameObject;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        v3_Posicion = new Vector3(Player.transform.position.x + f_xAjustePosicion, Player.transform.position.y + f_yAjustePosicion, f_Zoom);

        transform.position = Vector3.Lerp(transform.position, v3_Posicion, f_Velocidad * Time.deltaTime);
        if (playercControl.GetComponent<PlayerController>().b_Muerto)
        {
            audioSource.Stop();
        }
        else if(b_boomerangSonido)
        {
            AudioSource tempAudioSource = gameObject.AddComponent<AudioSource>();
            float volumenOriginal = tempAudioSource.volume;
            tempAudioSource.volume = 0.8f;
            tempAudioSource.PlayOneShot(boomerangAudio);
            tempAudioSource.volume = volumenOriginal;
            Destroy(tempAudioSource, boomerangAudio.length);
            b_boomerangSonido = false;
        }
    }


}
