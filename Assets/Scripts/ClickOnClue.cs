using UnityEngine;
using System.Collections;

public class ClickOnClue : MonoBehaviour {

    private RaycastHit _hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hit))
            {
                if (_hit.transform.tag.Contains("Clue"))
                {
                    this.GetComponent<CluesUIScript>().UpdateScore();
                    print("TestHit");
                    _hit.collider.gameObject.SetActive(false);
                }

            }
        }
    }
}
