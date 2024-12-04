using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int CurrentScore { get; private set; }
    public int HighScore { get; private set; }

    private void Awake()
    {
        CurrentScore = 0; // Initialize score to zero
        HighScore = PlayerPrefs.GetInt("HighScore", 0); // Load high score from PlayerPrefs
    }

    public void IncreaseScore(int amount)
    {
        if (amount < 0) throw new System.ArgumentException("Score increment cannot be negative.");
        CurrentScore += amount;
        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
            PlayerPrefs.SetInt("HighScore", HighScore); // Save new high score
        }
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }

    public void ApplyPenalty(int penalty)
    {
        if (penalty < 0) throw new System.ArgumentException("Penalty cannot be negative.");
        CurrentScore = Mathf.Max(CurrentScore - penalty, 0); // Ensure score doesn't go below zero
    }
}
