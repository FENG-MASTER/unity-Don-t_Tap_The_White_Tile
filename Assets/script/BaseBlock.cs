using UnityEngine;
using System.Collections;

//方块基类
public class BaseBlock : MonoBehaviour
{

    public enum State_Pos { Start, Moving, Out };

    public State_Pos state = State_Pos.Start;//
    public Sprite sp_nomraml;
    public Sprite sp_down;
    public bool isDestroy = false;//销毁标记


    protected SpriteRenderer renderer;
    protected Score score;
    protected ClickInterface clickIn;//点击处理器


    public void Start()
    {
        
        renderer = GetComponent<SpriteRenderer>();
        score = GameObject.Find("manager").GetComponent<Score>();
        sp_nomraml = renderer.sprite;
        clickIn = new WhileClick_Nomral(score);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            renderer.sprite = sp_down;
            clickIn.OnClick();
        }
        if (Input.GetMouseButtonUp(0))
        {

            renderer.sprite = sp_nomraml;

        }

    }

    /**
     * 这个函数有坑,这个回调是说当该物体不在相机范围内,那么会调用这个函数
     * 包括两种情况:
     *              1.物体离开相机显示范围
     *              2.物体被清除
     * 
     * */
    void OnBecameInvisible()
    {
        if(isDestroy){
            return;
        }
        if (state == State_Pos.Moving)
        {
            state = State_Pos.Out;
            clickIn.OnNoClick();
        }
    }

    void OnBecameVisible()
    {
        if (state == State_Pos.Start)
        {
            state = State_Pos.Moving;
        }
    }




}
