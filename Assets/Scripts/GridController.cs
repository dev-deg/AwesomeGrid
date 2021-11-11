using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] private GameObject text; //Reference to our text prefab
    [SerializeField] private Canvas canvas; //Reference to the canvas (as a parent)


    private GridSystem _gridSystem;

    void Start()
    {
        //Instantiating our grid system
        _gridSystem = new GridSystem(10, 10, 1f, new Vector3(-5, -5),text,canvas);
        //To test our new functions
        _gridSystem.setValue(new Vector2Int(4, 4), "25");
        Debug.Log(_gridSystem.getValue(new Vector2Int(2, 2)));
    }
}
