using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private TutorialBoard tutorialBoard;
    public List<TutorialImage> imageList;
    void Start()
    {
        tutorialBoard = FindObjectOfType<TutorialBoard>();
        StartCoroutine(FirstBoard());

    }

    IEnumerator FirstBoard()
    {
        tutorialBoard.GoingDown();
        yield return new WaitForSeconds(tutorialBoard.duration);
        imageList[0].ShowImage();
    }


}
