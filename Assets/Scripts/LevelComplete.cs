using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public string nextLevel = "";
    public void CompleteLevel(Piece piece)
    {
        if (piece.canTriggerLevelComplete)
        {
            StartCoroutine(SwitchLevel());
        }
    }

    IEnumerator SwitchLevel()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(nextLevel);
    }
}
