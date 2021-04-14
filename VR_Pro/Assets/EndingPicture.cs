using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPicture : MonoBehaviour
{
    private TutorialBoard Board;
    // Start is called before the first frame update
    void Start()
    {
        Board = FindObjectOfType<TutorialBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Board.transform.position + new Vector3(0, 0, -0.1f);
    }
}
