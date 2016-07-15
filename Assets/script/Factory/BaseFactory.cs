using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class BaseFactory
{

    private bool canGen = true;

    protected GameObject rowPrefab;

    public BaseFactory()
    {
        this.rowPrefab = GameRes.instance.prefab_row;

    }

    public GameObject Build()
    {
        if(!canGen){
            return null;
        }
        List<GameObject> list = new List<GameObject>(GameObject.FindGameObjectsWithTag("Row"));
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].GetComponent<Row>().state == Row.State_Pos.Start)
            {
                return null;
            }

        }

        GameObject o = GameObject.Instantiate<GameObject>(rowPrefab);
        o.transform.position = new Vector3(Camera.main.transform.position.x,
            Camera.main.transform.position.y + Screen.height / 100.0f / 2.0f + 3f*BaseBlock.heigh/2f ,
            Camera.main.transform.position.z);

        GameObject[] os;
        BuildRowBlocks(out os);
        o.GetComponent<Row>().Init(os);
        return o;
    }

    public abstract void BuildRowBlocks(out GameObject[] objs);//抽象生成方块方法

    public void Pause()
    {
        canGen = false;
    }

    public void Start()
    {
        canGen = true;
    }

    public void GameStateChange(MyUtils.GameState state)
    {

        if (state == MyUtils.GameState.End)
        {
            canGen = false;

        }
        else if (state == MyUtils.GameState.Ing)
        {
            canGen = true;

        }

    }


}
