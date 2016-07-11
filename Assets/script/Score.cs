using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Score : MonoBehaviour {

    private int scoreVal = 0;

    public enum State { ing, end };

    private State gobalState = State.ing;

    public UILabel label;
    public UILabel finalScore;
    public GameObject container;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        label.text = "分数:"+scoreVal;
	}

   public void AddScore(int add){
        scoreVal += add;
    }

   public void GameEnd()
   {
       if (gobalState==State.end)
       {
           return;
       }
       gobalState = State.end;
       sendStateChangeMsg();
       finalScore.text = "最终分数:" + scoreVal;
       container.SetActive(true);
       container.GetComponent<TweenPosition>().PlayForward();
       GameObject.Find("manager").GetComponent<MoveManager>().Pause();
       
   }

   public void RestartGame()
   {
       
       GameObject.Find("manager").GetComponent<MoveManager>().ReStart(); 
       TweenPosition p=container.GetComponent<TweenPosition>();//播放动画
       p.PlayReverse();
      List<GameObject> blockList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Row"));
       gobalState = State.ing;
       sendStateChangeMsg();
       scoreVal = 0;
   }

   void sendStateChangeMsg()
   {
       SendMessage("GameStateChange", gobalState);
   }

   
}
