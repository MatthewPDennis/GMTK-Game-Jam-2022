using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    public GamePiece Occupier;

    [SerializeField]
    private SpriteRenderer Renderer;

    [SerializeField]
    private Color BaseColor, OffsetColor;

    public void Init(bool isOffset)
    {
        Renderer.color = isOffset ? OffsetColor : BaseColor;
    }
}
