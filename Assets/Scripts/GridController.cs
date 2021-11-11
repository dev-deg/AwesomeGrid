using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    private GridSystem _gridSystem;

    void Start()
    {
        _gridSystem = new GridSystem(4, 4, 1f, new Vector3(-3, -3));
    }
}
