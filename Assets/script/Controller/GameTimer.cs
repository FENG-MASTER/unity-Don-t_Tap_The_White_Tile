using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//全局计时器管理类
public class GameTimer : MonoBehaviour
{

    public static GameTimer instance;

    private List<Timer> timers;
  

    //单个计时器
    public  class Timer
    {
        public UILabel displayLabel;//显示剩余时间的UI

        private long startTime;//开始时间
        private long interval;//设置间隔时间

        private long pauseTime;//用来记录暂停的时间点

        private bool pause=false;//暂停标记

        public delegate void RunEventHandle();//这里用的委托

        public RunEventHandle Run;//委托对象

        public bool loop = false;

        public Timer(int sec,UILabel label)
        {
            interval = sec* 10000000;//100微秒作为一个单位
            displayLabel = label;
            pauseTime = 0;
        }

        //开始计时
        public void StartTiming()
        {
            if(pause){
            //暂停状态切换回来
                interval += System.DateTime.Now.Ticks - pauseTime;
            }
            else
            {//新开始计时
                startTime = System.DateTime.Now.Ticks;    
            }
            pause = false;
            
        }

        //停止计时
        public void StopTiming()
        {
            if(loop){
                startTime = System.DateTime.Now.Ticks;
            }
            else
            {
                pause = true;
                interval = 0;
                pauseTime = 0;
            }
        
        }

        //暂停计时
        public void PauseTiming()
        {
            pause = true;
            pauseTime = System.DateTime.Now.Ticks;//记录暂停的时间点
       
        }

        //更新时间
        public void Update()
        {
            if(pause){
                //暂停
                return;
            }
            else
            {//正常计时
                displayLabel.text = "剩余时间:" + getLastTime();
                if (System.DateTime.Now.Ticks - startTime >= interval)
                {
                    Run();
                    StopTiming();
                }
            }

            

        }

        public double getLastTime()
        {
            double lTime = System.Math.Round((startTime+interval-System.DateTime.Now.Ticks) / 10000000f, 2);
            return lTime >= 0 ? lTime : 0;

        }


    }


    public void Add(Timer t)
    {
        timers.Add(t);
        t.StartTiming();
    }

    public void Remove(Timer t)
    {
        t.StopTiming();
        timers.Remove(t);
    }


    void Awake()
    {
        timers = new List<Timer>();
        instance = this;
    }


 
    void Update()
    {
        for (int i = 0; i < timers.Count;i++ )
        {
            timers[i].Update();
        }

    }

   

}
