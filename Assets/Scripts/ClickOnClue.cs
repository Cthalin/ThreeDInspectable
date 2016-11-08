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
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray, 100);

            //for (int i = 0; i < hits.Length; i++)
            //{
            //    RaycastHit hit = hits[i];
                
            //    if (hits[i].transform.tag.Contains("Clue"))
            //    {
            //        this.GetComponent<CluesUIScript>().UpdateScore();
            //        print("TestHit " + GetComponent<CluesUIScript>().Points.text);
            //        hits[i].collider.gameObject.SetActive(false);
            //        break;
            //    }else
            //    {
            //        break;
            //    }
            //}

            if (Physics.Raycast(ray, out _hit, layerMask))
            {
                if (_hit.transform.tag.Contains("Clue"))
                {
                    this.GetComponent<CluesUIScript>().UpdateScore();
                    print("TestHit "+GetComponent<CluesUIScript>().Points.text);
                    _hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }
}
