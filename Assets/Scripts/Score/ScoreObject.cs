using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreObject : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreUI;
    private int totalScore;
    public void ScoreIncrease(int scoreModifier)
    {
        totalScore += scoreModifier;
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = totalScore.ToString();
    }
}
