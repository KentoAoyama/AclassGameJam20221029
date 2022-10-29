using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    /// <summary>ゲーム内のスコアを表す</summary>
    public static int _score;

    [Tooltip("スコアを表示するテキスト")]
    [SerializeField] Text _scoreText;


    private void Awake()
    {
        _score = 0;
    }

    
    private void Update()
    {
        _scoreText.text = _score.ToString("D5");
    }


    /// <summary>スコアを加算するstaticなメソッド</summary>
    public static void AddScore(int addScore)
    {
        _score += addScore;
    }
}
