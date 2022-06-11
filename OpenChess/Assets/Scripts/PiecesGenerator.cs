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
        for (int x = 0; x < 8; x++)
        {
            Instantiate(GetWhitePiece(TypeOfPiece.Pawn), GameManager.boardGenerator.squares[x, 0].transform);

        }

    }

    public void GenerateBlackPieces()
    {
        for (int x = 0; x < 8; x++)
        {
            Instantiate(GetBlackPiece(TypeOfPiece.Pawn), GameManager.boardGenerator.squares[x, 7].transform);

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
