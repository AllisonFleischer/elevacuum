using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UnityEngine.Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Start"))
        {
            Application.LoadLevel("level1");
        }
        if (Input.GetButtonDown("Exit"))
        {
            Application.Quit();
        }
    }
}
