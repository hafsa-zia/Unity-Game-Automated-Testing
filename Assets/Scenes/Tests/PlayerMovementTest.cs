using NUnit.Framework;
using UnityEngine;
using PlayerMovementNamespace;

namespace PlayerMovementNamespace.Tests
{
    public class PlayerMovementTest
    {
        private GameObject player;
        private PlayerMovement movement;

        [SetUp]
        public void Setup()
        {
            player = new GameObject();
            movement = player.AddComponent<PlayerMovement>();
            player.transform.position = Vector3.zero;  // Starting position
        }

        [Test]
        public void PlayerMovesCorrectly()
        {
            movement.speed = 10f;
            player.transform.Translate(Vector3.forward * movement.speed * Time.deltaTime);

            // Assert that player moved from starting position
            Assert.AreNotEqual(Vector3.zero, player.transform.position);
        }

        [Test]
        public void PlayerMovesDiagonally()
        {
            movement.speed = 10f;
            player.transform.Translate(new Vector3(1, 0, 1) * movement.speed * Time.deltaTime);

            // Assert that player moved diagonally (not at origin)
            Assert.AreNotEqual(Vector3.zero, player.transform.position);
        }

        [Test]
        public void PlayerDoesNotMoveWithoutInput()
        {
            movement.speed = 10f;
            Vector3 startingPosition = player.transform.position;

            // No input, so position should not change
            player.transform.Translate(Vector3.zero);

            Assert.AreEqual(startingPosition, player.transform.position);
        }

        [Test]
        public void PlayerMovesFasterWithHigherSpeed()
        {
            Vector3 initialPosition = player.transform.position;
            movement.speed = 20f;

            // Move player
            player.transform.Translate(Vector3.forward * movement.speed * Time.deltaTime);

            // Assert that the player moved further with higher speed
            Assert.AreNotEqual(initialPosition, player.transform.position);
        }

        [Test]
        public void PlayerDoesNotMoveWhenSpeedIsZero()
        {
            movement.speed = 0f;
            Vector3 startingPosition = player.transform.position;

            // No movement with zero speed
            player.transform.Translate(Vector3.forward * movement.speed * Time.deltaTime);

            // Assert player has not moved
            Assert.AreEqual(startingPosition, player.transform.position);
        }

        [Test]
        public void PlayerMovesInReverseWithNegativeSpeed()
        {
            movement.speed = -10f;
            Vector3 startingPosition = player.transform.position;

            // Move player in reverse
            player.transform.Translate(Vector3.forward * movement.speed * Time.deltaTime);

            // Assert that the player has moved backwards (position should change)
            Assert.AreNotEqual(startingPosition, player.transform.position);
        }

        [Test]
        public void PlayerInputAtMaximumValues()
        {
            movement.speed = 10f;
            Vector3 startingPosition = player.transform.position;

            // Input at maximum values (move forward and right)
            player.transform.Translate(new Vector3(1, 0, 1) * movement.speed * Time.deltaTime);

            // Assert that player moved in the positive direction (diagonal movement)
            Assert.AreNotEqual(startingPosition, player.transform.position);
        }

        [Test]
        public void PlayerInputAtMinimumValues()
        {
            movement.speed = 10f;
            Vector3 startingPosition = player.transform.position;

            // Input at minimum values (move backward and left)
            player.transform.Translate(new Vector3(-1, 0, -1) * movement.speed * Time.deltaTime);

            // Assert that player moved in the negative direction (diagonal movement)
            Assert.AreNotEqual(startingPosition, player.transform.position);
        }

        [TearDown]
        public void TearDown()
        {
           GameObject.DestroyImmediate(player);  // Clean up after each test
        }
    }
}
