using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public GameObject whiteSquarePref, blackSquarePref;

    public Square [,]squares;

    public int boardLenghtX;
    public int boardLenghtY;

    void Awake()
    {
        squares = new Square[boardLenghtX, boardLenghtY];

        GenerateBoard();

    }

    private void GenerateBoard()
    {
        GameObject currentSquare = blackSquarePref;
        

        for (int y = 0; y < boardLenghtY; y++)
        {
            for (int x = 0; x < boardLenghtX; x++)
            {
                squares[x, y] = Instantiate(currentSquare, new Vector2(x, y), Quaternion.identity, transform).GetComponent<Square>();
                squares[x, y].squarePos = new Vector2Int(x, y);
                
                //if its the last iteration dont change color of squares
                if (x == boardLenghtX - 1)
                {
                    break;
                }
                //Switch color of squares
                if (currentSquare == blackSquarePref)
                {
                    currentSquare = whiteSquarePref;
                }
                else
                {
                    currentSquare = blackSquarePref;
                }
            }
        }
    }
}
