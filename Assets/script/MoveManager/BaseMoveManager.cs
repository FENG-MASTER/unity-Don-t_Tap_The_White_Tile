using UnityEngine;
using System.Collections;

public abstract class BaseMoveManager {

    protected bool isMove = true;

    public void Update()
    {
        if(isMove){
            Move();
        }
    }

    public abstract void Move();
    public abstract void Pause();

    public virtual void Start()
    {
        isMove = true;
    }

    public void GameStateChange(MyUtils.GameState state)
    {
        if (state == MyUtils.GameState.Ing)
        {
            isMove = true;
        }
        else if (state == MyUtils.GameState.End)
        {
            isMove = false;
        }
    }
}
