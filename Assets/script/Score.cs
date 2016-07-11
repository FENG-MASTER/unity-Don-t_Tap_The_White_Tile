using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    private int scoreVal = 0;

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
       finalScore.text = "最终分数:" + scoreVal;
       container.SetActive(true);
       container.GetComponent<TweenPosition>().PlayForward();
   }

   public void RestartGame()
   {
       scoreVal = 0;
   }

   private void Check()
   {


   }
}
