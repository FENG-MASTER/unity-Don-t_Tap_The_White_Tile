using UnityEngine;
using System.Collections;

public abstract class BaseGameController{

    protected BaseFactory factory;//工厂类

    public abstract void startGame();
    public virtual void Pause(){
       factory.Pause();
    }

    public virtual void Start()
    {
        factory.Start();
    }
    public abstract void StopGame();
    
    public void Update()
    {
        factory.Build();

    }
  

}
