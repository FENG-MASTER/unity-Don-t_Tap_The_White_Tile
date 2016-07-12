using UnityEngine;
using System.Collections;

public class ScreenManeger : MonoBehaviour {

    public UILabel label;

	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
        label.text = "height:" + Screen.height + "\n width:" + Screen.width;

        Camera.main.orthographicSize = Screen.height / 100.0f / 2.0f;//设置orthographicSize的值为屏幕高一半

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
