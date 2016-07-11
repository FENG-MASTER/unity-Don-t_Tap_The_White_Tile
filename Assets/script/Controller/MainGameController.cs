﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGameController : MonoBehaviour {

    public static MainGameController instance;

    public UILabel finalScore;
    public GameObject container;

    private MyUtils.GameState gobalState = MyUtils.GameState.Ing;

	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RestartGame()
    {
        GameObject.Find("manager").GetComponent<MoveManager>().ReStart();
        TweenPosition p = container.GetComponent<TweenPosition>();//播放动画
        p.PlayReverse();
        gobalState = MyUtils.GameState.Ing;
        sendStateChangeMsg();
        Score.instacne.scoreVal = 0;

    }

    public void EndGame()
    {
        if (gobalState == MyUtils.GameState.End)
        {
            return;
        }
        gobalState = MyUtils.GameState.End;
        sendStateChangeMsg();
        finalScore.text = "最终分数:" + Score.instacne.scoreVal;
        container.SetActive(true);
        container.GetComponent<TweenPosition>().PlayForward();
        GameObject.Find("manager").GetComponent<MoveManager>().Pause();

    }

    void sendStateChangeMsg()
    {
        SendMessage("GameStateChange", gobalState);
    }

}