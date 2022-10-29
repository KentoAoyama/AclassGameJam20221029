using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreSystem : MonoBehaviour
{
    /// <summary>ゲーム内のスコアを表す</summary>
    public static int _score;

    [Tooltip("スコアを表示するテキスト")]
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


    /// <summary>スコアを加算するstaticなメソッド</summary>
    public static void AddScore(int addScore)
    {
        _score += addScore;

        var sequence = DOTween.Sequence();
        sequence.Insert(0f, _scoreText.transform.DOScale(1.2f, 0.2f).SetEase(Ease.OutCirc));
        sequence.Insert(0.5f, _scoreText.transform.DOScale(1f, 0.2f).SetEase(Ease.OutCirc));

        sequence.Play();

        Debug.Log($"現在のスコアは {_score} です");
    }
}
