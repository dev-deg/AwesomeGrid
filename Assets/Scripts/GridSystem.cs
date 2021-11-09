using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GridSystem
{
    private int _width; //Number of boxes wide
    private int _height; //Number of boxes high
    private float _cellSize; //Size of each cell
    private int[,] _gridArray; //2D Array

    public GridSystem(int width, int height, float cellSize, GameObject text, GameObject canvas)
    {
        this._width = width;
        this._height = height;
        this._cellSize = cellSize;
        this._gridArray = new int[width, height];

        //Looping through all the coords
        for (int x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gridArray.GetLength(1); y++)
            {
                //Drawing Grid Lines
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1 , y), Color.white, 100f);

                //Create a Text
                GameObject newGO = GameObject.Instantiate(text, GetWorldPosition(x, y) + (new Vector3(_cellSize,_cellSize) * 0.5f), Quaternion.identity, canvas.transform);
                newGO.name = "Text" + x + y;
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    //Converts x and y coords to global positioning
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x,y) * _cellSize;
    }

}
