# DQN agent for autonomous car
The project includes an python agent using the Deep Q-Network (DQN) algorithm and neural network. It also includes a simple environment made in unity using the Unity ML-Agents Toolkit that allows for communication between the environment and the agent. Agent's goal is to drive the track without touching the edge of the road. Its speed is constant and unchanging. The only available actions are turn left or right and do nothing. It collects knowledge about the environment from 15 sensors that control leaving the road and 4 sensors that check contact with checkpoints set along the track. To do this, agent uses an epsilon-greedy strategy with decaying epsilon.

# Content
- DQN agent
- Unity environment
- Trained model that is able to drive all available tracks

# Example of track in environment
![image](https://github.com/Rafiid/DQN_autonomous_car/assets/79717572/5126bad2-54e6-4e78-ac2a-d3a22b7a4549)

# Installation
- mlagents (Python) 0.30.0
- numpy 1.21.2
- tensorflow 2.8.0
- Python 3.9.5

# Usage
1. Download project and import it to the unity.
2. Remember to set rotationAngle in CarController.cs and check_point_quantity in CheckPointManager to fit actual used track.
3. Run main.py or main_learning.py from Agent folder.
4. Run environemnt in unity.

Remember to empty the checkpoints directory containing the saves of the learned model before starting a new learning.
