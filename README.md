# DQN agent for autonomous car
The project includes an python agent using the Deep Q-Network (DQN) algorithm and neural network. It also includes a simple environment made in unity. Agent's goal is to drive the track without touching the edge of the road. Its speed is constant and unchanging. The only available actions are turn left or right and do nothing. It collects knowledge about the environment from 15 sensors that control leaving the road and 4 sensors that check contact with checkpoints set along the route. To do this, agent uses an epsilon-greedy strategy with decaying epsilon.

# Content
- DQN agent
- Unity environment
- Trained model that is able to drive all available tracks

# Example of track in environment
![image](https://github.com/Rafiid/DQN_autonomous_car/assets/79717572/e05c939d-5383-493f-bc42-c7b341d23ba1)

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
