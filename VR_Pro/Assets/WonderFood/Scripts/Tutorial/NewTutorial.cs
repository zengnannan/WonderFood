using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTutorial : MonoBehaviour
{
    private TutorialBoard tutorialBoard;
    private TutorialSound tutorialSound;
    public List<TutorialImage> imageList;
    private bool finishedThirdSound;

    public static bool FirstPickup;

    void Awake()
    {
        tutorialBoard = FindObjectOfType<TutorialBoard>();
        tutorialSound = FindObjectOfType<TutorialSound>();
        finishedThirdSound = false;
        FirstPickup = false;
    }

    void Update()
    {
        if (FirstPickup==true&&finishedThirdSound==true)
        {
            tutorialSound.PlaySound(4,PlayFifthSoundAndBoardDown);
        }
    }
    void Start()
    {
        StartCoroutine(PlayFirstSound());
    }

    IEnumerator PlayFirstSound()
    {
        yield return new WaitForSeconds(3);
        tutorialSound.PlaySound(1,PlaySecondAndThirdSound);
    }

    void PlaySecondAndThirdSound()
    {
        tutorialSound.PlaySound(2,PlayThirdSound);
    }

    void PlayThirdSound()
    {
        tutorialSound.PlaySound(3,FinishThirdSound);
    }

    void FinishThirdSound()
    {
        finishedThirdSound = true;
    }

    void PlayFifthSoundAndBoardDown()
    {
        tutorialSound.PlaySound(5);
        tutorialBoard.GoingDown();

    }

    IEnumerator BoardDownest()
    {
        yield return new WaitForSeconds(tutorialBoard.duration);
        ShowPicture(1);
        tutorialSound.PlaySound(6);
    }

    private void ShowPicture(int i)
    {
        imageList[i - 1].ShowImage();
    }

    private void HidePicture(int i)
    {
        imageList[i - 1].HideImage();
    }

}
