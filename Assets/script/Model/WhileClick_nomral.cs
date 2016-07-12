using UnityEngine;
using System.Collections;

public class WhileClick_Nomral : ClickInterface {
    private Score score;
    private GameObject parent;

    public WhileClick_Nomral(GameObject parent)
    {
        this.parent = parent;
    }
    public void OnClick()
    {
        
        parent.GetComponent<TweenAlpha>().style = TweenAlpha.Style.PingPong;
        parent.GetComponent<TweenAlpha>().gameObject.SetActive(true);
        parent.GetComponent<TweenAlpha>().PlayForward();
        MainGameController.instance.EndGame();
    }
    public void OnNoClick()
    {
       
    }


}
