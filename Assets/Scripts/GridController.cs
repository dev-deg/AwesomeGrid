using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GameObject text;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        GridSystem gridSys = new GridSystem(4, 4, 1f,text,canvas);
    }
}
