using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour {

    public static MainGameController instance;
    

    public UILabel finalScore;
    public GameObject container;
    public UILabel timer;
    public UILabel pauseLabel;

    private BaseFactory factory;//工厂类
    private BaseGameController gamecontroller;
    private BaseMoveManager moveManager;//移动控制器

    public MyUtils.GameState gobalState = MyUtils.GameState.Ing;

    private bool pause = false;

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
            case MyUtils.GameType.RollerCoaster:
                 factory = new ClassicalFactory();
                 gamecontroller = new ClassiaclGameController(finalScore, container, factory);
                moveManager = new RandomSpeedMoveManager();
                break;

            case MyUtils.GameType.TwoHand:
                factory = new ClassicalFactory(6,2);
                gamecontroller = new ClassiaclGameController(finalScore,container,factory);
                moveManager = new ClassicalMoveManager();
                break;

            case MyUtils.GameType.PlusOne:
                factory = new ClassicalFactory(5,1);
                gamecontroller = new ClassiaclGameController(finalScore,container,factory);
                moveManager = new ClassicalMoveManager();
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
            if(gobalState==MyUtils.GameState.Ing){
                PauseGame();            
            }
           
        }

	}

    public void PauseGame()
    {
        if(pause){
            gamecontroller.Start();
            moveManager.Start();
            pause = false;
            HidePause();
        }
        else
        {
            gamecontroller.Pause();
            moveManager.Pause();
            ShowPause();
            pause = true;
        }
      
    }

    public void RestartGame()
    {
        DestroyAllBlock();
        gamecontroller.startGame();
        moveManager.Start();
        pause = false;

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
        Score.instacne.SaveCurentScore();
        gamecontroller.StopGame();
        moveManager.Pause();
    }

   public void sendStateChangeMsg()
    {
        factory.GameStateChange(gobalState);
        SendMessage("GameStateChange", gobalState);
    }


   private void ShowPause() {
       pauseLabel.gameObject.SetActive(true);
       pauseLabel.GetComponent<TweenAlpha>().PlayForward();
   }

   private void HidePause()
   {
       pauseLabel.GetComponent<TweenAlpha>().PlayReverse();
   }

}
