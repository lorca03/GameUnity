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
    public GameObject enviar;

    void Start()
    {
        enviar.SetActive(true);
        inputField.Select();
        StartCoroutine(MostrarRanking());
    }

    public void AgregarPuntajeAlRanking()
    {
        string data = inputField.text+ ":"+ puntuacion.text;
        StartCoroutine(EnviarPuntaje(baseUrl, data));
    }

    IEnumerator EnviarPuntaje(string url, string data)
    {
        string cleanedJson = "";
        yield return ObtenerRanking(result => cleanedJson = result);
        cleanedJson += ","+data;
        cleanedJson = ConvertStringToJson(cleanedJson);
        using (UnityWebRequest www = new UnityWebRequest(url, "PUT"))
        {
            www.method = UnityWebRequest.kHttpVerbPUT;
            www.SetRequestHeader("Content-Type", "application/json");
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(cleanedJson);
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
                StartCoroutine(MostrarRanking());
            }
        }
    }
    public static string ConvertStringToJson(string stringData)
    {
        string[] entries = stringData.Split(',', StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        foreach (string entry in entries)
        {
            string[] parts = entry.Split(':');
            dictionary[parts[0]] = parts[1] + ":" + parts[2] + ":" + parts[3];
        }
        string json = "{";
        foreach (KeyValuePair<string, string> entry in dictionary)
        {
            json += "\"" + entry.Key + "\":\"" + entry.Value + "\",";
        }
        json = json.Substring(0, json.Length - 1);
        json += "}";
        return json;
    }

    IEnumerator ObtenerRanking(Action<string> callback) 
    {
        using (UnityWebRequest www = UnityWebRequest.Get(baseUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
                callback("");
            }
            else
            {
                string jsonText = www.downloadHandler.text;
                string cleanedJson = limpiarJSON(jsonText);
                callback(cleanedJson);
            }
        }
        
    }

    public String limpiarJSON(string jsontext) 
    {
        return Regex.Replace(jsontext, "[{}\"]", "");
    }

    public IEnumerator MostrarRanking()
    {
        string cleanedJson = "";
        yield return ObtenerRanking(result => cleanedJson = result);
        if (cleanedJson != "")
        {
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
                if (cont < nombres.Length && cont < puntuaciones.Length)
                {
                    nombres[cont].text = item.nombre;
                    puntuaciones[cont].text = item.contador;
                    cont++;
                }
            }
        }
    }

}
