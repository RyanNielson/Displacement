using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSwitch : MonoBehaviour
{
    public bool isPressed = false;

    public void Pressed(Piece piece)
    {
        isPressed = true;
    }

    public void Released(Piece piece)
    {
        isPressed = false;
    }
}
