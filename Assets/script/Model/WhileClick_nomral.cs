using UnityEngine;
using System.Collections;

public class WhileClick_Nomral : ClickInterface {
    private bool hasClick = false;
    private GameObject parent;
    private AudioClip sound;

    public WhileClick_Nomral(GameObject parent)
    {
        this.parent = parent;
        sound = GameRes.instance.sound_block_click_false;
    }
    public void OnClick()
    {
        if (hasClick) return;
        
        hasClick = true;
        AudioSource.PlayClipAtPoint(sound, parent.transform.position);
        parent.GetComponent<TweenAlpha>().style = TweenAlpha.Style.PingPong;
        parent.GetComponent<TweenAlpha>().gameObject.SetActive(true);
        parent.GetComponent<TweenAlpha>().PlayForward();
        MainGameController.instance.EndGame();
    }
    public void OnNoClick()
    {
       
    }


}
