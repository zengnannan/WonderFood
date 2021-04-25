using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTutorial : MonoBehaviour
{
    private TutorialBoard tutorialBoard;
    private TutorialSound tutorialSound;
    public List<TutorialImage> imageList;
    private bool finishedThirdSound;
    public GameObject ArrowOrder;
    public GameObject ArrowButton;
    public GameObject Net;
    public GameObject Pan;
    public GameObject RestartButton;
    public GameObject MainMenuButton;
    public GameObject Order;

    public static bool FirstPickup;
    public bool doOnce;
    public bool ready;
    public bool finishedTenVoice;

    void Awake()
    {
        tutorialBoard = FindObjectOfType<TutorialBoard>();
        tutorialSound = FindObjectOfType<TutorialSound>();
        finishedThirdSound = false;
        FirstPickup = false;
        ArrowOrder.SetActive(false);
        ArrowButton.SetActive(false);
        Net.SetActive(false);
        Pan.SetActive(false);
        RestartButton.SetActive(false);
        MainMenuButton.SetActive(false);
        doOnce = true;
        ready = false;
        finishedTenVoice = false;
        Order.SetActive(false);
    }

    void Update()
    {
        if (FirstPickup == true && finishedThirdSound == true && doOnce)
        {
            tutorialSound.PlaySound(4, PlayFifthSoundAndBoardDown);
            doOnce = false;
        }

        if (finishedTenVoice==true)
        {
            if (Pan.activeSelf==true&&Net.activeSelf==true)
            {
                Debug.Log("Pan"+Pan.GetComponent<GrabObjectInteraction>().hasPickedUp);
                if (Pan.GetComponent<GrabObjectInteraction>().hasPickedUp == true && Net.GetComponent<GrabObjectInteraction>().hasPickedUp == true )
                {
                  ready = true;
                }
            }
            
        }
    }
    void Start()
    {
        StartCoroutine(PlayFirstSound());
    }

    IEnumerator PlayFirstSound()
    {
        yield return new WaitForSeconds(3);
        tutorialSound.PlaySound(1, PlaySecondAndThirdSound);
        ArrowOrder.SetActive(false);
    }

    void PlaySecondAndThirdSound()
    {
        tutorialSound.PlaySound(2, PlayThirdSound);
    }

    void PlayThirdSound()
    {
        tutorialSound.PlaySound(3, FinishThirdSound);
    }

    void FinishThirdSound()
    {
        finishedThirdSound = true;
    }

    void PlayFifthSoundAndBoardDown()
    {
        tutorialSound.PlaySound(5,PlaySixSound);
        tutorialBoard.GoingDown();
        StartCoroutine(BoardDownest());


    }

    void PlaySixSound()
    {
        tutorialSound.PlaySound(6, PlaySeventhAndEighthSound);
        ArrowOrder.SetActive(true);
        Order.SetActive(true);
    }

    IEnumerator BoardDownest()
    {
        yield return new WaitForSeconds(tutorialBoard.duration);
        ShowPicture(1);
        
    }

    void PlaySeventhAndEighthSound()
    {
        tutorialSound.PlaySound(7,PlayEighthSoundAndNineSound);

    }

    void PlayEighthSoundAndNineSound()
    {
      tutorialSound.PlaySound(8, PlayNinthSound);
      StartCoroutine(ShowConsAndShowSecondPic());
    }
    IEnumerator ShowConsAndShowSecondPic()
    {
        yield return new WaitForSeconds(3);
        Net.SetActive(true);
        Pan.SetActive(true);
        HidePicture(1);
        ShowPicture(2);
        

    }

    void PlayNinthSound()
    {
        tutorialSound.PlaySound(9, PlayTenSound);
        HidePicture(2);
        ShowPicture(3);
    }

    void PlayTenSound()
    {
        tutorialSound.PlaySound(10,FinishedTenVoice);
        HidePicture(3);
        ShowPicture(4);
        ArrowButton.SetActive(true);
        RestartButton.SetActive(true);
        MainMenuButton.SetActive(true);
        
    }

    private void FinishedTenVoice()
    {
       finishedTenVoice = true;
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
