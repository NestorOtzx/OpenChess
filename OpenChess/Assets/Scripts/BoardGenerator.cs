using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public GameObject whiteSquarePref, blackSquarePref;

    int boardLenghtX;
    int boardLenghtY;

    void Awake()
    {
        boardLenghtX = GameManager.instance.boardX;
        boardLenghtY = GameManager.instance.boardY;

        GenerateBoard();
    }

    private void GenerateBoard()
    {
        GameObject currentSquare = blackSquarePref;

        for (int i = 0; i<boardLenghtY; i++)
        {
            for(int j = 0; j<boardLenghtX; j++)
            {
                Instantiate(currentSquare, new Vector2(j, i), Quaternion.identity, transform);

                //if its the last iteration dont change color of squares
                if (j==boardLenghtX-1){
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
