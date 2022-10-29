using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    /// <summary>�Q�[�����̃X�R�A��\��</summary>
    public static int _score;

    [Tooltip("�X�R�A��\������e�L�X�g")]
    [SerializeField] Text _scoreText;


    private void Awake()
    {
        _score = 0;
    }

    
    private void Update()
    {
        _scoreText.text = _score.ToString("D5");
    }


    /// <summary>�X�R�A�����Z����static�ȃ��\�b�h</summary>
    public static void AddScore(int addScore)
    {
        _score += addScore;
    }
}
