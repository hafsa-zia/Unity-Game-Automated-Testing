# Unity Game Automated Testing

A Unity-based game project with a comprehensive suite of **automated functional tests** designed to validate core gameplay systems and ensure application stability. The tests are written using the **NUnit framework** and executed through the **Unity Test Runner**.

## Testing Scope

The automated test suite validates key game systems and their expected behavior, including:

### Player Movement

* Verifies that the player responds correctly to movement inputs.
* Validates expected movement behavior during gameplay.

### Enemy AI

* Tests enemy detection of the player within a defined range.
* Validates enemy behavior when detecting and pursuing the player.

### Score System

* Verifies that the player's score is correctly incremented when collecting items.
* Validates expected score updates during gameplay.

### Health & Stamina Systems

* Tests health management and changes during gameplay.
* Validates stamina behavior and resource management.

### Obstacles & Collectibles

* Verifies that obstacles are correctly handled during gameplay.
* Tests collectible detection and interaction.
* Validates expected behavior when the player interacts with game objects.

## Testing Framework

The project uses:

* **NUnit** — Test framework for writing automated test cases
* **Unity Test Runner** — Execution environment for Unity automated tests
* **Unity / Unity Hub** — Game development and testing environment

## Test Coverage

| Game System     | Testing Focus                       |
| --------------- | ----------------------------------- |
| Player Movement | Input and movement behavior         |
| Enemy AI        | Player detection and pursuit        |
| Score System    | Score increment and updates         |
| Health System   | Health management                   |
| Stamina System  | Stamina management                  |
| Obstacles       | Obstacle handling                   |
| Collectibles    | Collection and interaction behavior |

## Project Purpose

The project demonstrates practical experience in **automated functional testing**, test case development, and validation of interconnected application systems. It uses structured automated tests to identify functional issues early and verify that core features continue to behave as expected after changes.
