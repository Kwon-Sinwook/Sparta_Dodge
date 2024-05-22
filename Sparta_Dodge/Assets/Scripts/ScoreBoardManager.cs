using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardManager : MonoBehaviour
{
    [SerializeField] private Text timeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;

    private float time;
    private float totalScore;
    private float bestScore;

    private Data data;

    private void Start()
    {
        data = DataManager.Instance.Load();

        time = 0.0f;
        totalScore = 0.0f;
        bestScore = data.bestScore;
        bestScoreText.text = bestScore.ToString();
    }

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

            DataManager.Instance.Save(new Data(bestScore));
        }
    }
}
