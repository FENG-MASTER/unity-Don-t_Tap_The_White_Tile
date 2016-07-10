using UnityEngine;
using System.Collections;

public class BlackClick_nomral : ClickInterface {
    private Score score;

    public BlackClick_nomral(Score score)
    {
        this.score = score;
    }
    public  void OnClick()
    {
        score.AddScore(1);
    }
    public  void OnNoClick()
     {
        
     }

	
}
