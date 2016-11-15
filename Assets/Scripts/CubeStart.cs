using UnityEngine;
using System.Collections;

public class CubeStart : MonoBehaviour {

    public GameObject[] NumberPlanes = new GameObject[4];
    private float _random;
    private int _randomSide;

    void Awake()
    {
        for(int i=0; i<NumberPlanes.Length; i++)
        {
            NumberPlanes[i].SetActive(false);
        }
    }
    void Start () {
        _random = Random.Range(0f, 3f);
        _randomSide = (int) Mathf.Round(_random);
        NumberPlanes[_randomSide].SetActive(true);
	}
}
