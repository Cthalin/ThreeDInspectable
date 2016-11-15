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
    public AudioSource Blip;
    public AudioSource BleepNeg;
    private CluePanelScript CluePanelScript;
    private CluesUIScript CluesUIScript;

    void Start()
    {
        Ring.SetActive(false);
        CluePanelScript = GetComponent<CluePanelScript>();
        CluesUIScript = GetComponent<CluesUIScript>();
        CluePanelScript.ActivateCluePanel(0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _sleep == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Ring.activeInHierarchy == true) { Ring.SetActive(false); }
            
            _sleep = false;

            if (Physics.Raycast(ray, out _hit, 1000f, layerMask))
            {
                if(_hit.collider.tag == "Clue")
                {
                    Ring.SetActive(true);
                    Ring.transform.position = Input.mousePosition;

                    //for (int i=0; i<Clues.Length; i++)
                    //{
                    //    if (_hit.collider.name == Clues[i].name)
                    //    {
                    //        GetComponent<CluePanelScript>().ActivateCluePanel(i);
                    //    }
                    //}
                    if(_hit.collider.name == Clues[_clueNo].name)
                    {
                        CluesUIScript.UpdateScore();
                        Blip.Play();
                        _clueNo++;
                        if (_clueNo < Clues.Length) {
                            CluePanelScript.ActivateCluePanel(_clueNo);
                            CluePanelScript.DeactivateCluePanel(_clueNo - 1);
                        }
                    }
                    else
                    {
                        BleepNeg.Play();
                        _clueNo = 0;
                        CluesUIScript.ResetScore();
                        for (int i = 0; i < Clues.Length; i++)
                        {
                            CluePanelScript.DeactivateCluePanel(i);
                        }
                        CluePanelScript.ActivateCluePanel(_clueNo);
                    }
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
