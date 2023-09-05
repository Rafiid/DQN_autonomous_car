import numpy as np
import tensorflow as tf
from collections import deque
import random

class DQN:
    def __init__(self, n_actions, memory_size, batch_size, gamma, learning_rate, epsilon_max, epsilon_increment):
        self.n_actions = n_actions
        self.memory_size = memory_size
        self.learning_rate = learning_rate
        self.gamma = gamma
        self.batch_size = batch_size
        self.model = self.build_model(self.learning_rate)
        self.epsilon_max = epsilon_max
        self.epsilon_increment = epsilon_increment
        self.epsilon = 0 if epsilon_increment is not None else self.epsilon_max
        self.learn_step_counter = 0
        self.memory = deque(maxlen=memory_size)
        self.checkpoint = tf.train.Checkpoint(model=self.model, optimizer=self.model.optimizer)


    def build_model(self, learning_rate):
        model = tf.keras.Sequential([
            tf.keras.layers.Dense(256, input_shape=(19,), activation='relu'),
            tf.keras.layers.Dense(3, activation=None)
        ])
    
        model.compile(loss='mse', optimizer=tf.keras.optimizers.Adam(learning_rate=learning_rate))

        return model

    def store_transition(self, state, action, reward, next_state, game_over):
        self.memory.append([state, action, reward, next_state, game_over])

    def choose_action(self, state):
        if np.random.uniform() < self.epsilon:
            actions_value = self.model(state)
            action = np.argmax(actions_value)
        else:
            action = np.random.randint(0, self.n_actions)

        self.learn_step_counter += 1
        if self.learn_step_counter % 2000 == 0 and self.learn_step_counter > 10000:
            if self.epsilon < self.epsilon_max:
                self.epsilon = self.epsilon + self.epsilon_increment
            else:
                self.epsilon = self.epsilon_max
        return action

    def getQvalues(self, state):
        q_values = self.model.predict(state)
        return q_values

    def learnFromStep(self, state, action, reward, next_state, game_over):
        with tf.GradientTape() as tape:

            predict_q_values = self.model(state)
            max_predict_q_value = tf.reduce_max(self.model(next_state))
            target_q_value = reward + (self.gamma * max_predict_q_value) * game_over
            target_q_values = predict_q_values

            target_q_values = target_q_values.numpy()
            target_q_values[0][action] = target_q_value
            target_q_values = tf.convert_to_tensor(target_q_values)

            loss = self.mean_squared_error(target_q_values, predict_q_values)

        gradients = tape.gradient(loss, self.model.trainable_weights)
        self.model.optimizer.apply_gradients(zip(gradients, self.model.trainable_weights))

    def learnFromBatch(self):
        with tf.GradientTape() as tape:
            batch = random.sample(self.memory, self.batch_size)
            predict_q_values = []
            target_q_values = []

            for state, action, reward, next_state, game_over in batch:
                predict_q_values.append(self.model(state))
                target_q_values.append(reward + (self.gamma * tf.reduce_max(self.model(next_state))) * game_over)

            target_q_values_modificated = predict_q_values

            for i in range(self.batch_size):
                numpy_target_q_values_modificated = target_q_values_modificated[i].numpy()
                numpy_target_q_values_modificated[0][batch[i][1]] = target_q_values[i].numpy()
                target_q_values_modificated.append(tf.convert_to_tensor(numpy_target_q_values_modificated))

            loss = self.mean_squared_error(target_q_values_modificated, predict_q_values)

        gradients = tape.gradient(loss, self.model.trainable_weights)
        self.model.optimizer.apply_gradients(zip(gradients, self.model.trainable_weights))

    def mean_squared_error(self, q_target, q_predict):
        return tf.keras.losses.mean_squared_error(q_target, q_predict)



