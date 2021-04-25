using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel : MonoBehaviour
{
    public static GameObject PaiPrefab;
    public static GameObject JiePrefab;

    public static void ShowText(GameObject prefab)
    {
        prefab.SetActive(true);
    }
}
