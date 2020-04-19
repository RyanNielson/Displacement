﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MovedAboveEvent : UnityEvent<Piece>
{
}

public class Piece : MonoBehaviour
{
    public bool pushable = false;
    public Vector3Int logicalPosition = Vector3Int.zero;
    public Board board;

    public MovedAboveEvent movedAbove;

    public bool canTriggerLevelComplete;

}
