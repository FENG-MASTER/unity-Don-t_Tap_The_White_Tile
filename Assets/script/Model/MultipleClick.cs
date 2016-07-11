using UnityEngine;
using System.Collections;

public class MultipleClick : ClickInterface
{
    private int clickTimes;
    private GameObject gameobj;

    public MultipleClick(GameObject obj,int times)
    {
        clickTimes = times;
        gameobj = obj;
    }

    public void OnClick()
    {
        clickTimes--;
        gameobj.GetComponent<SpriteRenderer>().color = new Color(150,0,0,0);
        if(clickTimes<0){
            MainGameController.instance.EndGame();
        }

    }

    public void OnNoClick()
    {
        if(clickTimes!=0){
            MainGameController.instance.EndGame();
        }
    }
}
