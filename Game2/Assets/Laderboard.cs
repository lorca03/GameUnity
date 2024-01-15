using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class Laderboard : MonoBehaviour
{
   [SerializeField] private List<TextMeshProUGUI> names;
   [SerializeField] private List<TextMeshProUGUI> scores;

    private string publicLeaderKey = "da5f7ab45ff9e0da0df3c9c1fc9672e3e835781ef0c312a230c4f921d4c1be9e";

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderKey, ((msg) =>
        {
            for (int i = 0; i < names.Count; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderKey, username, score, 
            ((msg) =>{
                //if (System.Array.IndexOf(badWords, name) != -1) return;
            //username.Substring(0, 4);
            GetLeaderboard();
        }));
    }
}
