using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PiecesGenerator : MonoBehaviour
{
    public GameObject[] whitePieces, blackPieces;

    [TextArea(5, 20)]
    public string generatorIndications;
    void Awake()
    {
        GenerateWhitePieces();
        GenerateBlackPieces();
    }

    public void GenerateWhitePieces()
    {
        //Rooks
        CreatePiece(Team.White, TypeOfPiece.Rook, new Vector2Int(0, 0));
        CreatePiece(Team.White, TypeOfPiece.Rook, new Vector2Int(7, 0));

        //Bishops
        CreatePiece(Team.White, TypeOfPiece.Bishop, new Vector2Int(2, 0));
        CreatePiece(Team.White, TypeOfPiece.Bishop, new Vector2Int(5, 0));



        //Knights
        CreatePiece(Team.White, TypeOfPiece.Knight, new Vector2Int(1, 0));
        CreatePiece(Team.White, TypeOfPiece.Knight, new Vector2Int(6, 0));

        //King
        CreatePiece(Team.White, TypeOfPiece.King, new Vector2Int(3, 0));

        //Queen
        CreatePiece(Team.White, TypeOfPiece.Queen, new Vector2Int(4, 0));

        

        //Pawns
        for (int x = 0; x < 8; x++)
        {
            CreatePiece(Team.White, TypeOfPiece.Pawn, new Vector2Int(x, 1));
        }
    }

    void CreatePiece(Team team, TypeOfPiece type, Vector2Int position)
    {
        if (team == Team.White)
            Instantiate(GetWhitePiece(type), GameManager.boardGenerator.squares[position.x, position.y].transform);
        else
            Instantiate(GetBlackPiece(type), GameManager.boardGenerator.squares[position.x, position.y].transform);
    }

    public void GenerateBlackPieces()
    {
        //Rooks
        CreatePiece(Team.Black, TypeOfPiece.Rook, new Vector2Int(0, 7));
        CreatePiece(Team.Black, TypeOfPiece.Rook, new Vector2Int(7, 7));

        //Bishops
        CreatePiece(Team.Black, TypeOfPiece.Bishop, new Vector2Int(2, 7));
        CreatePiece(Team.Black, TypeOfPiece.Bishop, new Vector2Int(5, 7));

        //Knights
        CreatePiece(Team.Black, TypeOfPiece.Knight, new Vector2Int(1, 7));
        CreatePiece(Team.Black, TypeOfPiece.Knight, new Vector2Int(6, 7));

        //King
        CreatePiece(Team.Black, TypeOfPiece.King, new Vector2Int(3, 7));

        //Queen
        CreatePiece(Team.Black, TypeOfPiece.Queen, new Vector2Int(4, 7));

        //Pawns
        for (int x = 0; x < 8; x++)
        {
            CreatePiece(Team.Black, TypeOfPiece.Pawn, new Vector2Int(x, 6));
        }
    }
    GameObject GetBlackPiece(TypeOfPiece type)
    {
        return blackPieces[(int)type];
    }

    GameObject GetWhitePiece(TypeOfPiece type)
    {
        return whitePieces[(int)type];
    }

}
