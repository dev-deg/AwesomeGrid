using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] private GameObject text; //Reference to our text prefab
    [SerializeField] private Canvas canvas; //Reference to the canvas (as a parent)
    [SerializeField] private Camera cam;

    private GridSystem _gridSystem;

    void Start()
    {
        //Instantiating our grid system
        _gridSystem = new GridSystem(10, 10, 1f, new Vector3(-5, -5),text,canvas);

    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //After I click a cell, something happens
            Vector3 worldMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            _gridSystem.setValue(worldMousePosition, "1");
        }
    }
}
