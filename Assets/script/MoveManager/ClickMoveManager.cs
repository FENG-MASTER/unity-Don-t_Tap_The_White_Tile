using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickMoveManager : BaseMoveManager {

    private List<GameObject> blockList;

    public override void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            JumpMoveRow();
        }
    }

    public override void Pause()
    {
        isMove = false;
        for (int i = 0; i < blockList.Count; i++)
        {
            blockList[i].GetComponent<Row>().StopTouch();
        }
    }

    void JumpMoveRow()
    {

        blockList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Row"));
        Vector3 old;
        for (int i = 0; i < blockList.Count; i++)
        {
            //这里采用了跟屁虫的做法,后面的方块全部跟着第一个方块,这样就可以保持整齐
            old = blockList[i].transform.position;
            if (i == 0)
            {
                blockList[i].transform.position = new Vector3(old.x, old.y - BaseBlock.heigh, old.z);
            }
            else
            {
                blockList[i].transform.position = new Vector3(old.x, blockList[i - 1].transform.position.y + BaseBlock.heigh, old.z);
            }

        }

    }

}
