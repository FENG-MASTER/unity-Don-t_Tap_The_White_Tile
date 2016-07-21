using UnityEngine;
using System.Collections;

public class MultipleClick : ClickInterface
{
    private int clickTimes;
    private int hasClick;
    private GameObject gameobj;

    private AudioClip sound;

    public MultipleClick(GameObject obj,int times)
    {
        clickTimes = times;
        hasClick = clickTimes;
        gameobj = obj;
        sound = GameRes.instance.sound_block_click;
    }

    public void OnClick()
    {
        hasClick--;
        gameobj.GetComponent<SpriteRenderer>().color = new Color(0,0,0,((float)hasClick)/clickTimes);
        Score.instacne.AddScore(1);
        AudioSource.PlayClipAtPoint(sound, gameobj.transform.position);
        if (hasClick < 0)
        {
            MainGameController.instance.EndGame();
        }

    }

    public void OnNoClick()
    {
        if (hasClick != 0)
        {
            MainGameController.instance.EndGame();
        }
    }
}
