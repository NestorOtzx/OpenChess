using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfPieces
{
    pawn, knight, bishop, rook, queen, king
}

public class PiecesGenerator : MonoBehaviour
{
    public GameObject[] pieces;

    /*string piecesLayout = "9,7,8,11,10,8,7,9,\n" +
                          "6,6,6,6,6,6,6,6,\n" +
                          "-,-,-,-,-,-,-,\n" +
                          "-,-,-,-,-,-,-,\n" +
                          "-,-,-,-,-,-,-,\n" +
                          "-,-,-,-,-,-,-,\n" +
                          "0,0,0,0,0,0,0,0,\n" +
                          "3,1,2,5,4,2,1,3";*/

    string piecesLayout = "9,7,8,11,10,8,7,9,\n" +
                          "6,6,6,6,6,6,6,6,\n" +
                          "-,-,-,-,-,-,-,\n" +
                          "-,-,-,-,-,-,-,\n" +
                          "-,-,-,-,-,-,-,\n" +
                          "-,-,-,-,-,-,-,\n" +
                          "0,0,0,0,0,0,0,0,\n" +
                          "3,-,-,5,-,-,-,3";



    public static Dictionary<GameObject, Piece> allPieces = new Dictionary<GameObject, Piece>();


    private void Awake()
    {
        allPieces.Clear();
        GeneratePieces();
    }

    void GeneratePieces()
    {
        string[] allLines = piecesLayout.Split("\n");
        System.Array.Reverse(allLines);

        if (piecesLayout == "")
        {
            return;
        }

        for (int y = 0; y < BoardManager.board.GetLength(1); y++)
        {
            string [] currLine = allLines[y].Split(",");

            for (int x = 0; x < BoardManager.board.GetLength(0); x++)
            {
                if (x < currLine.Length && BoardManager.board[x,y] != null)
                {
                    int res;
                    if (int.TryParse(currLine[x], out res))
                    {
                        Square squareToSpawn = BoardManager.board[x, y];

                        GameObject piece = Instantiate(pieces[res], squareToSpawn.transform);

                        Piece cPiece = piece.GetComponent<Piece>();
                        cPiece.currentPos = new Vector2Int(x, y);

                        cPiece.currentSquare = squareToSpawn;

                        squareToSpawn.currentPiece = cPiece;
                        squareToSpawn.isOccupied = true;

                        allPieces.Add(piece, cPiece);
                    }
                }
            }
        }
    }
}




