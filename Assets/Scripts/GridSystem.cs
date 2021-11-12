using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GridSystem
{
    private int _width; //Number of boxes wide
    private int _height; //Number of boxes high
    private float _boxSize; //Size of each box
    private int[,] _boxArray; //2D Array storing all the boxes
    private Text[,] _textarray; //2D Array storing all the text boxes

    private Vector3 _origin; //World location where the grid will start

    public GridSystem(int width, int height, float boxSize, Vector3 origin, GameObject text, Canvas canvas)
    {
        this._width = width;
        this._height = height;
        this._boxSize = boxSize;
        this._origin = origin;

        this._boxArray = new int[width,height];
        this._textarray = new Text[width, height];

        for (int x = 0; x < _boxArray.GetLength(0); x++)
        {
            for (int y = 0; y < _boxArray.GetLength(1); y++)
            {
                Debug.DrawLine(GetWorldPosition(new Vector2Int(x, y)), GetWorldPosition(new Vector2Int(x + 1, y)),Color.white,100f);
                Debug.DrawLine(GetWorldPosition(new Vector2Int(x, y)), GetWorldPosition(new Vector2Int(x, y + 1)), Color.white,100f);

                //Instantiate a text object
                GameObject newGO = GameObject.Instantiate(text, GetWorldPosition(new Vector2Int(x, y)) + (new Vector3(_boxSize,_boxSize) * 0.5f),
                    Quaternion.identity, canvas.transform);
                newGO.name = "Text" + x + y;
                _textarray[x, y] = newGO.GetComponent<Text>();
            }
        }
        //Add the two missing lines
        Debug.DrawLine(GetWorldPosition(new Vector2Int(0, height)), GetWorldPosition(new Vector2Int(width, height)), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(new Vector2Int(width, 0)), GetWorldPosition(new Vector2Int(width, height)), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(Vector2Int coords)
    {
        return new Vector3(coords.x,coords.y) * _boxSize + _origin ;
    }

    //Sets the value of a text component
    public void setValue(Vector2Int coords, string value)
    {
        if ((coords.x >= 0 && coords.x < _width) &&
            (coords.y >=0 && coords.y < _height))
        {
            _textarray[coords.x, coords.y].text = value;
        }
        else
        {
            Debug.LogError("Out of range! What are you doing?!");
        }
    }

    //Function overload of set Value (input is worldPosition)
    public void setValue(Vector3 worldPosition, string value)
    {
        Vector2Int pos = getGridCoords(worldPosition);
        setValue(pos, value);
    }

    //Gets the value of a text component
    public string getValue(Vector2Int coords)
    {
        if ((coords.x >= 0 && coords.x < _width) &&
            (coords.y >= 0 && coords.y < _height))
        {
           return _textarray[coords.x, coords.y].text;
        }
        else
        {
            return "-1";
        }
    }

    //Function overload of get Value (input is worldPosition)
    public string getValue(Vector3 worldPosition, string value)
    {
        Vector2Int pos = getGridCoords(worldPosition);
        return getValue(pos);
    }

    //Converting the world position of the grid into x and y values representing out boxes
    private Vector2Int getGridCoords(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt((worldPosition - this._origin).x / _boxSize); //Converting float to int (floor)
        int y = Mathf.FloorToInt((worldPosition - this._origin).y / _boxSize); //Converting float to int (floor)
        return new Vector2Int(x,y);
    }

}
