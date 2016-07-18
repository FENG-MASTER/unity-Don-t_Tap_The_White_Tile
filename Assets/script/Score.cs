using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Score : MonoBehaviour {

    public static Score instacne;

    public int scoreVal = 0;

    public enum State { ing, end };

    private State gobalState = State.ing;

    public UILabel label;
    public GameObject container;

	// Use this for initialization
	void Start () {
        instacne = this;
	}
	
	// Update is called once per frame
    void Update () {
        label.text = "分数:"+scoreVal;
	}

   public void AddScore(int add){
        scoreVal += add;
    }

   public void SaveCurentScore()
   {//保存分数
       Save(PlayerPrefs.GetInt("GameType"),scoreVal);
   }


   public int GetCurrentHighestScore()
   {
       //获取当前模式最高分
       return getHighestScore(PlayerPrefs.GetInt("GameType"));
   }

   private static int getHighestScore(int type)
   {
       return PlayerPrefs.GetInt(MyUtils.GameType.getGameTypeName(type)); 

   }

   private void Save(int type,int score)
   {
       if(score<getHighestScore(type)){
           return;
       }

       PlayerPrefs.SetInt(MyUtils.GameType.getGameTypeName(type),score);

   }

   public static Dictionary<string,int> getScoreMap()
   {
       Dictionary<string, int> dict = new Dictionary<string, int>();
       for (int i = 1; i < 11;i++ )
       {
           dict.Add(MyUtils.GameType.getGameTypeName(i),getHighestScore(i));
       }
       return dict;
   }

   

   
}
