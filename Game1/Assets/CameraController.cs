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
        CambiarPosicion(f_Zoom, f_xAjustePosicion,f_yAjustePosicion);
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

    public void CambiarPosicion(float zoom,float xAjustePosicion,float yAjustePosicion)
    {
        v3_Posicion = new Vector3(Player.transform.position.x + xAjustePosicion, Player.transform.position.y + yAjustePosicion, zoom);

        transform.position = Vector3.Lerp(transform.position, v3_Posicion, f_Velocidad * Time.deltaTime);
    }


}
