using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class StaminaSystemTest
{
    private GameObject player;
    private StaminaSystem staminaSystem;

    [SetUp]
    public void SetUp()
    {
        // Create a GameObject with StaminaSystem for testing
        player = new GameObject("Player");
        staminaSystem = player.AddComponent<StaminaSystem>();

        // Initialize stamina values explicitly for consistent testing
        staminaSystem.InitializeStamina(100, 100); // Max stamina = 100, Current stamina = 100
    }

    [Test]
    public void StaminaSystem_Decrease_DoesNotGoBelowZero()
    {
        // Act
        staminaSystem.DecreaseStamina(200); // Attempt to decrease more than available

        // Assert
        Assert.AreEqual(0, staminaSystem.CurrentStamina, "Stamina should not go below 0.");
    }

    [Test]
    public void StaminaSystem_Increase_DoesNotExceedMaxStamina()
    {
        // Arrange
        staminaSystem.DecreaseStamina(50); // Reduce stamina to simulate mid-combat state

        // Act
        staminaSystem.IncreaseStamina(100); // Try to increase beyond max

        // Assert
        Assert.AreEqual(100, staminaSystem.CurrentStamina, "Stamina should not exceed MaxStamina.");
    }

    [Test]
    public void StaminaSystem_DecreaseStamina_DecreasesCorrectly()
    {
        // Act
        staminaSystem.DecreaseStamina(30);

        // Assert
        Assert.AreEqual(70, staminaSystem.CurrentStamina, "Stamina should decrease by the specified amount.");
    }

    [Test]
    public void StaminaSystem_IncreaseStamina_IncreasesCorrectly()
    {
        // Arrange
        staminaSystem.DecreaseStamina(50); // Reduce stamina to 50

        // Act
        staminaSystem.IncreaseStamina(30); // Increase stamina by 30

        // Assert
        Assert.AreEqual(80, staminaSystem.CurrentStamina, "Stamina should increase by the specified amount.");
    }

    [Test]
    public void StaminaSystem_InitializeStamina_SetsValuesCorrectly()
    {
        // Act
        staminaSystem.InitializeStamina(120, 80); // Initialize max and current stamina

        // Assert
        Assert.AreEqual(120, staminaSystem.MaxStamina, "MaxStamina should be set to the initialized value.");
        Assert.AreEqual(80, staminaSystem.CurrentStamina, "CurrentStamina should be set to the initialized value.");
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up the created GameObject after each test
        Object.DestroyImmediate(player);
    }
}
