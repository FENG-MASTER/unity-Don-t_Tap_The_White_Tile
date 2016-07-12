using UnityEngine;
using System.Collections;

public class ScreenManeger : MonoBehaviour {



	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.Portrait;

        Camera.main.orthographicSize = Screen.height / 100.0f / 2.0f;//设置orthographicSize的值为屏幕高一半

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
