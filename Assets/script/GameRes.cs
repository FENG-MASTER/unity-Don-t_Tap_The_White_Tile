 using UnityEngine;
using System.Collections;

public class GameRes : MonoBehaviour
{
    //全局动态资源加载类

    public static GameRes instance;//单例模式


    //声音
    public AudioClip sound_block_click;
    public AudioClip sound_block_click_false;

    //prefab
    public GameObject prefab_row;
    public GameObject prefab_block;

    //贴图
    public Sprite sprite_black;
    public Sprite sprite_whlite;
    public Sprite sprite_whlite_down;
    public Sprite sprite_twiceBlock;
    public Sprite sprite_transition;


    void Awake()
    {
      //  LoadRes();
        instance = this;

    }

    private void LoadRes()
    {
        sound_block_click = Resources.Load<AudioClip>("sound/sound_block_click");
        sound_block_click_false = Resources.Load<AudioClip>("sound/sound_block_click_false");

        prefab_block = Resources.Load<GameObject>("prefab/block");
        prefab_row = Resources.Load<GameObject>("prefab/row");

        sprite_black = Resources.Load<Sprite>("texture/black");
        sprite_whlite = Resources.Load<Sprite>("texture/whilte");
        sprite_whlite_down = Resources.Load<Sprite>("texture/whilte_down");
        sprite_twiceBlock = Resources.Load<Sprite>("texture/twiceBlock");
        sprite_transition = Resources.Load<Sprite>("texture/transition");
       
    }


}
