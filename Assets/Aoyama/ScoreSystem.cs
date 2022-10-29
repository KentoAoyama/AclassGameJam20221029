using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    /// <summary>ゲーム内のスコアを表す</summary>
    public static int _score;
    static readonly int _addScore = 100;
    static readonly int _decreaseScore = 100;

    [Tooltip("スコアを表示するテキスト")]
    [SerializeField] Text _scoreText;

    void Awake()
    {
        _score = 0;
    }

    
    void Update()
    {
        _scoreText.text = _score.ToString("D5");
    }


    /// <summary>スコアを加算するstaticなメソッド</summary>
    public static void AddScore()
    {
        _score += _addScore;
    }


    /// <summary>スコアを減算するstaticなメソッド</summary>
    public static void DecreaseScore()
    {
        _score -= _decreaseScore;

        //スコアはマイナスにいかないものとする
        if (_score < 0)
        {
            _score = 0;
        }
    }
}
