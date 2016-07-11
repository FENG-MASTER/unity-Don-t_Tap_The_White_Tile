using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Score : MonoBehaviour {

    public static Score instacne;

    public int scoreVal = 0;

    public enum State { ing, end };

    private State gobalState = State.ing;

    public UILabel label;
    public UILabel finalScore;
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


   
}
