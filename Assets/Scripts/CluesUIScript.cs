using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CluesUIScript : MonoBehaviour {
    public Text Points;

    private int Score = 0;

    public void UpdateScore()
    {
        Score++;
        Points.text = Score+"/5";
    }
}
