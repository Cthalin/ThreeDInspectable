using UnityEngine;
using System.Collections;

public class ClickOnClue : MonoBehaviour {

    public LayerMask layerMask;
    public GameObject Ring;
    private RaycastHit _hit;

    void Start()
    {
        Ring.SetActive(false);
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out _hit, 1000f, layerMask))
        //    {
        //        this.GetComponent<CluesUIScript>().UpdateScore();
        //        //print("TestHit "+GetComponent<CluesUIScript>().Points.text);
        //        var pos = Camera.main.WorldToScreenPoint(_hit.transform.position);

        //        print(pos);

        //        Ring.SetActive(true);
        //        Ring.transform.position = pos;
        //        StartCoroutine(VanishRing(Ring));
                
        //        _hit.collider.gameObject.SetActive(false);
        //    }
        //}
    }

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out _hit, 1000f, layerMask))
        {
            this.GetComponent<CluesUIScript>().UpdateScore();
            //print("TestHit "+GetComponent<CluesUIScript>().Points.text);
            var pos = Camera.main.WorldToScreenPoint(_hit.transform.position);

            print(pos);

            Ring.SetActive(true);
            Ring.transform.position = pos;
            StartCoroutine(VanishRing(Ring));

            _hit.collider.gameObject.SetActive(false);
        }
    }

    IEnumerator VanishRing(GameObject Ring)
    {
        yield return new WaitForSeconds(2f);
        Ring.SetActive(false);
    }
}
