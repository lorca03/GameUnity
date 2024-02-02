using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class RankingManager : MonoBehaviour
{
    private const string baseUrl = "https://neongame-guillermo-default-rtdb.europe-west1.firebasedatabase.app/ranking.json";
    public TextMeshProUGUI[] nombres;
    public TextMeshProUGUI[] puntuaciones;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MostrarRanking());
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
