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
        for (int j = 0; j < 8; j++)
        {
            Instantiate(GetWhitePiece(TypeOfPiece.Pawn), new Vector2(j, 0), Quaternion.identity, GameManager.instance.boardSquares[j].transform);
        }
    }

    public void GenerateBlackPieces()
    {
        for (int j = 0; j < 8; j++)
        {
            Instantiate(GetBlackPiece(TypeOfPiece.Pawn), new Vector2(j, 7), Quaternion.identity, GameManager.instance.boardSquares[j+7*GameManager.instance.boardX].transform);
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
