using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ObstacleSystemTest
{
    private GameObject player;
    private ObstacleSystem obstacleSystem;

    [SetUp]
    public void SetUp()
    {
        // Create a GameObject with ObstacleSystem for testing
        player = new GameObject("Player");
        obstacleSystem = player.AddComponent<ObstacleSystem>();
    }

    [Test]
    public void ObstacleSystem_CanCrossObstacle_ReturnsTrueWhenRequirementsMet()
    {
        // Arrange
        int requiredStamina = 30;
        int requiredMana = 20;
        int currentStamina = 50;
        int currentMana = 40;

        // Act
        bool result = obstacleSystem.CanCrossObstacle(requiredStamina, requiredMana, currentStamina, currentMana);

        // Assert
        Assert.IsTrue(result, "Player should be able to cross the obstacle when requirements are met.");
    }

    [Test]
    public void ObstacleSystem_CanCrossObstacle_ReturnsFalseWhenStaminaIsInsufficient()
    {
        // Arrange
        int requiredStamina = 30;
        int requiredMana = 20;
        int currentStamina = 10; // Not enough stamina
        int currentMana = 40;

        // Act
        bool result = obstacleSystem.CanCrossObstacle(requiredStamina, requiredMana, currentStamina, currentMana);

        // Assert
        Assert.IsFalse(result, "Player should not be able to cross the obstacle with insufficient stamina.");
    }

    [Test]
    public void ObstacleSystem_CanCrossObstacle_ReturnsFalseWhenManaIsInsufficient()
    {
        // Arrange
        int requiredStamina = 30;
        int requiredMana = 20;
        int currentStamina = 50;
        int currentMana = 10; // Not enough mana

        // Act
        bool result = obstacleSystem.CanCrossObstacle(requiredStamina, requiredMana, currentStamina, currentMana);

        // Assert
        Assert.IsFalse(result, "Player should not be able to cross the obstacle with insufficient mana.");
    }

    [Test]
    public void ObstacleSystem_CrossObstacle_IncreasesObstaclesCrossed()
    {
        // Act
        obstacleSystem.CrossObstacle();

        // Assert
        Assert.AreEqual(1, obstacleSystem.ObstaclesCrossed, "ObstaclesCrossed should increase when an obstacle is crossed.");
    }

    [Test]
    public void ObstacleSystem_CrossObstacle_MultipleCallsIncreaseCount()
    {
        // Act
        obstacleSystem.CrossObstacle();
        obstacleSystem.CrossObstacle();
        obstacleSystem.CrossObstacle();

        // Assert
        Assert.AreEqual(3, obstacleSystem.ObstaclesCrossed, "ObstaclesCrossed should reflect the number of times obstacles have been crossed.");
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(player);
    }
}
