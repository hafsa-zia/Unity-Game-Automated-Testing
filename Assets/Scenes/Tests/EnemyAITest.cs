using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class EnemyAITest
{
    private GameObject enemy;
    private EnemyAI enemyAI;
    private GameObject player;

    [SetUp]
    public void SetUp()
    {
        // Create enemy and player objects
        enemy = new GameObject("Enemy");
        enemyAI = enemy.AddComponent<EnemyAI>();

        player = new GameObject("Player");
        player.transform.position = new Vector3(5, 0, 5); // Position player within detection range

        // Manually set the player for the EnemyAI to avoid relying on GameObject.Find
        enemyAI.SetPlayer(player.transform);
    }

    [Test]
    public void EnemyAI_DetectsPlayer_AndStartsChasing()
    {
        // Act
        enemyAI.Update(); // Manually invoke Update()

        // Assert
        Assert.IsTrue(enemyAI.IsChasing); // Ensure the enemy is chasing the player
    }

    [Test]
    public void EnemyAI_DoesNotDetectPlayer_IfOutOfRange()
    {
        // Arrange
        player.transform.position = new Vector3(20, 0, 20); // Move player out of detection range

        // Act
        enemyAI.Update(); // Manually invoke Update()

        // Assert
        Assert.IsFalse(enemyAI.IsChasing); // Ensure the enemy is not chasing the player
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(enemy);
        Object.DestroyImmediate(player);
    }
}
