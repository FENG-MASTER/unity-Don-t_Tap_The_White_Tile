using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClassicalFactory :BaseFactory {

    public GameObject block;

    public Sprite whliteSprite;
    public Sprite blackSprite;
    public Sprite whliteDownSprite;
    public Sprite transitionSprite;

    private int numPerRow;
    private int blackNum;

    private bool isReverse=false;
    private bool isJustReverse = false;

    public ClassicalFactory(int numPerRow,int blackNum)
    {
        this.rowPrefab = GameRes.instance.prefab_row;
        this.block = GameRes.instance.prefab_block;
        this.whliteSprite = GameRes.instance.sprite_whlite;
        this.blackSprite = GameRes.instance.sprite_black;
        this.whliteDownSprite = GameRes.instance.sprite_whlite_down;
        this.transitionSprite = GameRes.instance.sprite_transition;
        this.numPerRow = numPerRow;
        this.blackNum = blackNum;
    }

    public ClassicalFactory():this(4,1)
    {
        
    }


    public override void BuildRowBlocks(out GameObject[] objs)
    {
        //随机生成一排方块

        objs = new GameObject[numPerRow];

        int[] arr = GetRandomArray(numPerRow);
        for (int i = 0; i < objs.Length;i++ )
        {
            if(i<blackNum){//这里是生成黑方块的(需要点击)
                objs[arr[i]] = GameObject.Instantiate<GameObject>(block);
                if(isJustReverse){
                    objs[arr[i]].GetComponent<BaseBlock>().Init(transitionSprite, blackSprite, new BlackClick_nomral(objs[arr[i]]), objs.Length);
                    
                }else if(isReverse){
                    objs[arr[i]].GetComponent<BaseBlock>().Init(whliteSprite, blackSprite, new BlackClick_nomral(objs[arr[i]]).setReversePlay(true), objs.Length);

                }
                else
                {
                    objs[arr[i]].GetComponent<BaseBlock>().Init(blackSprite, blackSprite, new BlackClick_nomral(objs[arr[i]]), objs.Length);
                }
            }
            else
            {//这里是生成白色方块(不能点击)
                objs[arr[i]] = GameObject.Instantiate<GameObject>(block);
                if(isReverse){
                    objs[arr[i]].GetComponent<BaseBlock>().Init(blackSprite, whliteDownSprite, new WhileClick_Nomral(objs[arr[i]]), objs.Length);
                }
                else
                {
                    objs[arr[i]].GetComponent<BaseBlock>().Init(whliteSprite, whliteDownSprite, new WhileClick_Nomral(objs[arr[i]]), objs.Length);
                }
 

            }

        }

        isJustReverse = false;
        return;

    }

    public void SetReverse(bool isReverse)
    {
        this.isReverse = isReverse;
        isJustReverse = true;
    }


    private int[] GetRandomArray(int n)
    {
        int[] arr = new int[n];
        for (int i = 0; i < arr.Length;i++ )
        {
            arr[i] = i;//初始化
        }

        int temp;
        for (int i = 0; i < arr.Length;i++ )
        {
            int r=Random.Range(0, n - 1);
            temp=arr[i];
            arr[i] = arr[r];
            arr[r] = temp;
        }
        return arr;

    }

    

}
