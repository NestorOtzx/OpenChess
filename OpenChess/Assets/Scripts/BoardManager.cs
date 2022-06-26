using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    string boardShape ="□■□■□■□■\n" +
                       "■□■□■□■□\n" +
                       "□■□■□■□■\n" +
                       "■□■□■□■□\n" +
                       "□■□■□■□■\n" +
                       "■□■□■□■□\n" +
                       "□■□■□■□■\n" +
                       "■□■□■□■□";
    //Remember!!! Last line shouldnt have "\n";



    public GameObject squarePref;
    
    
    
    public Color blackSquareColor;


    public static Square[,] board;

    public static Dictionary<GameObject, Square> allSquares = new Dictionary<GameObject, Square>();

    private void Awake()
    {
        GenerateBoard();
        
    }

    void GenerateBoard()
    {
        string [] allLines = boardShape.Split("\n");

        System.Array.Reverse(allLines);

        int lenght = GetLongestFile(allLines);
        int width = allLines.Length;

        board = new Square[lenght, width];

        for (int y = 0; y<allLines.Length; y++)
        {
            for (int x = 0; x<allLines[y].Length; x++)
            {
                char letter = allLines[y][x];

                Square square = null;

                if (letter == '■')
                {
                    square = Instantiate(squarePref, new Vector2(x, y), Quaternion.identity, transform).GetComponent<Square>();

                    //Color sqrColor = Color.black;
                    //ColorUtility.TryParseHtmlString("#5945C6", out sqrColor);
                    square.SetColor(blackSquareColor);
                }
                else if (letter == '□')
                {
                    square = Instantiate(squarePref, new Vector2(x, y), Quaternion.identity, transform).GetComponent<Square>();
                }

                board[x, y] = square;
                if (square)
                {
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

        Debug.Log(longest);

        return longest;
    }
}

