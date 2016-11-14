using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClueSequence : MonoBehaviour {

    public LayerMask layerMask;
    public GameObject Ring;
    private RaycastHit _hit;
    public Text Position;
    public Text ClueNo;
    private Vector3 _mousePos;
    private bool _sleep = true;
    public GameObject[] Clues=new GameObject[5];
    private int _clueNo = 0;

    void Start()
    {
        Ring.SetActive(false);
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
                    Ring.SetActive(true);
                    Ring.transform.position = Input.mousePosition;

                    //_hit.collider.gameObject.SetActive(false);

                    for (int i=0; i<Clues.Length; i++)
                    {
                        if (_hit.collider.name == Clues[i].name)
                        {
                            GetComponent<CluePanelScript>().ActivateCluePanel(i);
                        }
                    }
                    if(_hit.collider.name == Clues[_clueNo].name)
                    {
                        this.GetComponent<CluesUIScript>().UpdateScore();
                        _clueNo++;
                        
                    }
                    else
                    {
                        _clueNo = 0;
                        GetComponent<CluesUIScript>().ResetScore();
                    }
                    
                    //if (_clueNo < Clues.Length) { Clues[_clueNo].SetActive(true); }
                    ClueNo.text = "Clue #" + _clueNo;
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
