using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

    public GameObject player;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        if (player.GetComponent<BlockCollideScript>().highScore == 0)
        {
            GetComponent<TextMesh>().text = "";
        }
        else GetComponent<TextMesh>().text = "High Score: " + player.GetComponent<BlockCollideScript>().highScore.ToString();
    }
}