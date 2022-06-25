using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public GameObject highlight;
    SpriteRenderer spr;
    public Vector2Int squarePos;

    //Utilities
    public bool isOccupied;
    public Piece currentPiece;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        ToggleHighlight(false);
    }

    public void SetColor(Color color)
    {
        spr.color = color;
    }

    public void ToggleHighlight(bool t)
    {
        highlight.SetActive(t);
    }
}
