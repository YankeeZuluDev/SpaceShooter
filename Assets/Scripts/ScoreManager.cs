using UnityEngine;
using Zenject;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private int maxScore;
    private const string maxScoreKey = "maxScore";
    private UIManager uIManager;

    [Inject]
    private void Construct(UIManager uIManager) => this.uIManager = uIManager;

    private void Awake()
    {
        // Initialize score
        score = 0;
        maxScore = LoadMaxScore();

        // Initialize score UI
        uIManager.UpdateScoreUI(score);
        uIManager.UpdateMaxScoreUI(maxScore);
    }

    private int LoadMaxScore() => PlayerPrefs.GetInt(maxScoreKey, 0);

    public void SaveMaxScore() => PlayerPrefs.SetInt(maxScoreKey, maxScore);

    public void AddScore(int addAmount)
    {
        score += addAmount;

        uIManager.UpdateScoreUI(score);

        if (score > maxScore)
        {
            maxScore = score;
            uIManager.UpdateMaxScoreUI(maxScore);
        }
    }

    public void ResetScore()
    {
        score = 0;

        uIManager.UpdateScoreUI(score);
    }
}
