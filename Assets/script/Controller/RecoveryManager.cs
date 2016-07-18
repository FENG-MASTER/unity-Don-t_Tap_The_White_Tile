using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecoveryManager : MonoBehaviour {
    //回收方块控制器,过了边界就清除

    public List<GameObject> blockList;

	void Update () {
        blockList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Row"));
        for (int i = 0; i < blockList.Count; i++)
        {
            if (blockList[i].GetComponent<Row>().state == Row.State_Pos.Out)
            {
                blockList[i].GetComponent<Row>().DestroyChildren();
                Destroy(blockList[i]);
                blockList.Remove(blockList[i]);
            }
        }
	}
}
