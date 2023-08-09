using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public float difficultyMultiplier = 1;
    public static DifficultyManager Instance;
    private void Start()
    {
        Instance = this;
    }
}
