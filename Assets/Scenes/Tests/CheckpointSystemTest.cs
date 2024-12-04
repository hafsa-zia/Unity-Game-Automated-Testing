using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class CheckpointSystemTest
{
    private GameObject player;
    private CheckpointSystem checkpointSystem;

    [SetUp]
    public void SetUp()
    {
        // Create a GameObject with CheckpointSystem for testing
        player = new GameObject("Player");
        checkpointSystem = player.AddComponent<CheckpointSystem>();
    }

    [Test]
    public void CheckpointSystem_SetCheckpoint_SavesCheckpointPosition()
    {
        // Arrange
        Vector3 newCheckpoint = new Vector3(5, 0, 10);

        // Act
        checkpointSystem.SetCheckpoint(newCheckpoint);

        // Assert
        Assert.AreEqual(newCheckpoint, checkpointSystem.LastCheckpoint); // Ensure the checkpoint was saved correctly
    }

    [Test]
    public void CheckpointSystem_RespawnAtCheckpoint_RespawnsAtLastCheckpoint()
    {
        // Arrange
        Vector3 initialCheckpoint = new Vector3(5, 0, 10);
        checkpointSystem.SetCheckpoint(initialCheckpoint);

        // Act
        Vector3 respawnPosition = checkpointSystem.RespawnAtCheckpoint();

        // Assert
        Assert.AreEqual(initialCheckpoint, respawnPosition); // Ensure the player respawns at the correct position
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(player);
    }
}
