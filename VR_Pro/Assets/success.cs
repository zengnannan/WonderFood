using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class success : MonoBehaviour
{
    [SerializeField] private GameObject[] successButtons;

    public void ShowSuccessButtons()
    {
        foreach (var button in successButtons)
        {
            button.SetActive(true);
        }
    }
}
