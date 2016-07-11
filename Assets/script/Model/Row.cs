using UnityEngine;
using System.Collections;

public class Row : MonoBehaviour
{

    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;

    public enum State_Pos { Start, Moving, Out };
    public State_Pos state = State_Pos.Start;
    private bool hasInit = false;

    public void Init(GameObject o1,GameObject o2,GameObject o3,GameObject o4)
    {
        b1 = o1;
        b2 = o2;
        b3 = o3;
        b4 = o4;
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

        UpdatePosition(b1, 1);
        UpdatePosition(b2, 2);
        UpdatePosition(b3, 3);
        UpdatePosition(b4, 4);
        UpdateState();

    }

    private void UpdatePosition(GameObject obj, int num)
    {
        Vector3 v = this.transform.position;
        obj.transform.position = new Vector3(v.x - (num * 3 - 7.5f), v.y, v.z);
    }

    public void DestroyChildren()
    {
        b1.GetComponent<BaseBlock>().isDestroy = true;//添加销毁标记
        b2.GetComponent<BaseBlock>().isDestroy = true;
        b3.GetComponent<BaseBlock>().isDestroy = true;
        b4.GetComponent<BaseBlock>().isDestroy = true;

        Destroy(b1);//销毁
        Destroy(b2);
        Destroy(b3);
        Destroy(b4);
    }

    public void StopTouch()
    {
        b1.GetComponent<BoxCollider>().enabled = false;
        b2.GetComponent<BoxCollider>().enabled = false;
        b3.GetComponent<BoxCollider>().enabled = false;
        b4.GetComponent<BoxCollider>().enabled = false;
    }

    private bool isMoving()
    {
        return b1.GetComponent<BaseBlock>().state == BaseBlock.State_Pos.Moving ||
               b2.GetComponent<BaseBlock>().state == BaseBlock.State_Pos.Moving ||
               b3.GetComponent<BaseBlock>().state == BaseBlock.State_Pos.Moving ||
               b4.GetComponent<BaseBlock>().state == BaseBlock.State_Pos.Moving;
    }

    private bool isOut()
    {
        return b1.GetComponent<BaseBlock>().state == BaseBlock.State_Pos.Out &&
               b2.GetComponent<BaseBlock>().state == BaseBlock.State_Pos.Out &&
               b3.GetComponent<BaseBlock>().state == BaseBlock.State_Pos.Out &&
               b4.GetComponent<BaseBlock>().state == BaseBlock.State_Pos.Out;
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
