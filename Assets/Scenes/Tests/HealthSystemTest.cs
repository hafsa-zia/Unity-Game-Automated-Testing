using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class HealthSystemTest
{
    private GameObject player;
    private HealthSystem healthSystem;

    [SetUp]
    public void SetUp()
    {
        // Create a GameObject with HealthSystem for testing
        player = new GameObject("Player");
        healthSystem = player.AddComponent<HealthSystem>();
    }

    [Test]
    public void HealthSystem_TakeDamage_DecreasesHealth()
    {
        // Set initial health to a value using Heal to ensure we can set it
        healthSystem.Heal(100); // Heal to full health first
        
        // Take damage, which should decrease health
        healthSystem.TakeDamage(20);
        
        // Assert the expected result after taking damage
        Assert.AreEqual(80, healthSystem.Health); // Assert that health is reduced to 80
    }

    [Test]
    public void HealthSystem_TakeDamage_DoesNotGoBelowZero()
    {
        // Arrange
        healthSystem.Heal(100); // Heal to full health first
        healthSystem.TakeDamage(200); // Take more damage than max health

        // Assert
        Assert.AreEqual(0, healthSystem.Health); // Ensure health doesn't go below 0
    }

    [Test]
    public void HealthSystem_Heal_IncreasesHealth()
    {
        // Set initial health to a value using Heal
        healthSystem.Heal(50); // Set health to 50
        
        // Heal by a certain amount
        healthSystem.Heal(30);
        
        // Assert the expected increase in health
        Assert.AreEqual(80, healthSystem.Health); // Assert that health is now 80
    }

    [Test]
    public void HealthSystem_Heal_DoesNotExceedMaxHealth()
    {
        // Arrange
        healthSystem.Heal(50); // Heal to 50 health first
        healthSystem.Heal(100); // Heal by 100, should not exceed max health

        // Assert
        Assert.AreEqual(100, healthSystem.Health); // Ensure health doesn't exceed maxHealth
    }

    [Test]
    public void HealthSystem_Heal_WhenAlreadyAtMaxHealth_DoesNotChangeHealth()
    {
        // Set initial health to the max value using Heal
        healthSystem.Heal(100); // Heal to full health
        
        // Heal, which shouldn't change the health because it's already at max
        healthSystem.Heal(20); // Attempting to heal by 20
        
        // Assert health remains the same
        Assert.AreEqual(100, healthSystem.Health);
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up after each test
        Object.DestroyImmediate(player);
    }
}
