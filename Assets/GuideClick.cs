using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GuideClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseOver()
    {
        SceneManager.LoadSceneAsync(2);

    }
}
