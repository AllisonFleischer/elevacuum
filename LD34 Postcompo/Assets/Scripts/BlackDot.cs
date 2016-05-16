using UnityEngine;
using System.Collections;

public class BlackDot : MonoBehaviour
{

    public float dotSpeed;
    public bool isLeft; // Governs initial movement, set in gameObject from Unity editor

    public bool doesSpecialMove = false;
    public float[] specialMove = { 0 }; // Governs rotation after appearing onscreen, set in gameObject from Unity editor
    /* "specialMove" array goes wait for secs->set rotation->wait for secs->set rotation->wait for secs->...
    Rotation is absolute, set in degrees */

    private int specialCounter;

	void Start ()
    {
	    if (doesSpecialMove == true) { StartCoroutine(startSpecialMove()); }
	}

    IEnumerator startSpecialMove()
    {
        if (isLeft == true)
        {
            while (transform.position.x >= 9)
            {
                yield return new WaitForFixedUpdate();
            }
        }
        else
        {
            while (transform.position.x <= -9)
            {
                yield return new WaitForFixedUpdate();
            }
        }
        while (specialCounter < (specialMove.Length - 1))
        {
            yield return new WaitForSeconds(arrayValue(specialCounter, specialMove));
            specialCounter++;
            transform.eulerAngles = new Vector3(0, 0, arrayValue(specialCounter, specialMove));
            specialCounter++;
        }

    }

    private float arrayValue(int value, float[] array) // Handles array value conversion nonsense because I'm too lazy to cast every time. I mean, uh, because it's good practice!
    {
        return ((float)(array.GetValue(value)));
    }

	
	// Update is called once per frame
	void Update ()
    {
        if (isLeft == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime * dotSpeed);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * dotSpeed);
        }
    }
}