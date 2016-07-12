using UnityEngine;
using System.Collections;

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
        Application.LoadLevelAsync(2);
    }

    public void StartDBclickGame()
    {
        //开始双击模式?...名字没想好QAQ
        PlayerPrefs.SetInt("GameType", MyUtils.GameType.DBclick);
        Application.LoadLevelAsync(2);
    }



}
