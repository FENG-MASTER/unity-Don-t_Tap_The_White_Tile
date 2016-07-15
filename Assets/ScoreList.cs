using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ScoreList : MonoBehaviour
{

    public UILabel label;

    void Start()
    {
        string list = "";

        foreach (KeyValuePair<string, int> pair in Score.getScoreMap())
        {
            list += pair.Key + ":" + pair.Value + "\n";
        }
        label.text = list;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync(0);
        }
    }


}
