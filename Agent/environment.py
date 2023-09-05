from mlagents_envs.environment import UnityEnvironment as UE
from mlagents_envs.base_env import ActionTuple
from mlagents_envs.side_channel.engine_configuration_channel import EngineConfigurationChannel
import numpy as np
import tensorflow as tf
import re

class Environment:
    def __init__(self,file_name, time_scale):   
        print("Click play button")
        channel = EngineConfigurationChannel()
        self.env = UE(file_name=file_name, side_channels=[channel], no_graphics=True)
        print("Environment initialized")
        channel.set_configuration_parameters(time_scale=time_scale)
        self.env.reset()
        self.behavior_name = list(self.env.behavior_specs.keys())[0]

    def makeAction(self, action):
        action = np.array([[action]], dtype=np.int32)
        action = ActionTuple(discrete=action)
        self.env.set_actions(self.behavior_name, action)
        self.env.step()

    def getState(self, decision_steps):
        state = tf.convert_to_tensor(np.array(decision_steps[0][0]))
        return state

    def getStepInfo(self):
        decision_steps, terminal_steps = self.env.get_steps(self.behavior_name)
        return decision_steps

    def getReward(self, decision_steps):
        return decision_steps[0][1]
