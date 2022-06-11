using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPawn : WhitePawn
{
    public override void SetWhiteAvailableSquares()
    {
        int position = currentSquare.squareID;
        List<Square> squares = GameManager.instance.boardSquares;

        Debug.Log(position - GameManager.instance.boardX);

        squares[position - GameManager.instance.boardX].isAvailable = true;
    }

    protected override void UnavailableSquares()
    {
        int position = currentSquare.squareID;
        List<Square> squares = GameManager.instance.boardSquares;

        if (movedTwice)
        {
            squares[position - 2 * GameManager.instance.boardX].isAvailable = false;
        }

        squares[position - GameManager.instance.boardX].isAvailable = false;
    }

}
