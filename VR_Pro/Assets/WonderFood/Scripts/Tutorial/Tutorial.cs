using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.XR.Interaction.Toolkit;

public class Tutorial : MonoBehaviour
{
    private TutorialBoard tutorialBoard;
    public List<TutorialImage> imageList;
    private TutorialSound tutorialSound;
    private TutorialOrder tutorialOrder;
    private XRSocketInteractor snap;

    private bool FinishedSecondSound;
    private bool FinishedThirdSound;
    private bool FinishedFifthSound;
    private bool FinishedSixthSound;

    private bool FinishedPicture2;
    private bool FinishedPicture3;
    private bool FinishedPicture5;

    public bool ready;
 

    private bool playOnce;
    private bool playOnce2;
    private bool playOnce3;
    private bool playOnce4;
    private bool playOnce5;
    private bool playOnce6;

    public GameObject Pan;
    public GameObject Wangzi;
    void Awake()
    {
        tutorialBoard = FindObjectOfType<TutorialBoard>();
        tutorialSound = FindObjectOfType<TutorialSound>();
        tutorialOrder = FindObjectOfType<TutorialOrder>();
        snap = FindObjectOfType<XRSocketInteractor>();

        FinishedSecondSound = false;
        FinishedThirdSound = false;
        FinishedPicture2 = false;
        FinishedPicture3=false;
        FinishedPicture5 = false;
        FinishedFifthSound =false;
        FinishedSixthSound = false;
        ready=false;

        playOnce = false;
        playOnce2 = false;
        playOnce3 = false;
        playOnce4 = false;
        playOnce5 = false;
        playOnce6 = false;
    }
    void Start()
    {
        //Phase1
        StartCoroutine(FirstBoard());
        snap.gameObject.SetActive(false);
    }

    void Update()
    {
        if (FinishedSecondSound)
        {
            if (tutorialOrder.gameObject.GetComponent<GrabObjectInteraction>().hasPickedUp&& playOnce==false)
            {
                
                playOnce = true;
                tutorialSound.PlaySound(3,ChangeToPicture2);
                
            }
        }

        if (FinishedPicture2&&playOnce2==false)
        {
            tutorialSound.PlaySound(4,ChangeToPicture3);
            playOnce2 = true;
        }

        if (FinishedPicture3&&playOnce3==false)
        {
            ChangeToPicture4_2();
            playOnce3 = true;
        }

        if (FinishedFifthSound&&playOnce4==false)
        {
            tutorialSound.PlaySound(6,finishSixthSound);
            playOnce4 = true;
        }

        if (FinishedSixthSound==true)
        {
            snap.gameObject.SetActive(true);
            if (tutorialOrder.GetComponent<TutorialOrder>().haveHang == true&&playOnce5==false)
            {
                ChangeToPicture5();
                playOnce5 = true;
            }
        }

        if (FinishedPicture5==true)
        {
            if (Pan.GetComponent<GrabObjectInteraction>().hasPickedUp==true&&Wangzi.GetComponent<GrabObjectInteraction>().hasPickedUp==true&&playOnce6==false)
            {
                ready = true;
                playOnce6 = true;
            }

            
        }

    }

    IEnumerator FirstBoard()
    {
        
        tutorialBoard.GoingDown();
        yield return new WaitForSeconds(tutorialBoard.duration);
        ShowPicture(1);
        
        tutorialSound.PlaySound(1,PlaySecoundSound);

    }

    private void FinishSecondSound()
    {
        FinishedSecondSound = true;
        
    }

    private void FinishThirdSound()
    {
        FinishedThirdSound = true;
    }

    private void finishFifthSound()
    {
       FinishedFifthSound = true;
    }
    private void finishSixthSound()
    {
        FinishedSixthSound = true;
    }
    private void PlaySecoundSound()
    {
        tutorialSound.PlaySound(2,FinishSecondSound);
        tutorialOrder.GetComponent<MeshRenderer>().enabled = true;
    }


    private void ChangeToPicture2()
    {
        HidePicture(1);
        ShowPicture(2);
        FinishedPicture2 = true;
    }

    private void ChangeToPicture3()
    {
        tutorialSound.PlaySound(5,finishFifthSound);
        HidePicture(2);
        ShowPicture(3);
        FinishedPicture3 = true;
    }
    private void ChangeToPicture4_2()
    {
        StartCoroutine(ChangeToPicture4());
    }
    private IEnumerator ChangeToPicture4()
    {
        yield return new WaitForSeconds(4);
        HidePicture(3);
        ShowPicture(4);
    }

    private void ChangeToPicture5()
    {
        HidePicture(4);
        ShowPicture(5);
        FinishedPicture5 = true;
        tutorialSound.PlaySound(7);
    }
    private void ShowPicture(int i)
    {
        imageList[i-1].ShowImage();
    }

    private void HidePicture(int i)
    {
        imageList[i-1].HideImage();
    }


}
