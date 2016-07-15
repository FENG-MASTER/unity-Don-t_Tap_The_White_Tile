using UnityEngine;
using System.Collections;

public class TimerGameController : BaseGameController {

    private UILabel timer;
    private UILabel finalScore;
    private GameObject container;

    GameTimer.Timer t;

    public TimerGameController(UILabel finalScore, GameObject container,UILabel timer, BaseFactory f)
    {
        this.finalScore = finalScore;
        this.container = container;
        this.factory = f;
        this.timer = timer;

    }

    public override void Pause()
    {
        base.Pause();
        t.PauseTiming();
    }

    public override void Start()
    {
        base.Start();
        t.StartTiming();
    }


    public override void startGame()
    {
        int scoreNeeded = 20;

        t = new GameTimer.Timer(10, timer);
        t.loop = true;
        t.Run = delegate()
        {
            if (Score.instacne.scoreVal > scoreNeeded)
            {
                scoreNeeded += 20;
            }
            else
            {
                t.loop = false;
                t.StopTiming();
                StopGame();
            }
        };
        GameTimer.instance.Add(t);

       
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
        GameTimer.instance.Remove(t);//记得把计时器移除

    }
}
