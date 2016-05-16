using UnityEngine;
using System.Collections;

public class BlockMove : MonoBehaviour {

    public float playerSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y >= 5)
        {
            transform.Translate(Vector3.down * Time.deltaTime * playerSpeed / 4);
        }
        else if (transform.position.y <= -5)
        {
            transform.Translate(Vector3.up * Time.deltaTime * playerSpeed / 4);
        }
        else transform.Translate(Vector3.up * Time.deltaTime * playerSpeed * Input.GetAxis("Vertical"));
    }
}