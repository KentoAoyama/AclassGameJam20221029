using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimeSystem : MonoBehaviour
{
    [Tooltip("タイマーを表示するText")]
    [SerializeField]  Text _timerText;

    [Tooltip("開始時のカウントダウンを表示するText")]
    [SerializeField]  Text _countDownText;

    [Tooltip("ゲーム終了時に出す文字")]
    [SerializeField]  string _finishText = "おわり";

    [Tooltip("タイマーが変化する色")]
    [SerializeField] Color _timerChangeColor = Color.red;

    [Tooltip("")]
    [SerializeField] float _timerColorChangeInterval = 1.0f;

    [Tooltip("ゲームの制限時間")]
    [SerializeField] float _gameTime;

    [Tooltip("リザルトシーンの名前")]
    [SerializeField] string _resultSceneName;

    [SerializeField] FadeSystem _fadeSystem;

    float _countDown = 3.9f;
    float _timer;
    float _startTime;

    bool _isTimeTextchange = false;

    /// <summary>ゲーム中であることを表す変数</summary>
    public static bool _isGame;


    private void Start()
    {
        //タイマーをリセット
        _timer = _gameTime;        
        //開始時のタイムを保存
        _startTime = _gameTime;

        _fadeSystem.StartFadeIn();
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
            //タイムが残り1/3になったら色を点滅させる
            if (_timer < _startTime/3 && !_isTimeTextchange)
            {
                _isTimeTextchange = true;
                _timerText.DOColor(_timerChangeColor, _timerColorChangeInterval).SetLoops(-1, LoopType.Yoyo);                    
            }

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

        if (_timer <= 1)
        {
            _fadeSystem.StartFadeOut(_resultSceneName);
        }
    }
}
