using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour {

    public static MainGameController instance;
    

    public UILabel finalScore;
    public GameObject container;
    public UILabel timer;

    private BaseFactory factory;//工厂类
    private BaseGameController gamecontroller;
    private BaseMoveManager moveManager;//移动控制器

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
                moveManager = new ClassicalMoveManager();
                break;
            case MyUtils.GameType.DBclick:
                factory = new DBlclickFactory();
                gamecontroller = new ClassiaclGameController(finalScore, container, factory);
                moveManager = new ClassicalMoveManager();
                break;
            case MyUtils.GameType.Timer:
                factory = new ClassicalFactory();
                gamecontroller = new TimerGameController(finalScore, container, timer, factory);
                moveManager = new ClickMoveManager();
                break;
            default:
                factory = new ClassicalFactory();
                gamecontroller = new ClassiaclGameController(finalScore, container, factory);
                moveManager = new ClassicalMoveManager();
                break;
        }

        gamecontroller.startGame();
        moveManager.Start();
      
	}
	
	// Update is called once per frame
	void Update () {
        gamecontroller.Update();
        moveManager.Update();
        if(Input.GetKeyDown(KeyCode.Escape)){
          
            SceneManager.LoadSceneAsync(1);
        }

	}

    public void RestartGame()
    {
        gamecontroller.startGame();
        DestroyAllBlock();
        moveManager.Start();

    }

    public void DestroyAllBlock()
    {

        List<GameObject> blockList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Row"));
        for (int i = 0; i < blockList.Count; i++)
        {
            blockList[i].GetComponent<Row>().DestroyChildren();
            DestroyImmediate(blockList[i]);//这个是立即销毁.如果用下面那条语句,将会延迟销毁,有BUG
            //    Destroy(blockList[i]);
        }
        blockList.Clear();
    }

    public void EndGame()
    {
        gamecontroller.StopGame();
        moveManager.Pause();
        return;
        if (gobalState == MyUtils.GameState.End)
        {
            return;
        }
        gobalState = MyUtils.GameState.End;
        sendStateChangeMsg();
        finalScore.text = "最终分数:" + Score.instacne.scoreVal;
        container.SetActive(true);
        container.GetComponent<TweenPosition>().PlayForward();


    }

   public void sendStateChangeMsg()
    {
        factory.GameStateChange(gobalState);
        SendMessage("GameStateChange", gobalState);
    }

}
