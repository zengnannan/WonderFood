using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{

    public static float lastPlayerScore;
    public static float lastHighestScore;

    private float currentPlayerScore;
    private float currentHighestScore;

    private bool doOnce;

    public Text PlayerScoreText;

    private GameObject SuccessCon;

    public List<GameObject> RankList;

    // Start is called before the first frame update
    void Start()
    {
        doOnce = true;
        lastHighestScore = PlayerPrefs.GetFloat("SystemScore");
        lastPlayerScore = PlayerPrefs.GetFloat("PlayerScore");
        SuccessCon = GameObject.Find("Congratulation");

    }

    // Update is called once per frame
    void Update()
    {
        if (doOnce && SuccessCon.GetComponent<CanvasGroup>().alpha == 1)
        {
            var playerScore = PlayerPrefs.GetFloat("PlayerScore");
            var Highestscore = PlayerPrefs.GetFloat("SystemScore");
            playerScore += ScoreManager.instance.currentScore;
            Highestscore += ScoreManager.HighestScore;
            PlayerPrefs.SetFloat("PlayerScore", playerScore);
            PlayerPrefs.SetFloat("SystemScore", Highestscore);

            currentHighestScore = Highestscore;
            currentPlayerScore = playerScore;

            PlayerScoreText.text = ""+(int)PlayerPrefs.GetFloat("PlayerScore");
        }

        if (currentHighestScore != 0 && UITimer.instance.currentTime <= 0 && currentPlayerScore != 0) 
        {
            
            if (currentPlayerScore / currentHighestScore <= 0.7)
            {
                RankList[0].gameObject.SetActive(true);
            }
            else if (currentPlayerScore / currentHighestScore > 0.7 && currentPlayerScore / currentHighestScore <= 0.8)
            {

                RankList[1].gameObject.SetActive(true);
            }
            else if (currentPlayerScore / currentHighestScore > 0.8 && currentPlayerScore / currentHighestScore <= 0.9)
            {

                RankList[2].gameObject.SetActive(true);
            }
            else if (currentPlayerScore / currentHighestScore > 0.9 && currentPlayerScore / currentHighestScore <= 0.95)
            {

                RankList[3].gameObject.SetActive(true);
            }
            else if (currentPlayerScore / currentHighestScore > 0.95 && currentPlayerScore / currentHighestScore < 1)
            {

                RankList[4].gameObject.SetActive(true);
            }
            else if (currentPlayerScore / currentHighestScore == 1)
            {
                RankList[5].gameObject.SetActive(true);
            }

        }

    }
}
