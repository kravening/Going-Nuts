﻿using System.Collections;
using UnityEngine;

//TODO: kijk of er een timer class gemaakt kan worden.
//TODO: consts waar zo nodig.

    /// <summary>
    /// This class is the manager for the in-game time
    /// </summary>
    public class GameTimeManager : SingletonBase<GameTimeManager>
    {
        /// <summary>
        /// an event signaling the game has started
        /// </summary>
        public delegate void GameStarted();

        public static event GameStarted GameStartedEvent;

        /// <summary>
        /// an event signaling the game has paused
        /// </summary>
        public delegate void GamePaused();

        public static event GamePaused GamePausedEvent;

        /// <summary>
        /// an event signaling the game has resumed
        /// </summary>
        public delegate void GameResumed();

        public static event GamePaused GameResumedEvent;

        /// <summary>
        /// an event signaling the game has ended
        /// </summary>
        public delegate void GameEnded();

        public static event GameEnded GameEndedEvent;
        
        public delegate void SetTimer(int timer);

        public static event SetTimer UpdateTimer;

        /// <summary>
        /// current time of the game round
        /// </summary>
        public float currentTime { get; private set; }

        /// <summary>
        /// max time of any given game round
        /// </summary>
        private float _roundTime = 180;

        /// <summary>
        /// this invokes the game started event, and starts the timer for the game.
        /// </summary>
        public void StartGame()
        {
            //resets round time.
            currentTime = _roundTime;
            GameStartedEvent.Invoke();
            StartCoroutine(GameTimer());
        }

        /// <summary>
        /// this pauses the game timer and time based behaviours resulting in the game staying stationary, besides maybe the shaders.
        /// </summary>
        public void PauseGame()
        {
            Time.timeScale = 0;
            GamePausedEvent.Invoke();
        }

        /// <summary>
        /// this resumes the game timer and time based behaviours resulting in the game continuing from where it was paused.
        /// </summary>
        public void ResumeGame()
        {
            Time.timeScale = 1;
            GameResumedEvent.Invoke();
        }

        /// <summary>
        /// this function functions as the game timer, and will call the game ended event once the max round time has been reached.
        /// </summary>
        /// <returns></returns>
        private IEnumerator GameTimer()
        {
            
            while (currentTime > 0)
            {
                UpdateTimer?.Invoke((int)currentTime);
                currentTime -= Time.deltaTime;
                yield return new WaitForSeconds(0);
            }
            
            UpdateTimer?.Invoke(0);
            
            yield return new WaitForSeconds(0);

            EndGame();
        }
        /// <summary>
        /// This function calls the event that ends the game.
        /// </summary>
        private void EndGame()
        {
            GameEndedEvent.Invoke();
        }
    }