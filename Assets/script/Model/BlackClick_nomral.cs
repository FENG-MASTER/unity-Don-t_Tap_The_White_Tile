using UnityEngine;
using System.Collections;

public class BlackClick_nomral : ClickInterface {
  

    private GameObject parent;
    private bool hasClicked=false;
    private AudioClip sound;

    private bool isReversePlay = false;

    public BlackClick_nomral(GameObject parent)
    {
        
        this.parent = parent;
        sound = GameRes.instance.sound_block_click;
    }
    public  void OnClick()
    {
        if(hasClicked)return;

        Score.instacne.AddScore(1);
        hasClicked = true;

        AudioSource.PlayClipAtPoint(sound,parent.transform.position);
        //播放消失动画
        parent.GetComponent<TweenAlpha>().gameObject.SetActive(true);
        if (isReversePlay)
        {
            parent.GetComponent<TweenAlpha>().PlayReverse();
        }
        else 
        {
            parent.GetComponent<TweenAlpha>().PlayForward();
        }
        
       
    }
    public  void OnNoClick()
     {
        if(!hasClicked){
            MainGameController.instance.EndGame();
        }
     }

    public BlackClick_nomral setReversePlay(bool isReversePlay)
    {
        this.isReversePlay = isReversePlay;
        return this;
    }

    

	
}
