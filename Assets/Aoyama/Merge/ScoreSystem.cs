using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreSystem : MonoBehaviour
{
    /// <summary>�Q�[�����̃X�R�A��\��</summary>
    public static int _score;

    [Tooltip("�X�R�A��\������e�L�X�g")]
    static Text _scoreText;

    private void Awake()
    {
        _score = 0;
        _scoreText = GetComponent<Text>();
    }

    
    private void Update()
    {
        _scoreText.text = _score.ToString("D2");
    }


    /// <summary>�X�R�A�����Z����static�ȃ��\�b�h</summary>
    public static void AddScore(int addScore)
    {
        _score += addScore;

        var sequence = DOTween.Sequence();
        sequence.Insert(0f, _scoreText.transform.DOScale(1.2f, 0.2f).SetEase(Ease.OutCirc));
        sequence.Insert(0.5f, _scoreText.transform.DOScale(1f, 0.2f).SetEase(Ease.OutCirc));

        sequence.Play();

        Debug.Log($"���݂̃X�R�A�� {_score} �ł�");
    }
}
