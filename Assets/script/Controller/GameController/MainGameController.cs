using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour {

    public static MainGameController instance;//单例模式实例
    

    public UILabel finalScore;//显示最终分数的label
    public GameObject container;//显示分数的父窗口
    public UILabel timer;//计时器显示label
    public UILabel pauseLabel;
    public UILabel highestScore;
    public UILabel gameType;
    public UILabel goal;

    private BaseFactory factory;//工厂类
    private BaseGameController gamecontroller;//游戏控制器
    private BaseMoveManager moveManager;//移动控制器

    public MyUtils.GameState gobalState = MyUtils.GameState.Ing;//游戏状态

    private bool pause = false;//是否正在暂停

    void Awake()
    {
        instance = this;//设置自己为单例的一个实例
    }
	void Start () {
        //根据playprefs传来的参数,确定游戏模式

        int type = PlayerPrefs.GetInt("GameType");
        switch (type)
        {
            case MyUtils.GameType.Classics://经典模式
                factory = new ClassicalFactory();
                gamecontroller = new ClassiaclGameController(finalScore, highestScore, container, factory);
                moveManager = new ClassicalMoveManager();
                break;
            case MyUtils.GameType.DBclick://击破模式
                factory = new DBlclickFactory();
                gamecontroller = new ClassiaclGameController(finalScore, highestScore, container, factory);
                moveManager = new ClassicalMoveManager();
                break;
            case MyUtils.GameType.Timer://计时模式
                factory = new ClassicalFactory();
                gamecontroller = new TimerGameController(finalScore, highestScore, goal, container, timer, factory);
                moveManager = new ClickMoveManager();
                break;
            case MyUtils.GameType.RollerCoaster://过山车模式
                 factory = new ClassicalFactory();
                 gamecontroller = new ClassiaclGameController(finalScore, highestScore, container, factory);
                moveManager = new RandomSpeedMoveManager();
                break;
            case MyUtils.GameType.TwoHand://双手模式
                factory = new ClassicalFactory(6,2);
                gamecontroller = new ClassiaclGameController(finalScore, highestScore, container, factory);
                moveManager = new ClassicalMoveManager();
                break;
            case MyUtils.GameType.PlusOne://加一模式
                factory = new ClassicalFactory(5,1);
                gamecontroller = new ClassiaclGameController(finalScore, highestScore, container, factory);
                moveManager = new ClassicalMoveManager();
                break;
            case MyUtils.GameType.Half://减半模式 
                factory = new HalfFactory();
                gamecontroller = new ClassiaclGameController(finalScore, highestScore, container, factory);
                moveManager = new ClassicalMoveManager();
                break;

            case MyUtils.GameType.TwoHand_RollerCoaster:
                factory = new ClassicalFactory(6,2);
                gamecontroller = new ClassiaclGameController(finalScore, highestScore, container, factory);
                moveManager = new RandomSpeedMoveManager();
                break;

            case MyUtils.GameType.Reverse:
                factory = new ClassicalFactory();
                ((ClassicalFactory)factory).SetReverse(true);
                gamecontroller = new ClassiaclGameController(finalScore, highestScore, container, factory);
                moveManager = new ClassicalMoveManager();
                break;

            case MyUtils.GameType.Chaos://混沌模式
                factory = new ClassicalFactory(4,2);
                gamecontroller = new ChaosGameController(finalScore, highestScore, goal, container, timer, factory);
                moveManager = new ClassicalMoveManager().setMultiple(0.8f);
                break;
            default:
                factory = new ClassicalFactory();//默认是经典
                gamecontroller = new ClassiaclGameController(finalScore, highestScore, container, factory);
                moveManager = new ClassicalMoveManager();
                break;
        }
        gamecontroller.startGame();//控制器启动
        moveManager.Start();//移动器启动
        gameType.text = MyUtils.GameType.getGameTypeName(type);
      
	}
	

	void Update () {
        gamecontroller.Update();
        moveManager.Update();

        if(Input.GetKeyDown(KeyCode.Escape)){//用户按下返回键
            if(gobalState==MyUtils.GameState.Ing){//如果正在游戏
                PauseGame();//就暂停
            }
            else
            {
                SceneManager.LoadSceneAsync(0);//如果不是正在游戏,那么就是打完这局辣,那就直接退出到开始菜单
            }
           
        }

	}

    public void PauseGame()//暂停游戏
    {
        if(pause){//如果已经暂停,那就继续游戏
            gamecontroller.Start();
            moveManager.Start();
            pause = false;
            HidePause();
        }
        else
        {
            gamecontroller.Pause();
            moveManager.Pause();
            ShowPause();//显示暂停窗口
            pause = true;
        }
      
    }

    public void RestartGame()//重新开始游戏
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

    public void EndGame()//游戏结束
    {
        
        gamecontroller.StopGame();
        moveManager.Pause();
        Score.instacne.SaveCurentScore();//保存一下分数
    }

   public void sendStateChangeMsg()//广播一下游戏状态的变更
    {
        factory.GameStateChange(gobalState);
        SendMessage("GameStateChange", gobalState);
    }


   private void ShowPause() {//显示暂停窗口
       pauseLabel.gameObject.SetActive(true);
       pauseLabel.GetComponent<TweenAlpha>().PlayForward();
   }

   private void HidePause()//隐藏暂停窗口
   {
       pauseLabel.GetComponent<TweenAlpha>().PlayReverse();
   }

}
