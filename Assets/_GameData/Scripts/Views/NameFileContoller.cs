using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NameFileContoller : MonoBehaviour
{
    public TextAsset nameFile;
    public string[] names;
    public Text player1Name;
    public Text player2Name;
    // Start is called before the first frame update
    void Start()
    {
        ReadTextAsset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadTextAsset()
    {
        names = nameFile.text.Split(new string[] {",", "\n" }, StringSplitOptions.None);

        player1Name.text = PlayerPrefs.GetString("playerName");
        InvokeRepeating("Player2NameShuffle", 1.5f, 0.1f);
        Invoke("cancelNameShuffle", 3.0f);
    }

    void cancelNameShuffle()
    {
        CancelInvoke("Player2NameShuffle");
    }

    void Player2NameShuffle()
    {
        player2Name.text = names[Random.Range(0, names.Length - 1)];
    }
}
