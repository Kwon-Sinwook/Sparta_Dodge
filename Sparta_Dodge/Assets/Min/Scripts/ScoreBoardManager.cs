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

    // 적 캐릭터 제거하고 점수를 증가시킬 때 사용
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
