using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PiecesGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    BoardGenerator board;

    [System.Serializable]
    public struct PieceInfo
    {
        public int position;
        public TypeOfPiece type;
    }

    public GameObject[] piecesPrefs;

    [TextArea(5, 20)]
    public string generatorIndications;


    void Start()
    {
        board = GetComponent<BoardGenerator>();

        for (int j = 0; j < board.boardLenghtX; j++)
        {
            Instantiate(GetPiece(TypeOfPiece.Pawn), new Vector2(j, 0), Quaternion.identity, transform);
        }
    }

    GameObject GetPiece(TypeOfPiece type)
    {
        return piecesPrefs[(int)type];
    }

}
