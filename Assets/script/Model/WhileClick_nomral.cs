using UnityEngine;
using System.Collections;

public class WhileClick_Nomral : ClickInterface {
    private Score score;

    public WhileClick_Nomral()
    {
        
    }
    public void OnClick()
    {
        MainGameController.instance.EndGame();
    }
    public void OnNoClick()
    {
       
    }


}
