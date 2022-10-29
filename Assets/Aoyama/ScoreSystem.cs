using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    /// <summary>�Q�[�����̃X�R�A��\��</summary>
    public static int _score;
    static readonly int _addScore = 100;
    static readonly int _decreaseScore = 100;

    [Tooltip("�X�R�A��\������e�L�X�g")]
    [SerializeField] Text _scoreText;

    void Awake()
    {
        _score = 0;
    }

    
    void Update()
    {
        _scoreText.text = _score.ToString("D5");
    }


    /// <summary>�X�R�A�����Z����static�ȃ��\�b�h</summary>
    public static void AddScore()
    {
        _score += _addScore;
    }


    /// <summary>�X�R�A�����Z����static�ȃ��\�b�h</summary>
    public static void DecreaseScore()
    {
        _score -= _decreaseScore;

        //�X�R�A�̓}�C�i�X�ɂ����Ȃ����̂Ƃ���
        if (_score < 0)
        {
            _score = 0;
        }
    }
}
