using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSystem
{
    private int _width; //Number of boxes wide
    private int _height; //Number of boxes high
    private float _cellSize; //Size of each cell
    private int[,] _gridArray; //2D Array of Coords
    private Text[,] _textArray; //2D Array of the Text GOs
    private Vector3 _originLocation; //The start point of the grid

    public GridSystem(int width, int height, float cellSize,
        GameObject text, GameObject canvas, Vector3 origin)

    {
        this._width = width;
        this._height = height;
        this._cellSize = cellSize;
        this._gridArray = new int[width, height];
        this._textArray = new Text[width, height];
        this._originLocation = origin;
        
        //Looping through all the coords
        for (int x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gridArray.GetLength(1); y++)
            {
                //Drawing Grid Lines
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1 , y), Color.white, 100f);

                //Create a Text object
                GameObject newGO = GameObject.Instantiate(text, GetWorldPosition(x, y) + (new Vector3(_cellSize,_cellSize) * 0.5f), Quaternion.identity, canvas.transform);
                newGO.name = "Text" + x + y;
                _textArray[x, y] = newGO.GetComponent<Text>();
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    //Gets the value of a specific text object
    public void setValue(int x, int y, string value)
    {
        if ((x >= 0 && x < _width) && (y >= 0 && y < _height))
        {
            _textArray[x, y].text = value;
        }
        else
        {
            Debug.LogError("Out of range! What are you doing?!");
        }
    }

    //Overloading SetValue
    public void setValue(Vector3 worldPosition, string value)
    {
        Vector2Int pos = getGridCoordinates(worldPosition);
        setValue(pos.x, pos.y, value);
    }

    //Sets the value of a specific text object
    public string getValue(int x, int y)
    {

        if ((x >= 0 && x < _width) && (y >= 0 && y < _height))
        {
            return _textArray[x, y].text;
        }
        else
        {
            return "-1";
        }
            
    }

    //Converts x and y coords to global positioning
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x,y) * _cellSize + _originLocation;
    }

    private Vector2Int getGridCoordinates(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt((worldPosition - _originLocation).x / _cellSize);
        int y = Mathf.FloorToInt((worldPosition - _originLocation).y / _cellSize);
        return new Vector2Int(x, y);
    }

}
