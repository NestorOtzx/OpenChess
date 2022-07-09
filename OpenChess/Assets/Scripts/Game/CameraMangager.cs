using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMangager : MonoBehaviour
{
    public Vector2 offset;
    Camera mainCamera;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void Start()
    {
        SetCameraPos();
    }

    private void SetCameraPos()
    {
        mainCamera.orthographicSize = 0;

        Vector2 boardSize = new Vector2(BoardManager.board.GetLength(0), BoardManager.board.GetLength(1));

        int longestSize = boardSize.x > boardSize.y ? (int)boardSize.x : (int)boardSize.y;

        mainCamera.orthographicSize = 0.5f * longestSize;

        float posX = (boardSize.x / 2) - 0.5f;
        float posY = (boardSize.y / 2) - 0.5f;

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
