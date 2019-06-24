using System.Collections;
using UnityEngine;

/// <summary>
/// This class is the manager for the in-game time
/// </summary>
public class GameTimeManager : SingletonBase<GameTimeManager>
{
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
        EventCatalogue.InvokeGameStartedEvent();
        StartCoroutine(GameTimer());
    }

    /// <summary>
    /// this pauses the game timer and time based behaviours resulting in the game staying stationary, besides maybe the shaders.
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0;
        EventCatalogue.InvokeGamePausedEvent();
    }

    /// <summary>
    /// this resumes the game timer and time based behaviours resulting in the game continuing from where it was paused.
    /// </summary>
    public void ResumeGame()
    {
        Time.timeScale = 1;
        EventCatalogue.InvokeGameResumedEvent();
    }

    /// <summary>
    /// This function calls the event that ends the game.
    /// </summary>
    private void EndGame()
    {
        EventCatalogue.InvokeGameEndedEvent();
    }

    /// <summary>
    /// this function functions as the game timer, and will call the game ended event once the max round time has been reached.
    /// </summary>
    /// <returns></returns>
    private IEnumerator GameTimer()
    {

        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            EventCatalogue.OnUpdateTimer((int)currentTime);
            yield return new WaitForSeconds(0);
        }

        EventCatalogue.OnUpdateTimer(0);

        yield return new WaitForSeconds(0);

        EndGame();
    }
}