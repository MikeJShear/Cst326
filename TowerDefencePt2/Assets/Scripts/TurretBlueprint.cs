using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public static implicit operator TurretBlueprint(Node v)
    {
        throw new NotImplementedException();
    }
}
