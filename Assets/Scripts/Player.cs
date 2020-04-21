using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// TODO: Maybe this can just be a special type of block or something.
public class Player : MonoBehaviour
{
    Piece piece;

    private ActionCounter actionCounter;

    public bool canMove = true;

    public bool hasWon = false;

    // Start is called before the first frame update
    void Start()
    {
        piece = GetComponent<Piece>();
        actionCounter = GameObject.FindObjectOfType<ActionCounter>();
    }

    void Update()
    {
        // Maybe put this in the piece logic.
        if (canMove && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            // piece.board.MovePiece(piece, piece.logicalPosition + new Vector3Int(0, 0, 1));

            List<Piece> moveList = new List<Piece>();
            moveList.Add(piece);
            piece.board.MovePieces(moveList, new Vector3Int(0, 0, 1));
            if (actionCounter)
            {
                actionCounter.IncrementActions();
            }
        }
        else if (canMove && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            // piece.board.MovePiece(piece, piece.logicalPosition + new Vector3Int(0, 0, -1));
            List<Piece> moveList = new List<Piece>();
            moveList.Add(piece);
            piece.board.MovePieces(moveList, new Vector3Int(0, 0, -1));
            if (actionCounter)
            {
                actionCounter.IncrementActions();
            }
        }
        else if (canMove && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            // piece.board.MovePiece(piece, piece.logicalPosition + Vector3Int.right);
            List<Piece> moveList = new List<Piece>();
            moveList.Add(piece);
            piece.board.MovePieces(moveList, Vector3Int.right);
            if (actionCounter)
            {
                actionCounter.IncrementActions();
            }
        }
        else if (canMove && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            // piece.board.MovePiece(piece, piece.logicalPosition + Vector3Int.left);
            List<Piece> moveList = new List<Piece>();
            moveList.Add(piece);
            piece.board.MovePieces(moveList, Vector3Int.left);
            if (actionCounter)
            {
                actionCounter.IncrementActions();
            }
        }
        else if (canMove && (Input.GetKeyDown(KeyCode.Q)))
        {
            // Pull
            List<Piece> piecesForward = piece.board.PushablePiecesInDirection(piece, Direction.Forward);
            piece.board.MovePieces(piecesForward, new Vector3Int(0, 0, -1));

            List<Piece> piecesBackward = piece.board.PushablePiecesInDirection(piece, Direction.Backward);
            piece.board.MovePieces(piecesBackward, new Vector3Int(0, 0, 1));

            List<Piece> piecesRight = piece.board.PushablePiecesInDirection(piece, Direction.Right);
            piece.board.MovePieces(piecesRight, new Vector3Int(-1, 0, 0));


            List<Piece> piecesLeft = piece.board.PushablePiecesInDirection(piece, Direction.Left);
            piece.board.MovePieces(piecesLeft, new Vector3Int(1, 0, 0));

            if (actionCounter)
            {
                actionCounter.IncrementActions();
            }
        }
        else if (canMove && (Input.GetKeyDown(KeyCode.E)))
        {

            List<Piece> piecesForward = piece.board.PushablePiecesInDirection(piece, Direction.Forward);
            piece.board.MovePieces(piecesForward, new Vector3Int(0, 0, 1));

            List<Piece> piecesBackward = piece.board.PushablePiecesInDirection(piece, Direction.Backward);
            piece.board.MovePieces(piecesBackward, new Vector3Int(0, 0, -1));


            List<Piece> piecesRight = piece.board.PushablePiecesInDirection(piece, Direction.Right);
            piece.board.MovePieces(piecesRight, new Vector3Int(1, 0, 0));

            List<Piece> piecesLeft = piece.board.PushablePiecesInDirection(piece, Direction.Left);
            piece.board.MovePieces(piecesLeft, new Vector3Int(-1, 0, 0));
            if (actionCounter)
            {
                actionCounter.IncrementActions();
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
