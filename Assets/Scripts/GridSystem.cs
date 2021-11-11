using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    private int _width; //Number of boxes wide
    private int _height; //Number of boxes high
    private float _boxSize; //Size of each box
    private int[,] _boxArray; //2D Array storing all the boxes
    private Vector3 _origin; //World location where the grid will start

    public GridSystem(int width, int height, float boxSize, Vector3 origin)
    {
        this._width = width;
        this._height = height;
        this._boxSize = boxSize;
        this._origin = origin;

        this._boxArray = new int[width,height];

        for (int x = 0; x < _boxArray.GetLength(0); x++)
        {
            for (int y = 0; y < _boxArray.GetLength(1); y++)
            {
                Debug.DrawLine(GetWorldPosition(new Vector2Int(x, y)), GetWorldPosition(new Vector2Int(x + 1, y)),Color.white,100f);
                Debug.DrawLine(GetWorldPosition(new Vector2Int(x, y)), GetWorldPosition(new Vector2Int(x, y + 1)), Color.white,100f);
            }
        }
        //Add the two missing lines

    }

    private Vector3 GetWorldPosition(Vector2Int coords)
    {
        return new Vector3(coords.x,coords.y) * _boxSize + _origin ;
    }

}
