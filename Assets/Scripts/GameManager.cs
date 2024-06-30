
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;

    public LeaderboardManager leaderboard;
    public TextMeshProUGUI scoreText;
    public TMP_InputField name;
    void Start()
    {
        score = CharacterMovement.score;   
        scoreText.text = "" + score;
        StartCoroutine(SetupRoutine());
        
    }

    [System.Obsolete]
    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderboard.SubmitScoreRoutine(score);
        yield return leaderboard.FetchTopHighscoresRoutine();
        GetName();
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");
                done = true;
            } else
            {
                Debug.Log("successfully started LootLocker session");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            
        });
        yield return new WaitWhile(() => done == false);
    }

    public void GetName()
    {
        LootLockerSDKManager.GetPlayerName((response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully retrieved player name: " + response.name);
                name.text = response.name;
            } else
            {
                Debug.Log("Error getting player name");
            }
        });
    }

    public void PlayAgain() {
        SceneManager.LoadScene(1);
    }
}
