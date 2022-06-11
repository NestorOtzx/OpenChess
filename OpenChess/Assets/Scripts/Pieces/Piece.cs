using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum TypeOfPiece
{
    Pawn, King, Queen, Knight, Rook, Bishop
}

public class Piece : MonoBehaviour
{
    protected Square currentSquare;

    private void Start()
    {
        currentSquare = transform.parent.GetComponent<Square>();
        currentSquare.isOcuped = true;
    }

    public virtual void SetWhiteAvailableSquares()
    {
        int position = currentSquare.squareID;
        List<Square> squares = GameManager.instance.boardSquares;

        squares[position + GameManager.instance.boardX].isAvailable = true;
    }

    protected virtual void UnavailableSquares()
    {
     
    }

    public virtual void OnBeingGrabbed()
    {
        SetWhiteAvailableSquares();
    }

    public virtual void OnBeingDropped(Square squareDroped)
    {
        if (squareDroped != null && squareDroped.isAvailable && !squareDroped.isOcuped)
        {
            currentSquare.isOcuped = false;
            currentSquare = squareDroped;
            currentSquare.isOcuped = true;
        }
        
        transform.position = currentSquare.transform.position;
        transform.parent = currentSquare.transform;
    }

}
