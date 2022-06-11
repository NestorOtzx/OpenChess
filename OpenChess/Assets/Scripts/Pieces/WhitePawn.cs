using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePawn : Piece
{
    
    protected bool firstMove = true;
    protected bool movedTwice = false;
    public override void SetWhiteAvailableSquares()
    {
        int position = currentSquare.squareID;
        List<Square> squares = GameManager.instance.boardSquares;

        if (firstMove)
        {
            squares[position + 2*GameManager.instance.boardX].isAvailable = true;
            movedTwice = true;
        }

        squares[position + GameManager.instance.boardX].isAvailable = true;
    }

    protected override void UnavailableSquares()
    {
        int position = currentSquare.squareID;
        List<Square> squares = GameManager.instance.boardSquares;

        if (movedTwice)
        {
            squares[position + 2 * GameManager.instance.boardX].isAvailable = false;
        }
        
        squares[position + GameManager.instance.boardX].isAvailable = false;
    }

    public override void OnBeingDropped(Square squareDroped)
    {
        bool auxSquareDropedAv = squareDroped.isAvailable;

        //Disable all avaiblable squares
        UnavailableSquares();

        if (squareDroped != null && auxSquareDropedAv && !squareDroped.isOcuped)
        {
            
            currentSquare.isOcuped = false;
            currentSquare = squareDroped;
            currentSquare.isOcuped = true;
            firstMove = false;
            movedTwice = false;
        }
        

        transform.position = currentSquare.transform.position;
        transform.parent = currentSquare.transform;
    }
}
