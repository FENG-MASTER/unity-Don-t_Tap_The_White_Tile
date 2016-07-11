using UnityEngine;
using System.Collections;

//方块基类
public class BaseBlock : MonoBehaviour
{

    public enum State_Pos { Start, Moving, Out };

    public State_Pos state = State_Pos.Start;//状态量
    public Sprite sp_normal;//正常贴图
    public Sprite sp_down;//按下时候的贴图
    public bool isDestroy = false;//销毁标记,用于解决异步的销毁过程产生的问题


    protected SpriteRenderer renderer;//渲染器
    protected ClickInterface clickIn;//点击处理接口
    protected Score score;

    public void Init(Sprite normal,Sprite down,ClickInterface cInterface)
    {
        sp_normal = normal;
        sp_down = down;
        clickIn = cInterface;
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite=sp_normal;
    }

    public void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        score = GameObject.Find("manager").GetComponent<Score>();
        sp_normal = renderer.sprite;
        clickIn = new WhileClick_Nomral();//默认是白块的点击处理
    }


    void OnMouseOver()
    {
        //鼠标在该物体上方的时候回调这个函数

        if (Input.GetMouseButtonDown(0))//当鼠标左键按下的时候
        {
            renderer.sprite = sp_down;//改变贴图
            clickIn.OnClick();//执行按键后事件处理
        }
        if (Input.GetMouseButtonUp(0))//当鼠标左键松开
        {
            renderer.sprite = sp_normal;//改变回原来贴图

        }

    }

    /**
     * 这个函数有坑,这个回调是说当该物体不在相机范围内,那么会调用这个函数
     * 包括两种情况:
     *              1.物体离开相机显示范围
     *              2.物体被清除
     * 
     * */
    void OnBecameInvisible()//不可见时
    {
        if(isDestroy){//这个是用来解决异步销毁出现的问题的,当这个物体被标记了销毁的时候,不处理这个函数
            return;
        }
        if (state == State_Pos.Moving)//正在移动状态的时候,变成不在视野范围,那么就应该是超出了边界
        {
            state = State_Pos.Out;//把状态变成Out
            clickIn.OnNoClick();//执行没有按下这个方块后的代码
        }
    }

    void OnBecameVisible()//可见时
    {
        if (state == State_Pos.Start)//当该物体从开始状态到可见状态,证明在屏幕出现
        {
            state = State_Pos.Moving;//状态改成移动
        }
    }


    public void SetClickInterface(ClickInterface CInterface)
    {
        clickIn = CInterface;
    }




}
