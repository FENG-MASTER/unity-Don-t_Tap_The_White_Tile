using UnityEngine;
using System.Collections;

public class WhileClick_Nomral : ClickInterface {
    private Score score;

    public WhileClick_Nomral(Score score)
    {
        this.score=score;
        
    }
    public void OnClick()
    {
        MainGameController.instance.EndGame();
    }
    public void OnNoClick()
    {
       
    }


}
