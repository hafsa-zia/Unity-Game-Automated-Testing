using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    public Vector3 LastCheckpoint { get; private set; } // Stores the last reached checkpoint

    // Set the player's checkpoint to the current position
    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        LastCheckpoint = checkpointPosition;
    }

    // Reset the player's position to the last checkpoint
    public Vector3 RespawnAtCheckpoint()
    {
        return LastCheckpoint; // Return the last saved checkpoint position
    }
}
