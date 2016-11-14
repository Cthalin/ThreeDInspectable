using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClueSequence : MonoBehaviour {

    public LayerMask layerMask;
    public GameObject Ring;
    private RaycastHit _hit;
    public Text Position;
    private Vector3 _mousePos;
    private bool _sleep = true;
    public GameObject[] Clues=new GameObject[5];
    private bool[] _sequence = new bool[5];

    void Start()
    {
        Ring.SetActive(false);
        bool[] _sequence = { true, false, false, false, false};

        for (int i=0; i<Clues.Length; i++)
        {
            if (_sequence[i]) { Clues[i].SetActive(true); }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _sleep == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Ring.activeInHierarchy == true) { Ring.SetActive(false); }
            for (int i=0; i<5; i++)
            {
                GetComponent<CluePanelScript>().DeactivateCluePanel(i); 
            }
            _sleep = false;

            if (Physics.Raycast(ray, out _hit, 1000f, layerMask))
            {
                if(_hit.collider.tag == "Clue")
                {
                    this.GetComponent<CluesUIScript>().UpdateScore();

                    Ring.SetActive(true);
                    Ring.transform.position = Input.mousePosition;

                    _hit.collider.gameObject.SetActive(false);

                    for (int i=0; i<Clues.Length; i++)
                    {
                        if (_hit.collider.name == Clues[i].name)
                        {
                            GetComponent<CluePanelScript>().ActivateCluePanel(i);
                        }
                    }
                    
                }
                
            }
        }

        Position.text = "Pos (" + Input.mousePosition.x + "/" + Input.mousePosition.y + ")";

        if (Input.GetMouseButtonUp(0))
        {
            if (_sleep == false) { _sleep = true; }
        }
    }
}
