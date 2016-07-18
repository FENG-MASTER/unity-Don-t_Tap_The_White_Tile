using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChoiceController : MonoBehaviour {

    public Texture Classics;
    public Texture DBclick;
    public Texture PlusOne;
    public Texture RollerCoaster;
    public Texture Timer;
    public Texture TwoHand;
    public Texture Half;


    public UITexture UIt;
    public UIWidget container;

	void Start () {
	
	}
	

	void Update () {
	
	}

    public void StartClassicsGame() 
    { 
        //开始经典模式
        PlayerPrefs.SetInt("GameType",MyUtils.GameType.Classics);
        Guide();

    }

    public void StartDBclickGame()
    {
        //开始双击模式?...名字没想好QAQ
        PlayerPrefs.SetInt("GameType", MyUtils.GameType.DBclick);
        Guide();

    }

    public void StartTimerGame()
    {
        //计时模式
        PlayerPrefs.SetInt("GameType", MyUtils.GameType.Timer);
        Guide();


    }

    public void StartRollerCoasterGame() {
        //过山车模式
        PlayerPrefs.SetInt("GameType", MyUtils.GameType.RollerCoaster);
        Guide();
    }

    public void StartTwoHandGame()
    {
        //双手模式
        PlayerPrefs.SetInt("GameType", MyUtils.GameType.TwoHand);
        Guide();
    }

    public void StartPlusOneGame()
    {
        //+1模式
        PlayerPrefs.SetInt("GameType", MyUtils.GameType.PlusOne);
        Guide();
    }

    public void StartHalfGame()
    {
        //减半模式
        PlayerPrefs.SetInt("GameType", MyUtils.GameType.Half);
        Guide();
    }

    public void Guide()
    {//显示模式介绍
        Texture t = null;
        switch (PlayerPrefs.GetInt("GameType"))
        {
            case MyUtils.GameType.Classics:
                t = Classics;
                break;
            case MyUtils.GameType.DBclick:
                t = DBclick;
                break;
            case MyUtils.GameType.PlusOne:
                t = PlusOne;
                break;
            case MyUtils.GameType.RollerCoaster:
                t = RollerCoaster;
                break;
            case MyUtils.GameType.Timer:
                t = Timer;
                break;
            case MyUtils.GameType.TwoHand:
                t = TwoHand;
                break;
            case MyUtils.GameType.Half:
                t = Half;
                break;
            default:
                t = Classics;
                break;

        }
        UIt.mainTexture = t;
        container.gameObject.SetActive(true);
        UIt.GetComponent<TweenAlpha>().PlayForward();
        
        
       
    }

    public void EntetGame()
    {
        SceneManager.LoadSceneAsync(2);

    }



}
