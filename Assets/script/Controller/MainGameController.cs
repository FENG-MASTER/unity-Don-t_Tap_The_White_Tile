using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGameController : MonoBehaviour {

    public static MainGameController instance;
    

    public UILabel finalScore;
    public GameObject container;

    public BaseFactory factory;

    public GameObject rowPrefab;
    public GameObject block;

    public Sprite blackSprite;
    public Sprite whliteSprite;
    public Sprite whliteDownSprite;
    public Sprite DBSprite;

    private MyUtils.GameState gobalState = MyUtils.GameState.Ing;

	// Use this for initialization

    void Awake()
    {
        instance = this;
        int type=PlayerPrefs.GetInt("GameType");
        switch(type){
            case MyUtils.GameType.Classics:
                factory = new ClassicalFactory();
                break;
            case MyUtils.GameType.DBclick:
                factory = new DBlclickFactory();
                break;
            default:
                factory = new ClassicalFactory();
                break;
        }

    }
	void Start () {
       

      
	}
	
	// Update is called once per frame
	void Update () {
        factory.Build();
	
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
        factory.GameStateChange(gobalState);
        SendMessage("GameStateChange", gobalState);
    }

}
