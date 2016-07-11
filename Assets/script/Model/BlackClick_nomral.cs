﻿using UnityEngine;
using System.Collections;

public class BlackClick_nomral : ClickInterface {
    private GameObject parent;
    private Score score;
    private bool hasClicked=false;
  

    public BlackClick_nomral(GameObject parent)
    {
        this.parent = parent;
    }
    public  void OnClick()
    {
        Score.instacne.AddScore(1);
        hasClicked = true;
        //播放消失动画
        parent.GetComponent<TweenAlpha>().gameObject.SetActive(true);
        parent.GetComponent<TweenAlpha>().PlayForward();
    }
    public  void OnNoClick()
     {
        if(!hasClicked){
            MainGameController.instance.EndGame();
        }
     }

	
}
