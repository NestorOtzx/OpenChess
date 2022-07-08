using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    //Remember!!! Last line shouldnt have "\n";



    public GameObject squarePref;
    
    
    
    public Color blackSquareColor;


    public static Square[,] board;

    public static Dictionary<GameObject, Square> allSquares = new Dictionary<GameObject, Square>();

    private void Awake()
    {
        GenerateBoard(GameManager.instance.gameMode.board);
        
    }

    void GenerateBoard(string boardShape)
    {
        string [] allLines = boardShape.Split("\n");

        System.Array.Reverse(allLines);

        int lenghtY = allLines.Length;
        int lenghtX = GetLongestFile(allLines);

        board = new Square[lenghtX, lenghtY];

        for (int y = 0; y < allLines.Length; y++)
        {

            for (int x = 0; x < allLines[y].Length; x++)
            {
                string currentLine = allLines[y];

                Square square = null;

                if (currentLine[x] == '□')
                {
                    square = Instantiate(squarePref, new Vector2(x, y), Quaternion.identity, transform).GetComponent<Square>();
                    square.SetColor(blackSquareColor);
                }
                else if (currentLine[x] == '■')
                {
                    square = Instantiate(squarePref, new Vector2(x, y), Quaternion.identity, transform).GetComponent<Square>();
                }

                if (square)
                {
                    board[x, y] = square;

                    square.squarePos = new Vector2Int(x, y);
                    allSquares.Add(square.gameObject, square);
                }
            }
        }
    }

    public static bool CheckBoardPos(int x, int y)
    {
        return x >= 0 && y >= 0 && x < board.GetLength(0) && y < board.GetLength(1) && board[x, y] != null;
    }

    public static bool CheckBoardPos(Square square)
    {
        if (!square)
        {
            return false;
        }

        int x = square.squarePos.x;
        int y = square.squarePos.y;

        return x >= 0 && y >= 0 && x < board.GetLength(0) && y < board.GetLength(1) && board[x, y] != null;
    }

    int GetLongestFile(string [] lines)
    {
        int longest= 0;

        for(int i = 0; i<lines.Length; i++)
        {
            if (lines[i].Length >= longest)
            {
                longest = lines[i].Length;
            }
        }

        return longest;
    }
}

