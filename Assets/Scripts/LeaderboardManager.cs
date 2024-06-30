using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using UnityEngine.XR;

public class LeaderboardManager : MonoBehaviour
{
    string leaderboardID = "23199";
    public TextMeshProUGUI names;
    public TextMeshProUGUI scores;
    public TextMeshProUGUI name;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    [System.Obsolete]
    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardID, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("Failed to upload score" + response.errorData.message);
            } else
            {
                Debug.Log("successfully uploaded score");
                StartCoroutine(FetchTopHighscoresRoutine());
            }
            done = true;
        });
#pragma warning restore CS0618 // Type or member is obsolete
        yield return new WaitWhile(() => done == false);
    }



    public IEnumerator FetchTopHighscoresRoutine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderboardID.ToString(), 5, 0, (response) =>
        {
            if (response.success)
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }
                done = true;
                names.text = tempPlayerNames;
                scores.text = tempPlayerScores;
            }
            else
            {
                Debug.Log("failed" + response.errorData.message);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    public IEnumerator ChangeName(string name)
    {
        bool done = false;
        LootLockerSDKManager.SetPlayerName(name, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("Name change failed" + response.errorData.message);
            }
            else
            {
                Debug.Log("name change succeded!!! u r amazing cole wow");
            }
            done = true;
        });
        yield return new WaitWhile(() => done == false);
        StartCoroutine(FetchTopHighscoresRoutine());
    }

    public void NameChange()
    {
        if (name.text != "Name")
        {
            StartCoroutine(ChangeName(name.text));
        }
    }

    public void SubmitScore(int score) {
        StartCoroutine(SubmitScoreRoutine(score));
    }
}