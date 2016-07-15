using UnityEngine;
using System.Collections;

public class RandomSpeedMoveManager : ClassicalMoveManager
{
    private int RTimeInterval=0;
    private int PTimeLast=0;
    private int X = 0;
    private float RAddSpeed = 0f;//这个以一个方块高度为一个单位
    private int perSec;
    private float sp;

    public RandomSpeedMoveManager()
    {
        perSec = 30;

    }


    public override void Start()
    {
        base.Start();
        Init();
    }

    public override float getSpeed(int score)
    {
        sp= base.getSpeed(score);
        if (RTimeInterval == 0 && X == PTimeLast)
        {
            Init();
        }

        if (RTimeInterval != 0 && X != PTimeLast)
        {
            RTimeInterval--;
        }
        else if (RTimeInterval == 0 && X != PTimeLast)
        {
            sp += GetRandomSpeedAdded();
            X++;
        }
        
        return sp;

    }

    private void Init()
    {
        RTimeInterval = Random.Range(10 * perSec, 20 * perSec);
        PTimeLast = Random.Range(10 * perSec, 20 * perSec);
        X = 0;
        RAddSpeed = Random.value/15f *BaseBlock.heigh;
    }

    private float GetRandomSpeedAdded()
    {
        if(X<PTimeLast/2f){
            return 2f * RAddSpeed / PTimeLast;
        }
        else
        {
            return -2f * RAddSpeed * X / PTimeLast + 2 * RAddSpeed;
        }
    }

	
}
