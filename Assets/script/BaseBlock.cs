using UnityEngine;
using System.Collections;

//方块基类
public class BaseBlock : MonoBehaviour
{

    public enum State_Pos { Start, Moving, Out };

    public State_Pos state = State_Pos.Start;//
    public Sprite sp_nomraml;
    public Sprite sp_down;

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

    void OnBecameInvisible()
    {
        if (state == State_Pos.Moving)
        {
            clickIn.OnNoClick();
            state = State_Pos.Out;
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
