using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public string nextLevel = "";

    private int activatedCount = 0;

    private int requiredActivatedCount = 0;

    public Material activatedMaterial;
    public Material deactivatedMaterial;

    void Start()
    {
        PushSwitch[] switches = GameObject.FindObjectsOfType<PushSwitch>();
        requiredActivatedCount = switches.Length;
        if (activatedCount < requiredActivatedCount)
        {
            GetComponent<MeshRenderer>().material = deactivatedMaterial;
        }
        else
        {
            GetComponent<MeshRenderer>().material = activatedMaterial;
        }

        foreach (PushSwitch swi in switches)
        {
            swi.attachedLevelComplete = this;

        }
    }

    public void Activate()
    {
        activatedCount++;

        if (activatedCount >= requiredActivatedCount)
        {
            GetComponent<MeshRenderer>().material = activatedMaterial;
        }
    }

    public void Deactivate()
    {
        activatedCount--;
        GetComponent<MeshRenderer>().material = deactivatedMaterial;
    }

    public void CompleteLevel(Piece piece)
    {
        if (piece.canTriggerLevelComplete && activatedCount >= requiredActivatedCount)
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
