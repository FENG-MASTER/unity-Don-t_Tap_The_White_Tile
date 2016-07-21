using UnityEngine;
using System.Collections;

public class ChaosGameController : BaseGameController
{
    private UILabel timer;
    private UILabel finalScore;
    private UILabel highestScore;
    private GameObject container;
    private UILabel goal;

    private int level = 1;
    private int scoreNeeded = 25;
    GameTimer.Timer t;

    private bool isReverse = false;

    public ChaosGameController(UILabel finalScore, UILabel highestScore, UILabel goal,
        GameObject container, UILabel timer, BaseFactory f)
    {
        this.finalScore = finalScore;
        this.container = container;
        this.factory = f;
        this.timer = timer;
        this.highestScore = highestScore;
        this.goal = goal;
        

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

        level = 1;
        t = new GameTimer.Timer(10, timer);
        ShowGoal();
        t.loop = true;
        t.Run = delegate()
        {
            isReverse = !isReverse;
            ((ClassicalFactory)factory).SetReverse(isReverse);
             ShowGoal();
        };
        GameTimer.instance.Add(t);


        TweenPosition p = container.GetComponent<TweenPosition>();//播放动画
        p.PlayReverse();
        MainGameController.instance.gobalState = MyUtils.GameState.Ing;

        MainGameController.instance.sendStateChangeMsg();
        Score.instacne.scoreVal = 0;
        isReverse = false;
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
        highestScore.text = "历史最高分:" + Score.instacne.GetCurrentHighestScore();
        container.SetActive(true);
        container.GetComponent<TweenPosition>().PlayForward();
        GameTimer.instance.Remove(t);//记得把计时器移除
        level = 1;
        scoreNeeded = 25;

    }

    private void ShowGoal()
    {
        goal.text = isReverse?"白":"黑";
    }
}
