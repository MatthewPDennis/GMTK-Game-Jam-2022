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
    /// Integer from game board dictionary representing position of game piece on the board
    /// </summary>
    public int BoardPosition;

    /// <summary>
    /// Legal moves for this game piece
    /// </summary>
    public List<Vector2> LegalMoves;

    //public PieceType Type;

    void Start()
    {
        
    }


    public bool IsMoveLegal(Vector2 move)
    {
        return LegalMoves.Contains(move);
    }


}
