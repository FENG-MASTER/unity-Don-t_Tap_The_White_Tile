using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour {

    private bool isAboutShow = false;
    public UILabel aboutDes;
    public UILabel aboutButton;

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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
	}
}
