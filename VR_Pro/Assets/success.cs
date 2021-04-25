using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class success : MonoBehaviour
{
    [SerializeField] private GameObject[] successButtons;
    public Text ScoreText;
    public void ShowSuccessButtons()
    {
        Debug.Log("Show Button");
        foreach (var button in successButtons)
        {
            button.SetActive(true);
        }
    }

    private void Update()
    {
        ScoreText.text = ScoreManager.instance.currentScore.ToString();
    }
}
