using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardManager : MonoBehaviour
{
    [SerializeField] private Text timeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;

    private float time = 0.0f;
    private float totalScore = 0.0f;
    private float bestScore = 0.0f;

    private void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("N2");
    }

    // �� ĳ���� �����ϰ� ������ ������ų �� ���
    public void UpdateScore(float score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();

        if(totalScore > bestScore)
        {
            bestScore = totalScore;
            bestScoreText.text = bestScore.ToString();
        }
    }
}
