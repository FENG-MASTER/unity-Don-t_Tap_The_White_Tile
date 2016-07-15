using UnityEngine;
using System.Collections;

public class ClassiaclGameController : BaseGameController {


    private UILabel finalScore;
    private GameObject container;

    public ClassiaclGameController(UILabel finalScore, GameObject container,BaseFactory f)
    {
        this.finalScore = finalScore;
        this.container = container;
        this.factory = f;

    }


    public override void startGame()
    {
        TweenPosition p = container.GetComponent<TweenPosition>();//播放动画
        p.PlayReverse();
        MainGameController.instance.gobalState = MyUtils.GameState.Ing;

        MainGameController.instance.sendStateChangeMsg();
        Score.instacne.scoreVal = 0;
    }

  
    public override void StopGame()
    {
        if (MainGameController.instance.gobalState == MyUtils.GameState.End)
        {
            return;
        }
        MainGameController.instance.gobalState = MyUtils.GameState.End;
        MainGameController.instance.sendStateChangeMsg();
        finalScore.text = "最终分数:" + Score.instacne.scoreVal;
        container.SetActive(true);
        container.GetComponent<TweenPosition>().PlayForward();
  
    }
}
