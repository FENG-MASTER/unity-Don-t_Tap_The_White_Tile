using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpMoveManager : MonoBehaviour
{

    public static JumpMoveManager instance;

    private bool begin_offset = true;
    private List<GameObject> blockList = new List<GameObject>();
    private bool isMove = true;


    void Awake()
    {
        enabled = false;
        instance = this;

    }
    public void Open()
    {
        MoveManager.instance.enabled = false;
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMove){
            return;
        }
        
        if (begin_offset)
        {
          JumpMoveRow();
        
           begin_offset = false;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                JumpMoveRow();
            }
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


    void BeginOffset()
    {
        blockList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Row"));
        Vector3 old;
        for (int i = 0; i < blockList.Count; i++)
        {
            //这里采用了跟屁虫的做法,后面的方块全部跟着第一个方块,这样就可以保持整齐
            old = blockList[i].transform.position;
            if (i == 0)
            {
                blockList[i].transform.position = new Vector3(old.x, old.y - BaseBlock.heigh*2, old.z);
            }
            else
            {
                blockList[i].transform.position = new Vector3(old.x, blockList[i - 1].transform.position.y + BaseBlock.heigh, old.z);
            }

        }

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
