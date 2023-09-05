import numpy as np
import traceback
from network import DQN
from environment import Environment
import tensorflow as tf

def main():
    checkpoint_sum = 0
    try:

        for step in range(10000001):

            step_info = environment.getStepInfo()
            state = environment.getState(step_info)
            action = agent.choose_action(state)
            environment.makeAction(action)
            reward = environment.getReward(step_info)

            if reward == 1.0:
                checkpoint_sum = checkpoint_sum + 1

            if reward == -1.0:
                print(step)
                with open("./points.txt", 'a') as file:
                    file.write(f"{checkpoint_sum}\n")
                checkpoint_sum = 0


    except Exception as e:
        traceback.print_exc()
    environment.env.close()


if __name__ == "__main__":
    environment = Environment(None, 1)
    agent = DQN(3, 10000, 32, 0.90, 0.0001, 1, None)
    agent.learn_step_counter = 50000

    agent.checkpoint.restore(tf.train.latest_checkpoint('./checkpoints'))
    print("Load file: ", tf.train.latest_checkpoint('./checkpoints'))

    main()
