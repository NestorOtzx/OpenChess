using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera mainC;

    bool dragging = false;

    public LayerMask piecesLayer, boardLayer;
    public TEAM playerTeam;

    Piece piece;
    List<Square> possibleMoves;

    void Start()
    {
        mainC = Camera.main;
    }

    // Update is called once per frame
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Get the piece under the cursor
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(mainC.ScreenPointToRay(Input.mousePosition), 50, piecesLayer);
            if (hit.collider)
            {
                piece = PiecesGenerator.allPieces[hit.transform.gameObject];
                
                if (piece.team == TurnManager.currentTeamTurn)
                {
                    dragging = true;
                    possibleMoves = piece.GetPossibleMoves();
                    HighlightPossibleMoves(true);
                }
                else
                {
                    piece = null;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (!piece)
            {
                return;
            }

            var mousePos = mainC.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D square = Physics2D.GetRayIntersection(mousePos, 50, boardLayer);

            dragging = false;

            HighlightPossibleMoves(false);


            if (square.collider && square.transform != piece.currentSquare.transform)
            {
                Square sqreToJump = BoardManager.allSquares[square.transform.gameObject];

                if (possibleMoves.Contains(sqreToJump))
                {
                    piece.Move(BoardManager.allSquares[square.transform.gameObject]);
                }
                else
                {
                    CancelMove();
                }
            }
            else
            {
                CancelMove();
            }
        }
        if (dragging) //Piece Movement
        {
            Vector3 newPos = mainC.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0;
            piece.transform.position = newPos;
        }
    }

    private void CancelMove()
    {
        piece.transform.position = (Vector2)piece.currentSquare.squarePos;
    }

    void HighlightPossibleMoves(bool t)
    {
        for (int i = 0; i<possibleMoves.Count; i++)
        {
            possibleMoves[i].ToggleHighlight(t);
        }
    }

  
}
