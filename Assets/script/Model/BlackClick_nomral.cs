using UnityEngine;
using System.Collections;

public class BlackClick_nomral : ClickInterface {
  

    private GameObject parent;
    private bool hasClicked=false;
    private AudioClip sound;

    public BlackClick_nomral(GameObject parent)
    {
        
        this.parent = parent;
        sound = GameRes.instance.sound_block_click;
    }
    public  void OnClick()
    {
        Score.instacne.AddScore(1);
        hasClicked = true;

        AudioSource.PlayClipAtPoint(sound,parent.transform.position);
        //播放消失动画
        parent.GetComponent<TweenAlpha>().gameObject.SetActive(true);
        parent.GetComponent<TweenAlpha>().PlayForward();
       
    }
    public  void OnNoClick()
     {
        if(!hasClicked){
            MainGameController.instance.EndGame();
        }
     }

	
}
