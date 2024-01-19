using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI maxScoreText;

    public void UpdateScoreUI(int score) => scoreText.text = $"Score: {score}";

    public void UpdateMaxScoreUI(int maxScore) => maxScoreText.text = $"Max Score: {maxScore}";
}
