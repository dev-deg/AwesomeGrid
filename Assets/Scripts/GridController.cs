using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GameObject text;
    public GameObject canvas;
    public Camera cam;

    private GridSystem gridSys;

    // Start is called before the first frame update
    void Start()
    {
        gridSys = new GridSystem(10, 8, 1f, text, canvas, new Vector3(-5, -4));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Something happens
            Vector3 worldMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            gridSys.setValue(worldMousePosition, "1");
        }
    }
}
