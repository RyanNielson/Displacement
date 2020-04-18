using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public string nextLevel = "";
    public void CompleteLevel(Piece piece)
    {
        Debug.Log("Level Complete: " + piece.name);
        SceneManager.LoadScene(nextLevel);
    }
}
