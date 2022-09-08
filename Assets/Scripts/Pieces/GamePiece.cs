using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    /// <summary>
    /// Sprite used to represent this game piece
    /// </summary>
    public GameObject SpritePrefab;

    /// <summary>
    /// 
    /// </summary>
    public Tile BoardPosition;

    /// <summary>
    /// Name of the game piece.
    /// </summary>
    public string Name;

    /// <summary>
    /// Legal moves for this game piece
    /// </summary>
    public List<Vector2> LegalMoves;

    //public PieceType Type;

    void Start()
    {
        
    }

    void OnMouseUp()
    {

    }

    public bool IsMoveLegal(Vector2 move)
    {
        return LegalMoves.Contains(move);
    }


}
