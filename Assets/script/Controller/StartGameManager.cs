using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Umeng;

public class StartGameManager : MonoBehaviour {

    private bool isAboutShow = false;
    public UILabel aboutDes;
    public UILabel aboutButton;


    void Start()
    {
       
        //app key 
        GA.StartWithAppKeyAndChannelId("578de48ee0f55a0d15001a51", "AppStore");


    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void OnAboutButtonClick()
    {
        if(isAboutShow){
            aboutDes.GetComponent<TweenAlpha>().PlayReverse();
            aboutButton.text = "关\n\n于";
            isAboutShow = false;

        }
        else
        {
            aboutDes.gameObject.SetActive(true);
            aboutDes.GetComponent<TweenAlpha>().PlayForward();
            aboutButton.text = "后\n\n退";
            isAboutShow = true;
        }

       


    }

    public void OnRankListButtonClick()
    {
       SceneManager.LoadSceneAsync(3);
       
    }

	
	
	// Update is called once per frame
	void Update () {
       if(Input.GetKeyDown(KeyCode.Escape)){
           Application.Quit();//退出游戏

       }
	}
}
