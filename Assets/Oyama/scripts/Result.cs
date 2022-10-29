using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Result : MonoBehaviour
{
    static int maxgamescore;
    [SerializeField] Text scoreText;
    [SerializeField] Text scoreLogo;
    [SerializeField] Text _highScore;
    [SerializeField] string _highScoreText = "High Score!!";
    [SerializeField] FadeSystem _fadesystem;
    float _scoreChangeInterval;

    private void Awake()
    {
        _highScore.text = "";
    }

    void Start()
    {
        _fadesystem.StartFadeIn();

        int tempScore = ScoreSystem._score;

        DOTween.To(() => tempScore, x =>
        {
            tempScore = x;
            scoreText.text = tempScore.ToString();
        }, ScoreSystem._score, _scoreChangeInterval).OnComplete(() => Draw());
    }

    private void Draw()
    {
        scoreText.text = ScoreSystem._score.ToString();
        if (ScoreSystem._score >= maxgamescore)
        {
            _highScore.text = _highScoreText;
            maxgamescore = ScoreSystem._score;
        }
    }
}
