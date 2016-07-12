using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generater : MonoBehaviour
{

    public GameObject obj;
    public GameObject block;

    public Sprite black;
    public Sprite black_down;
    public Sprite white;
    public Sprite white_down;
    public Sprite twiceBlock;

    private MoveManager manager;

    private bool canGen = true;

    // Use this for initialization
    void Start()
    {
        manager = GetComponent<MoveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gen();
    }

    public void gen()
    {
        if(!canGen){
            return;
        }
        List<GameObject> list = manager.blockList;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].GetComponent<Row>().state == Row.State_Pos.Start)
            {
                return;
            }

        }
        
        GameObject o = Instantiate<GameObject>(obj);
        o.transform.position = new Vector3(Camera.main.transform.position.x, 
            Camera.main.transform.position.y+Screen.height/100.0f/2.0f+3.0f*BaseBlock.heigh/2f-0.25f, 
            Camera.main.transform.position.z);
        GameObject[] os = getRandmonBlocks();
        o.GetComponent<Row>().Init(os);
    }

    private GameObject[] getRandmonBlocks()
    {
        //随机生成一排方块

        GameObject[] objs=new GameObject[4];
        int Rnum=(int)(Random.value * 100) % 4;
        objs[Rnum] = Instantiate<GameObject>(block);

        int r = (int)(Random.value * 200) % 10;
        if(r==1){
            objs[Rnum].GetComponent<BaseBlock>().Init(twiceBlock, twiceBlock, new MultipleClick(objs[Rnum], 2),objs.Length);
        }else{
            objs[Rnum].GetComponent<BaseBlock>().Init(black, black_down, new BlackClick_nomral(objs[Rnum]), objs.Length);
        }

        
        for (int i = 0; i < objs.Length;i++ )
        {
            if (i != Rnum)
            {
                objs[i] = Instantiate<GameObject>(block);
                objs[i].GetComponent<BaseBlock>().Init(white, white_down, new WhileClick_Nomral(objs[i]), objs.Length);
            }
        }

        return objs;
     

    }

    public void GameStateChange(MyUtils.GameState state)
    {

        if (state == MyUtils.GameState.End)
        {
            canGen = false;
            print("GameStateChange end");
        }
        else if (state == MyUtils.GameState.Ing)
        {
            canGen = true;
            print("GameStateChange ing");
        }


    }
}
