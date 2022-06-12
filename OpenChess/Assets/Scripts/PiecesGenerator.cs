using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PiecesGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public struct PieceInfo
    {
        public int position;
        public TypeOfPiece type;
    }

    public GameObject[] whitePieces, blackPieces;

    [TextArea(5, 20)]
    public string generatorIndications;
    void Start()
    {
        GenerateWhitePieces();
        GenerateBlackPieces();
    }

    public void GenerateWhitePieces()
    {
        //Rooks
        CreatePiece(TeamOfPiece.White, TypeOfPiece.Rook, new Vector2Int(0, 0));
        CreatePiece(TeamOfPiece.White, TypeOfPiece.Rook, new Vector2Int(7, 0));

        //Bishops
        CreatePiece(TeamOfPiece.White, TypeOfPiece.Bishop, new Vector2Int(2, 0));
        CreatePiece(TeamOfPiece.White, TypeOfPiece.Bishop, new Vector2Int(5, 0));

        //Queen
        //CreatePiece(TeamOfPiece.White, TypeOfPiece.Queen, new Vector2Int(4, 0));

        //Pawns
        for (int x = 2; x < 6; x++)
        {
            CreatePiece(TeamOfPiece.White, TypeOfPiece.Pawn, new Vector2Int(x, 1));
        }
    }

    void CreatePiece(TeamOfPiece team, TypeOfPiece type, Vector2Int position)
    {
        if (team == TeamOfPiece.White)
            Instantiate(GetWhitePiece(type), GameManager.boardGenerator.squares[position.x, position.y].transform);
        else
            Instantiate(GetBlackPiece(type), GameManager.boardGenerator.squares[position.x, position.y].transform);
    }

    public void GenerateBlackPieces()
    {
        //Rooks
        CreatePiece(TeamOfPiece.Black, TypeOfPiece.Rook, new Vector2Int(0, 7));
        CreatePiece(TeamOfPiece.Black, TypeOfPiece.Rook, new Vector2Int(7, 7));

        //Bishops
        CreatePiece(TeamOfPiece.Black, TypeOfPiece.Bishop, new Vector2Int(2, 7));
        CreatePiece(TeamOfPiece.Black, TypeOfPiece.Bishop, new Vector2Int(5, 7));

        //Queen
        //CreatePiece(TeamOfPiece.Black, TypeOfPiece.Queen, new Vector2Int(4, 7));

        //Pawns
        for (int x = 2; x < 6; x++)
        {
            CreatePiece(TeamOfPiece.Black, TypeOfPiece.Pawn, new Vector2Int(x, 6));
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
