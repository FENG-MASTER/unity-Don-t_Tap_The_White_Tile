using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveManager : MonoBehaviour
{

    public List<GameObject>  blockList = new List<GameObject>();

    public float speed = 0.2f;

    private bool isMove=true;

    // Use this for initialization
    void Start()
    {
        blockList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Row"));
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMove){
            return;
        }
        speed = getSpeed(Score.instacne.scoreVal);
        blockList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Row"));
        Vector3 old;
        for (int i = 0; i < blockList.Count; i++)
        {

            //这里采用了跟屁虫的做法,后面的方块全部跟着第一个方块,这样就可以保持整齐
            old = blockList[i].transform.position;
            if(i==0){
                blockList[i].transform.position = new Vector3(old.x, old.y-speed, old.z);
            }
            else
            {
                blockList[i].transform.position = new Vector3(old.x, blockList[i - 1].transform.position.y + BaseBlock.heigh, old.z);
            }


            if (blockList[i].GetComponent<Row>().state == Row.State_Pos.Out)
            {
                blockList[i].GetComponent<Row>().DestroyChildren();
                Destroy(blockList[i]);
                blockList.Remove(blockList[i]);
            }
        }

    }

    public void Pause()
    {
        speed = 0.0f;
      
        for (int i = 0; i < blockList.Count; i++)
        {
            blockList[i].GetComponent<Row>().StopTouch();

        }
    }

    public void ReStart()
    {
        blockList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Row"));
        for (int i = 0; i < blockList.Count;i++ )
        {
            blockList[i].GetComponent<Row>().DestroyChildren();
            DestroyImmediate(blockList[i]);//这个是立即销毁.如果用下面那条语句,将会延迟销毁,有BUG
        //    Destroy(blockList[i]);
        }
        blockList.Clear();
     
   
    }

    public void GameStateChange(MyUtils.GameState state) { 
        if(state==MyUtils.GameState.Ing){
            isMove = true;
        }
        else if (state == MyUtils.GameState.End)
        {
            isMove=false;
        }
    }

    private float getSpeed(int score)
    {
      
        if(score<200){
            score += ((int)(Random.value*100) % 10);
            return (0.0025f*score+1)*BaseBlock.heigh/30f;
        }else{
            return (0.001f * score + 1) * BaseBlock.heigh / 30f;
        }


    }

}
