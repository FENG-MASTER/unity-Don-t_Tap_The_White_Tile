using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClassicalMoveManager :BaseMoveManager{

    public List<GameObject> blockList = new List<GameObject>();
    public float speed = 0.2f;

    public override void Move()
    {
        speed = getSpeed(Score.instacne.scoreVal);
        blockList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Row"));
        Vector3 old;
        for (int i = 0; i < blockList.Count; i++)
        {
            //这里采用了跟屁虫的做法,后面的方块全部跟着第一个方块,这样就可以保持整齐
            old = blockList[i].transform.position;
            if (i == 0)
            {
                blockList[i].transform.position = new Vector3(old.x, old.y - speed, old.z);
            }
            else
            {
                blockList[i].transform.position = new Vector3(old.x, blockList[i - 1].transform.position.y + BaseBlock.heigh, old.z);
            }

        }
    }

    public override void Start()
    {
        base.Start();
        for (int i = 0; i < blockList.Count; i++)
        {
            blockList[i].GetComponent<Row>().StartTouch();
        }

    }

    public override void Pause()
    {
        speed = 0.0f;
        isMove = false;
        for (int i = 0; i < blockList.Count; i++)
        {
            blockList[i].GetComponent<Row>().StopTouch();
        }

    }

    public virtual float getSpeed(int score)
    {

        if (score < 200)
        {
            score += ((int)(Random.value * 100) % 10);
            return (0.0030f * score + 1) * BaseBlock.heigh / 30f;
        }
        else
        {
            return (0.001f * score + 1) * BaseBlock.heigh / 30f;
        }


    }
}
