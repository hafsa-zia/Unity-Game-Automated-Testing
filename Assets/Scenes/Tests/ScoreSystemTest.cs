using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ScoreSystemTest
{
    private GameObject player;
    private ScoreSystem scoreSystem;

    [SetUp]
    public void SetUp()
    {
        // Create a GameObject with ScoreSystem for testing
        player = new GameObject("Player");
        scoreSystem = player.AddComponent<ScoreSystem>();
    }

    [Test]
    public void ScoreSystem_IncreaseScore_IncreasesCorrectly()
    {
        // Act
        scoreSystem.IncreaseScore(10); // Increase score by 10

        // Assert
        Assert.AreEqual(10, scoreSystem.CurrentScore, "Score should increase correctly.");
    }

    [Test]
    public void ScoreSystem_HighScore_UpdatesCorrectly()
    {
        // Arrange
        scoreSystem.IncreaseScore(50); // Current score = 50
        int initialHighScore = scoreSystem.HighScore;

        // Act
        scoreSystem.IncreaseScore(20); // Increase score by 20, new score = 70

        // Assert
        Assert.AreEqual(70, scoreSystem.CurrentScore, "Score should increase correctly.");
        Assert.AreEqual(70, scoreSystem.HighScore, "HighScore should update to the new score.");
    }

    [Test]
    public void ScoreSystem_ResetScore_ResetsToZero()
    {
        // Arrange
        scoreSystem.IncreaseScore(50); // Set score to 50

        // Act
        scoreSystem.ResetScore(); // Reset score

        // Assert
        Assert.AreEqual(0, scoreSystem.CurrentScore, "Score should be reset to zero.");
    }

    [Test]
    public void ScoreSystem_ApplyPenalty_DecreasesCorrectly()
    {
        // Arrange
        scoreSystem.IncreaseScore(50); // Set score to 50

        // Act
        scoreSystem.ApplyPenalty(20); // Apply a penalty of 20

        // Assert
        Assert.AreEqual(30, scoreSystem.CurrentScore, "Score should decrease correctly after applying penalty.");
    }

    [Test]
    public void ScoreSystem_ApplyPenalty_DoesNotGoBelowZero()
    {
        // Arrange
        scoreSystem.IncreaseScore(10); // Set score to 10

        // Act
        scoreSystem.ApplyPenalty(20); // Apply penalty greater than the score

        // Assert
        Assert.AreEqual(0, scoreSystem.CurrentScore, "Score should not go below zero.");
    }

    [Test]
    public void ScoreSystem_IncreaseScore_WithNegativeAmount_ThrowsException()
    {
        // Act & Assert
        Assert.Throws<System.ArgumentException>(() => scoreSystem.IncreaseScore(-10), "Score increment cannot be negative.");
    }

    [Test]
    public void ScoreSystem_ApplyPenalty_WithNegativeAmount_ThrowsException()
    {
        // Act & Assert
        Assert.Throws<System.ArgumentException>(() => scoreSystem.ApplyPenalty(-10), "Penalty cannot be negative.");
    }

    [Test]
    public void ScoreSystem_HighScore_PersistsAcrossSessions()
    {
        // Arrange
        scoreSystem.IncreaseScore(100); // Set score to 100
        int highScoreBeforeReset = scoreSystem.HighScore;

        // Act
        scoreSystem.ResetScore(); // Reset score
        scoreSystem.IncreaseScore(120); // Set new high score to 120

        // Assert
        Assert.AreEqual(100, highScoreBeforeReset, "High score should persist even after resetting the score.");
        Assert.AreEqual(120, scoreSystem.HighScore, "High score should update when new score exceeds previous high score.");
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(player);
    }
}
