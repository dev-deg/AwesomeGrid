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

}
