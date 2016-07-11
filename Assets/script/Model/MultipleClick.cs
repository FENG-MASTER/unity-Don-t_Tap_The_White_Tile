using UnityEngine;
using System.Collections;

public class MultipleClick : ClickInterface
{
    private int clickTimes;
    private int hasClick;
    private GameObject gameobj;

    public MultipleClick(GameObject obj,int times)
    {
        clickTimes = times;
        hasClick = clickTimes;
        gameobj = obj;
    }

    public void OnClick()
    {
        hasClick--;
        gameobj.GetComponent<SpriteRenderer>().color = new Color(0,0,0,((float)hasClick)/clickTimes);
        if (hasClick < 0)
        {
            MainGameController.instance.EndGame();
        }

    }

    public void OnNoClick()
    {
        if (hasClick != 0)
        {
            MainGameController.instance.EndGame();
        }
    }
}
