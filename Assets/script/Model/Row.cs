using UnityEngine;
using System.Collections;

public class Row : MonoBehaviour
{
    public GameObject[] blocks;

    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;

    public enum State_Pos { Start, Moving, Out };
    public State_Pos state = State_Pos.Start;
    private bool hasInit = false;

    public void Init(GameObject[] blocks)
    {
        this.blocks = blocks;
        BaseBlock.heigh = Screen.height / 100f / blocks.Length;
        BaseBlock.width = Screen.width / 100f / blocks.Length;
        hasInit = true;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!hasInit){
            return;
        }

        UpdateState();

        for (int i = 0; i < blocks.Length;i++ )
        {
            UpdatePosition(blocks[i],i);
        }


        

    }


    //更新ogj这个物体的位置,这个位置在左边数第num个,一共blocks这个数组那么多个
    private void UpdatePosition(GameObject obj, int num)
    {
        Vector3 v = this.transform.position;
        obj.transform.position = new Vector3(v.x + (num - (blocks.Length-1)/2f)*BaseBlock.width, v.y, v.z);
    }

    public void DestroyChildren()
    {
        for (int i = 0; i < blocks.Length;i++ )
        {
            blocks[i].GetComponent<BaseBlock>().isDestroy = true;//添加销毁标记
            Destroy(blocks[i]);//销毁
        }

 
    }

    public void StopTouch()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].GetComponent<BoxCollider>().enabled = false;//阻断点击事件
        }
       
    }

    private bool isMoving()
    {
        bool flag = false;
        for (int i = 0; i < blocks.Length; i++)
        {
           flag = flag || (blocks[i].GetComponent<BaseBlock>().state == BaseBlock.State_Pos.Moving);
        }

        return flag;
    }

    private bool isOut()
    {
        bool flag = true;
        for (int i = 0; i < blocks.Length; i++)
        {
            flag = flag && (blocks[i].GetComponent<BaseBlock>().state == BaseBlock.State_Pos.Out);
        }
        return flag;
    }

    private void UpdateState()
    {
        if(isMoving())
        {
            state = State_Pos.Moving;
        }else if(isOut())
        {
            state = State_Pos.Out;
        }
        else
        {
            state = State_Pos.Start;
        }

    }


}
