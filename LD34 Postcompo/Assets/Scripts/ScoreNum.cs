using UnityEngine;
using System.Collections;

public class ScoreNum : MonoBehaviour {

    public GameObject PlayerCollider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<TextMesh>().text = PlayerCollider.GetComponent<BlockCollideScript>().score.ToString();
    }
}
