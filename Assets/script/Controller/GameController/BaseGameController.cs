using UnityEngine;
using System.Collections;

public abstract class BaseGameController{

    protected BaseFactory factory;//工厂类


    public abstract void startGame();
    public abstract void pauseGame();
    public abstract void StopGame();
    
    public void Update()
    {
        factory.Build();

    }
  

}
