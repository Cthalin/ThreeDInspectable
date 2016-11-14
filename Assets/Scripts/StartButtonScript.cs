using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour {

    public void StartTheGame()
    {
        SceneManager.LoadScene(0);
    }
}
