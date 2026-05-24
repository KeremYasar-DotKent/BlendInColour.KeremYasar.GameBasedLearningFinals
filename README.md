# Blend in Color - Game-Based Learning Prototype

### GitHub Repository Link
> https://github.com/KeremYasar-DotKent/BlendInColour.KeremYasar.GameBasedLearningFinals/new/main?filename=README.md

Team Members:
Kerem Yaşar

Sena Karaca

Laiba Mohsan

---

## 1. Game Introduction
**Blend in Color** is a fast-paced, single-player 3D educational platformer that transforms the abstract concepts of **Color Theory and Chromatic Spectra** into dynamic, spatial parkour challenges. Set in a minimalist, vibrant digital void, players must navigate through shifting levels by dynamically altering their character's color tone. The primary goal is to master visual literacy, color categorization, and spectrum values to phase through corresponding barriers, utilize unique environmental physics (such as wall-climbing and ice-sliding), and successfully reach the final transition portal to restart the cycle.

---

## 2. Individual Contributions ("What I Did")

### Kerem - Team Leader & Core Developer & Level Designer
* **State & Color Management:** Programmed the core architecture for color-shifting triggers (`ColorPicker`) and the color-phasing obstacles (`ColorPassBlock`).
* **Level Progression & Navigation:** Scripted the trigger-based scene transition manager (`LevelChanger`) that handles progression between the 4 distinct color stages and loops the final stage back to the Main Menu.
* **Version Control Management:** Maintained the structured GitHub repository layout, configured version control ignore templates, and managed iterative branch states.

### Laiba - Gameplay & Physics Programmer
* **Advanced Physics Systems:** Implemented and fine-tuned custom player movement variables, specifically focusing on the low-friction ice physics for the Blue stage momentum.
* **Vertical Movement Mechanics:** Scripted and configured the vertical wall-climbing states and velocity calculations dedicated to the Green level stage layout.
* **Safety Net Logic:** Programmed the boundary collision scripts (`Hazard` detectors) to catch out-of-bounds player movements safely.

### Sena - UI/UX Designer & Technical Artist
* **Core Loop UI Architecture:** Designed and implemented the Start Menu user interface layout, configuring the `PLAY` and `QUIT` button functionality using high-fidelity raw image layers.
* **Checkpoint & Respawn Systems:** Developed the trigger-based checkpoint data retention script to accurately save player transform coordinates upon collision.
* **Visual Polish & Hierarchy:** Organized the internal scene hierarchy structures, managed tag/layer sorting for environmental assets, and optimized asset package integration.

---

## 3. Educational Concept
* **Pedagogical Goal:** The primary learning objective is to teach players **Color Theory (Value, Hue, and Tone categorization)** and cognitive spatial processing. Players learn to visually identify and differentiate between variations in a color spectrum (e.g., Light, Medium, Dark, and Deep variants) and understand the concept of "Color Neutralization" as a reset state.
* **Applied Learning Theory:** This prototype utilizes **Cognitivism** and **Constructivism**. Rather than relying on simple rote memorization, players actively construct cognitive frameworks to map colors to gameplay affordances. Learning happens through cognitive problem-solving as the game layer scales in difficulty.
* **How Mechanics Facilitate Learning:** In *Blend in Color*, a color is not cosmetic; it is a physical law. When a player encounters a *ColorPassBlock*, they face a cognitive barrier that can only be solved by finding the matching *ColorPicker* gate. In Level 1 (Red), players learn basic color matching. By Level 4 (Blue), players must combine high-speed *Ice Physics* with rapid color switches, forcing their brain to process color categorization instantly under high-tempo gameplay. The *Color Neutralizer* acts as a literal representation of chromatic subtraction, wiping the player's property and forcing them to re-evaluate the puzzle layout to progress.
