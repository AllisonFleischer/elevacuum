using UnityEngine;
using System.Collections;

public class VertMove : MonoBehaviour
{

    public float moveSpeed;
    public bool isDown;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isDown == false)
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        }
    }
}