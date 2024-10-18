using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // Required for Serializable

[Serializable]
public class Level
{
    [Range(1, 11)]
    public int partCount = 11;

    [Range(0, 11)]
    public int deathPartCount = 1;
}

[CreateAssetMenu(fileName = "New Stage")]
public class Stage : ScriptableObject
{
    public Color stageBackgroundColor = Color.white;
    public Color stageLevelPartColor = Color.white;
    public Color stageBallColor = Color.white;

    [Range(1, 10)] // Adding a range for the number of balls
    public int ballCount = 1;

    public List<Level> levels = new List<Level>();
}
