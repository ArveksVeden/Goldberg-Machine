using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private string Name;
    public bool IsDone;

    public Level(string name, bool isDone)
    {
        Name = name;
        IsDone = isDone;
    }
}
