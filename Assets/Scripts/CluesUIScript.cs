using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CluesUIScript : MonoBehaviour {
    public Text Points;

    private int Score = 0;

    public void UpdateScore()
    {
        Score++;
        Points.text = Score+"/5";

        if (Score >= 5) { StartCoroutine("Finished"); }
    }

    public void ResetScore()
    {
        Score = 0;
        Points.text = Score + "/5";
    }

    IEnumerator Finished()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }
}
