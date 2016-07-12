using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public  class ClassicalFactory :BaseFactory {

    public GameObject block;

    public Sprite whliteSprite;
    public Sprite blackSprite;
    public Sprite whliteDownSprite;

    public ClassicalFactory(GameObject row, 
        GameObject block, Sprite blackSprite, 
        Sprite whliteSprite,Sprite whliteDownSprite):base(row)
    {
        this.rowPrefab = row;
        this.block = block;
        this.whliteSprite = whliteSprite;
        this.blackSprite = blackSprite;
        this.whliteDownSprite = whliteDownSprite;
    }


    public override void BuildRowBlocks(out GameObject[] objs)
    {
        //随机生成一排方块

        objs = new GameObject[4];
        int Rnum = (int)(Random.value * 100) % 4;
        objs[Rnum] = GameObject.Instantiate<GameObject>(block);

        objs[Rnum].GetComponent<BaseBlock>().Init(blackSprite, blackSprite, new BlackClick_nomral(objs[Rnum]), objs.Length);
        


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
