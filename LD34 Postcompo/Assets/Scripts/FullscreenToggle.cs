using UnityEngine;
using System.Collections;

public class FullscreenToggle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Screen.fullScreen == true) {Screen.fullScreen = false;} else Screen.fullScreen = true; //Toggle fullscreen
        }
	}
}
