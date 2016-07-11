using UnityEngine;
using System.Collections;

public class StartGameManager : MonoBehaviour {

    public void OnStartButtonClick()
    {
        Application.LoadLevelAsync(1);

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
