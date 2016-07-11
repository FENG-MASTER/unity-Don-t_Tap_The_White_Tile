using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generater : MonoBehaviour
{

    public GameObject obj;
    public GameObject block_b;
    public GameObject block_w;

    public Sprite black;
    public Sprite black_down;
    public Sprite white;
    public Sprite white_down;

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
        o.transform.position = new Vector3(10f, -14.55f, -3.03f);
        GameObject[] os = getRandmonBlocks();
        o.GetComponent<Row>().Init(os[0],os[1],os[2],os[3]);
    }

    private GameObject[] getRandmonBlocks()
    {
        GameObject[] objs=new GameObject[4];
        int Rnum=(int)(Random.value * 100) % 4;
        objs[Rnum] = Instantiate<GameObject>(block_b);
        objs[Rnum].GetComponent<BaseBlock>().Init(black, black_down, new BlackClick_nomral(objs[Rnum]));
        for (int i = 0; i < objs.Length;i++ )
        {
            if (i != Rnum)
            {
                objs[i] = Instantiate<GameObject>(block_w);
                objs[i].GetComponent<BaseBlock>().Init(white, white_down, new WhileClick_Nomral());
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
