using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float DetectionRange { get; private set; } = 10f; // Range in which the enemy can detect the player
    public bool IsChasing { get; private set; } = false; // Whether the enemy is chasing the player
    private Transform player;

    // Allow manual player assignment for testing purposes
    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }

    private void Start()
    {
        // This method will still work in the scene if a "Player" GameObject exists.
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform; // Get the player's transform
        }
    }

    public void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player is not assigned.");
            return; // Return early if player is not assigned
        }

        // Detect player within range and start chasing
        if (Vector3.Distance(transform.position, player.position) <= DetectionRange)
        {
            IsChasing = true;
        }
        else
        {
            IsChasing = false;
        }
    }
}
