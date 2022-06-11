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
    Square currentSquare;
    public void OnBeingGrabbed()
    {
        Debug.Log("Grabbed");
    }

    public void OnBeingDropped(Square squareDroped)
    {
        Debug.Log("Dropped");
        if (squareDroped != null)
        {
            //currentSquare.isOcuped = false;
            currentSquare = squareDroped;
            currentSquare.isOcuped = true;
        }
        
        transform.position = currentSquare.transform.position;
        transform.parent = currentSquare.transform;
    }

}
