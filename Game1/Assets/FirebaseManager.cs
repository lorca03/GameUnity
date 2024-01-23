using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class FirebaseManager : MonoBehaviour
{
    private const string baseUrl = "https://neongame-guillermo-default-rtdb.europe-west1.firebasedatabase.app/ranking.json";
    public TextMeshProUGUI[] nombres;
    public TextMeshProUGUI[] puntuaciones;
    public TextMeshProUGUI puntuacion;
    public TMP_InputField inputField;

    void Start()
    {
        StartCoroutine(ObtenerRanking());
    }

    public void Hola()
    {
        Debug.Log("ey");
    }

    //public void AgregarPuntajeAlRanking()
    //{
    //    string data = inputField.text + ":"+puntuacion;
    //    StartCoroutine(EnviarPuntaje(baseUrl, data));
    //}

    //IEnumerator EnviarPuntaje(string url, string data)
    //{
    //    using (UnityWebRequest www = UnityWebRequest.Put(url, data))
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

    public void AgregarPuntajeAlRanking()
    {
        string data = $"{{\"{inputField.text}\":\"{puntuacion.text}\"}}";
        StartCoroutine(EnviarPuntaje(baseUrl, data));
    }

    IEnumerator EnviarPuntaje(string url, string data)
    {
        using (UnityWebRequest www = new UnityWebRequest(url, "PUT"))
        {
            www.method = UnityWebRequest.kHttpVerbPUT;
            www.SetRequestHeader("Content-Type", "application/json");
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(data);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log(data);
                Debug.Log("Puntaje enviado correctamente");
                //StartCoroutine(ObtenerRanking());
            }
        }
    }

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

                string[] partes = cleanedJson.Split(',');
                int cont = 0;

                var dataList = new List<(string nombre, string contador)>();

                foreach (var parte in partes)
                {
                    string[] part = parte.Split(':');

                    string nombre = part[0];
                    string contador = string.Join(":", part.Skip(1));

                    dataList.Add((nombre, contador));
                    cont++;
                }

                var orderedDataList = dataList.OrderBy(x => TimeSpan.Parse("00:" + x.contador)).ToList();
                cont = 0;

                foreach (var item in orderedDataList)
                {
                    nombres[cont].text = item.nombre;
                    puntuaciones[cont].text = item.contador;
                    cont++;
                }
            }
        }
    }

}
