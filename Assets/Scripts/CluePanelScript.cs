using UnityEngine;
using System.Collections;

public class CluePanelScript : MonoBehaviour {

    public GameObject[] Panels = new GameObject[5];

	void Start () {
        for (int i = 0; i<5; i++)
        {
            DeactivateCluePanel(i);
        }
	}
	
    public void ActivateCluePanel(int i)
    {
        Panels[i].SetActive(true);
    }

    public void DeactivateCluePanel(int i)
    {
        Panels[i].SetActive(false);
    }
}
