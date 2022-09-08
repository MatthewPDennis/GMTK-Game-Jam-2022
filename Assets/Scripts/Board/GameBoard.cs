using System;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    [SerializeField]
    public GameObject TilePrefab;

    [SerializeField]
    public Dictionary<Vector2Int, GameObject> TileCollection;

    [SerializeField]
    private int XDimension;

    [SerializeField]
    private int YDimension {  get { return 6; } }

    [SerializeField]
    private Transform Camera;

    void Start()
    {
        TileCollection = new Dictionary<Vector2Int, GameObject>();
        CreateBoard(10);
    }

    /// <summary>
    /// Creates a new game board. Y-dimension is capped at 6, but the X-dimension is variable.
    /// </summary>
    /// <param name="xDim">Determines the width of the game board</param>
    public void CreateBoard(int xDim)
    {
        XDimension = xDim;

        for (int x = 0; x < XDimension; x++)
        {
            for (int y = 0; y < YDimension; y++)
            {
                var isOffset = ((x + y) % 2 == 1);

                var tileObj = Instantiate(TilePrefab, new Vector3(x, y), Quaternion.identity, this.transform);
                Tile t = tileObj.GetComponent<Tile>();
                t.Init(isOffset);
                tileObj.name = $"Tile {x},{y}";
                TileCollection.Add(new Vector2Int(x, y), tileObj);
            }
        }

        Camera.transform.position = new Vector3(((float)XDimension * 0.5f) -0.5f, ((float)YDimension * 0.5f) - 0.5f, Camera.transform.position.z);


    }



}
