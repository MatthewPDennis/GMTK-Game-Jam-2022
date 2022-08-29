using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    public GameObject TilePrefab;

    //public Dictionary<int, GameObject> TileCollection;

    public Tile[,] Tiles { get; private set; }

    //public GridLayoutGroup GameGrid;

    //private GameObject BoardParent;

    public int Width;

    public int Height;

    void Start()
    {
        Tiles = new Tile[Width, Height];
        /*
        BoardParent = this.transform.parent.gameObject;
        CreateBoard(6);
        */
    }

    /// <summary>
    /// Creates a new game board. Y-dimension is capped at 6, but the X-dimension is variable.
    /// </summary>
    /// <param name="xDim">Determines the width of the game board</param>
    public void CreateBoard(float xDim)
    {
        /*
        if (xDim < 6) return; //Enforce minimum board size

        const int fixedHeight = 6;
        const float halfHeight = 3;

        TileCollection = new Dictionary<int, GameObject>();
        int totalTiles = fixedHeight * (int)xDim; //Board height is always 6.
        float x, y;

        x = xDim * 0.5f * -1;
        y = halfHeight * -1; //Center the board on the y-axis

        //Start the dictionary count at 1 so we can more easily find particular tiles later.
        for (int i = 1; i <= totalTiles; i++)
        {
            var gObj = Instantiate(TilePrefab, new Vector3(x, y), Quaternion.identity);
            gObj.transform.SetParent(BoardParent.transform);
            var le = gObj.AddComponent<LayoutElement>();
            le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
            le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
            le.flexibleWidth = 0;
            le.flexibleHeight = 0;
            TileCollection.Add(i, gObj);
            x += 1;
            if (x >= xDim * 0.5f)
            {
                x = xDim * 0.5f * -1;
                y += 1;
            }
        }

        var recttrans = BoardParent.GetComponent<RectTransform>();
        GameObject t;
        TileCollection.TryGetValue(1, out t);
        var vec = new Vector2();
        if (t != null)
            vec.x = t.transform.position.x;
        TileCollection.TryGetValue(totalTiles, out t);
        if (t != null)
            vec.y = -t.transform.position.y;
        recttrans.sizeDelta = vec;
        */
        
    }



}
