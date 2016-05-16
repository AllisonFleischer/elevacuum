using UnityEngine;
using System.Collections;

[System.Serializable]
public class BlockCollideScript : MonoBehaviour
{

    public GameObject playerController; // gameObject that manages player's controls
    public int score; // Not for editor, stores current score
    public int highScore; // Not for editor, stores high score
    public AudioSource audio1; // Sound for collecting a black dot
    public AudioSource audio2; // Sound for hitting a white dot
    public AudioSource audio3; // Sound for collecting a diamond
    public float endTime; // Time until level ends
    // Set these in GameObject in Unity editor.

    private AudioSource[] audioList;

	// Use this for initialization
	void Start ()
    {
        //Debug.Log(PlayerPrefs.GetInt("High Score"));
        highScore = (PlayerPrefs.GetInt("High Score")); // Loads previous high score.
        StartCoroutine(EndLevel());
    }

    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(endTime); // Wait until level ends
        if (score > (PlayerPrefs.GetInt("High Score"))) { PlayerPrefs.SetInt("High Score", score); } // Set high score to current score if it's bigger than current high score
        Application.LoadLevel("title"); // TODO: Update to SceneManager instead of depreciated LoadLevel
    }

    // Update is called once per frame
    void Update ()
    {
	
	}

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("BlackBlock"))
        {
            Destroy(coll.gameObject);
            score = score + Mathf.RoundToInt(playerController.transform.localScale.x * 10); // Increase score by value based on how big you are
            playerController.transform.localScale += new Vector3(0.1F, 0.1F, 0); // Increase size
            audio1.pitch = Random.Range(.5F, 1.5F); // Randomize pitch
            audio1.Play(); // Play collection sound
        }
        if (coll.gameObject.CompareTag("WhiteBlock"))
        {
            //Application.LoadLevel(Application.loadedLevel);
            Destroy(coll.gameObject);
            score = score - Mathf.RoundToInt(playerController.transform.localScale.x * 20); // Decrease score by value depending on size
            playerController.transform.localScale = new Vector3(0.5F, 0.5F, 0); // Reset size
            audio2.pitch = Random.Range(.5F, 1.5F); // Randomize pitch
            audio2.Play(); // Play hit sound
        }
        if (coll.gameObject.CompareTag("ShrinkBlock"))
        {
            Destroy(coll.gameObject);
            playerController.transform.localScale = new Vector3(0.5F, 0.5F, 0); // Reset size
            audio3.pitch = Random.Range(.5F, 1.5F); // Randomize pitch
            audio3.Play(); // Play shrink sound
        }
    }
}