using UnityEngine;
using System.Collections;

public class ScreenManeger : MonoBehaviour {

    public UILabel label;

	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
        label.text = "height:" + Screen.height + "\nwidth:" + Screen.width+"\n" +Screen.dpi;
        Camera.main.orthographicSize = 1;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
