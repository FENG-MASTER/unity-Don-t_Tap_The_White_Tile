using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChoiceController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartClassicsGame() 
    { 
        //开始经典模式
        PlayerPrefs.SetInt("GameType",MyUtils.GameType.Classics);
        SceneManager.LoadSceneAsync(2);
    }

    public void StartDBclickGame()
    {
        //开始双击模式?...名字没想好QAQ
        PlayerPrefs.SetInt("GameType", MyUtils.GameType.DBclick);
        SceneManager.LoadSceneAsync(2);
    }

    public void StartTimerGame()
    {
        //计时模式
        PlayerPrefs.SetInt("GameType", MyUtils.GameType.Timer);
        SceneManager.LoadSceneAsync(2);

    }



}
