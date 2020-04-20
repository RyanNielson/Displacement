using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionCounter : MonoBehaviour
{
    public int maximumActions = 1;
    public int actionsSoFar = 0;

    // public

    // public TextMesh text;

    public Text text;

    public bool triggered = false;

    void Start()
    {
        Debug.Log("LIMIT MOVES");
        Debug.Log(ConfigManager.limitMoves);
        if (!ConfigManager.limitMoves)
        {
            Destroy(gameObject);
        }
        text.text = maximumActions.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (maximumActions - actionsSoFar <= 0 && !triggered)
        {
            Player player = GameObject.FindObjectOfType<Player>();
            player.canMove = false;

            text.text = "PRESS R TO RESET";
            text.color = Color.red;
        }
    }

    public void IncrementActions()
    {
        actionsSoFar++;

        actionsSoFar = Mathf.Clamp(actionsSoFar, 0, maximumActions);

        text.text = (maximumActions - actionsSoFar).ToString();
    }
}
