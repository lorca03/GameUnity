using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Windows;

public class FirebaseManager : MonoBehaviour
{
    private const string baseUrl = "https://neongame-guillermo-default-rtdb.europe-west1.firebasedatabase.app/ranking.json";

    void Start()
    {
        StartCoroutine(ObtenerRanking());
    }

    public void AgregarPuntajeAlRanking(string jugador, int puntaje)
    {
        //string jsonData = "{\"jugador\":\"" + jugador + "\", \"puntaje\":" + puntaje + "}";
        //StartCoroutine(EnviarPuntaje(url, jsonData));
    }

    //IEnumerator EnviarPuntaje(string url, string jsonData)
    //{
    //    using (UnityWebRequest www = UnityWebRequest.Put(url, jsonData))
    //    {
    //        www.method = UnityWebRequest.kHttpVerbPUT;
    //        www.SetRequestHeader("Content-Type", "application/json");

    //        yield return www.SendWebRequest();

    //        if (www.result != UnityWebRequest.Result.Success)
    //        {
    //            Debug.LogError(www.error);
    //        }
    //        else
    //        {
    //            Debug.Log("Puntaje enviado correctamente");
    //        }
    //    }
    //}

    IEnumerator ObtenerRanking()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(baseUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                string jsonText = www.downloadHandler.text;

                string cleanedJson = Regex.Replace(jsonText, "[{}\"]", "");
                Debug.Log(cleanedJson);

                //// Divide la cadena en pares clave-valor utilizando la coma como delimitador
                //string[] keyValuePairs = cleanedJson.Split(',');

                //// Imprime la información
                //foreach (var pair in keyValuePairs)
                //{
                //    string[] parts = pair.Split(':');
                //    string jugador = parts[0].Trim();
                //    string puntaje = parts[1].Trim();

                //    Debug.Log($"Jugador: {jugador}, Puntaje: {puntaje}");
                //}
            }
        }
    }

}
public class RankingData
{
    public string jugador;
    public string puntaje;
}
