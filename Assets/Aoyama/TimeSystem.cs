using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeSystem : MonoBehaviour
{
    [Tooltip("タイマーを表示するText")]
    [SerializeField]  Text _timerText;

    [Tooltip("開始時のカウントダウンを表示するText")]
    [SerializeField]  Text _countDownText;

    [Tooltip("ゲーム終了時に出す文字")]
    [SerializeField]  string _finishText = "おわり";

    [Tooltip("ゲームの制限時間")]
    [SerializeField] float _gameTime;

    [Tooltip("リザルトシーンの名前")]
    [SerializeField] string _resultSceneName;

    [SerializeField] FadeSystem _fadeSystem;

    float _countDown = 3.5f;
    float _timer;

    /// <summary>ゲーム中であることを表す変数</summary>
    public static bool _isGame;


    private void Start()
    {
        _timer = _gameTime;
    }

    private void FixedUpdate()
    {
        TimeChange();
    }


    /// <summary>カウントダウンとタイムの管理を行うメソッド</summary>
    private void TimeChange()
    {
        if (!_isGame)
        {
            //カウントダウン
            _countDown -= Time.deltaTime;

            _countDownText.text = Mathf.Floor(_countDown).ToString();
        }
        else
        {
            //タイマー
            _timer -= Time.deltaTime;

            _timerText.text = _timer.ToString("F2");
        }

        if (_countDown < 1)
        {
            //カウントダウンが終わったらゲームを開始
            _countDownText.text = "";
            _isGame = true;
        }

        if (_timer <= 0)
        {
            //タイマーが０になったらゲーム終了\
            GameOver();
        }
    }


    private void GameOver()
    {
        _timerText.text = "0000";
        _isGame = false;
        _countDownText.text = _finishText;

        _fadeSystem.StartFadeOut(_resultSceneName);
    }
}
