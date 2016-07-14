using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGameController : MonoBehaviour {

    public static MainGameController instance;
    

    public UILabel finalScore;
    public GameObject container;
    public UILabel timer;

    private BaseFactory factory;//工厂类
    private BaseGameController gamecontroller;

    public MyUtils.GameState gobalState = MyUtils.GameState.Ing;

	// Use this for initialization

    void Awake()
    {
        instance = this;
    }
	void Start () {
        int type = PlayerPrefs.GetInt("GameType");
        switch (type)
        {
            case MyUtils.GameType.Classics:
                factory = new ClassicalFactory();
                gamecontroller = new ClassiaclGameController(finalScore,container,factory);
                break;
            case MyUtils.GameType.DBclick:
                factory = new DBlclickFactory();
                gamecontroller = new ClassiaclGameController(finalScore, container, factory);
                break;
            case MyUtils.GameType.Timer:
                factory = new ClassicalFactory();
                gamecontroller = new TimerGameController(finalScore, container, timer, factory);
                break;
            default:
                factory = new ClassicalFactory();
                gamecontroller = new ClassiaclGameController(finalScore, container, factory);
                break;
        }

        gamecontroller.startGame();
     
      
	}
	
	// Update is called once per frame
	void Update () {
        gamecontroller.Update();
	}

    public void RestartGame()
    {
        gamecontroller.startGame();
        return;
        GameObject.Find("manager").GetComponent<MoveManager>().ReStart();
        TweenPosition p = container.GetComponent<TweenPosition>();//播放动画
        p.PlayReverse();
        gobalState = MyUtils.GameState.Ing;
        sendStateChangeMsg();
        Score.instacne.scoreVal = 0;

    }

    public void EndGame()
    {
        gamecontroller.StopGame();
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

   public void sendStateChangeMsg()
    {
        factory.GameStateChange(gobalState);
        SendMessage("GameStateChange", gobalState);
    }

}
