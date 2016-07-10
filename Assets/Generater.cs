using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generater : MonoBehaviour
{

    public GameObject obj;
    public GameObject block_b;
    public GameObject block_w;

    private MoveManager manager;

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
        List<GameObject> list = manager.blockList;
        print("gen1");
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].GetComponent<Row>().state == Row.State_Pos.Start)
            {
                return;
            }

        }
        print("gen3");
        GameObject o = Instantiate<GameObject>(obj);
        o.transform.position = new Vector3(10f, -41.79f, -3.03f);
        GameObject[] os = getRandmonBlocks();
        o.GetComponent<Row>().Init(os[0],os[1],os[2],os[3]);
    }

    private GameObject[] getRandmonBlocks()
    {
        GameObject[] objs=new GameObject[4];
        for (int i = 0; i < objs.Length;i++ )
        {
            objs[i] = Instantiate<GameObject>(block_w);
        }

        objs[(int)(Random.value*100) % 4]=Instantiate<GameObject>(block_b);
        return objs;
     

    }
}
