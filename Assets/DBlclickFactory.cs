using UnityEngine;
using System.Collections;

public class DBlclickFactory : BaseFactory {

    public GameObject block;

    public Sprite whliteSprite;
    public Sprite blackSprite;
    public Sprite whliteDownSprite;
    public Sprite DBclickSprite;

    public DBlclickFactory(GameObject row,GameObject block,
        Sprite black,Sprite whilte,Sprite whilteDown,
        Sprite DB):base(row)
    {
        this.block = block;
        this.blackSprite = black;
        this.whliteSprite = whilte;
        this.whliteDownSprite = whilteDown;
        this.DBclickSprite = DB;
    }


    public override void BuildRowBlocks(out GameObject[] objs)
    {
        objs = new GameObject[4];
        int Rnum = (int)(Random.value * 100) % 4;
        objs[Rnum] = GameObject.Instantiate<GameObject>(block);

        if (((int)(Random.value * 100) % 4) == 1)
        {
            objs[Rnum].GetComponent<BaseBlock>().Init(DBclickSprite, DBclickSprite, new MultipleClick(objs[Rnum],2), objs.Length);
        }
        else
        {
            objs[Rnum].GetComponent<BaseBlock>().Init(blackSprite, blackSprite, new BlackClick_nomral(objs[Rnum]), objs.Length);
        }




        for (int i = 0; i < objs.Length; i++)
        {
            if (i != Rnum)
            {
                objs[i] = GameObject.Instantiate<GameObject>(block);
                objs[i].GetComponent<BaseBlock>().Init(whliteSprite, whliteDownSprite, new WhileClick_Nomral(objs[i]), objs.Length);
            }
        }
    }
}
