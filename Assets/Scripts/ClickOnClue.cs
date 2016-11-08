using UnityEngine;
using System.Collections;

public class ClickOnClue : MonoBehaviour {

    public LayerMask layerMask;
    private RaycastHit _hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            print(layerMask.value);
            if (Physics.Raycast(ray, out _hit, 1000f, layerMask))
            {
                this.GetComponent<CluesUIScript>().UpdateScore();
                print("TestHit "+GetComponent<CluesUIScript>().Points.text);
                _hit.collider.gameObject.SetActive(false);
            }
        }
    }
}
