using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Piece currentPiece;
    Camera mainC;

    bool dragging = false;

    [SerializeField]
    LayerMask piecesLayer, boardLayer;

    public Team currentTeam;

    void Start()
    {
        mainC = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Play();
    }

    public virtual void Play()
    {
        if (Input.GetMouseButtonDown(0)) //Get the piece under the cursor
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(mainC.ScreenPointToRay(Input.mousePosition), 50, piecesLayer);

            if (hit.collider != null)
            {
                currentPiece = hit.transform.GetComponent<Piece>();

                if (currentPiece.team == currentTeam)
                {
                    currentPiece.OnBeingGrabbed();
                    dragging = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            if (currentPiece != null) //Get the square under the cursor to put the piece in there
            {
                RaycastHit2D hit = Physics2D.GetRayIntersection(mainC.ScreenPointToRay(Input.mousePosition), 50, boardLayer);

                if (hit.collider)
                {
                    Square currentSquare = hit.transform.GetComponent<Square>();

                    currentPiece.OnBeingDropped(currentSquare);
                }
                else //There is no square under the cursor
                {
                    currentPiece.OnBeingDropped(null);
                }
            }
        }
        if (dragging) //Piece Movement
        {
            Vector3 newPos = mainC.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0;
            currentPiece.transform.position = newPos;
        }
    }
}
