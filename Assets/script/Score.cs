using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public int scoreVal = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   public void AddScore(int add){
        scoreVal += add;
    }
}
