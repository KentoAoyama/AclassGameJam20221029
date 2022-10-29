using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeSystem : MonoBehaviour
{
    [Tooltip("�^�C�}�[��\������Text")]
    [SerializeField]  Text _timerText;

    [Tooltip("�J�n���̃J�E���g�_�E����\������Text")]
    [SerializeField]  Text _countDownText;

    [Tooltip("�Q�[���I�����ɏo������")]
    [SerializeField]  string _finishText = "�����";

    [Tooltip("�Q�[���̐�������")]
    [SerializeField] float _gameTime;

    [Tooltip("���U���g�V�[���̖��O")]
    [SerializeField] string _resultSceneName;

    [SerializeField] FadeSystem _fadeSystem;

    float _countDown = 3.5f;
    float _timer;

    /// <summary>�Q�[�����ł��邱�Ƃ�\���ϐ�</summary>
    public static bool _isGame;


    private void Start()
    {
        _timer = _gameTime;
    }

    private void FixedUpdate()
    {
        TimeChange();
    }


    /// <summary>�J�E���g�_�E���ƃ^�C���̊Ǘ����s�����\�b�h</summary>
    private void TimeChange()
    {
        if (!_isGame)
        {
            //�J�E���g�_�E��
            _countDown -= Time.deltaTime;

            _countDownText.text = Mathf.Floor(_countDown).ToString();
        }
        else
        {
            //�^�C�}�[
            _timer -= Time.deltaTime;

            _timerText.text = _timer.ToString("F2");
        }

        if (_countDown < 1)
        {
            //�J�E���g�_�E�����I�������Q�[�����J�n
            _countDownText.text = "";
            _isGame = true;
        }

        if (_timer <= 0)
        {
            //�^�C�}�[���O�ɂȂ�����Q�[���I��\
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
