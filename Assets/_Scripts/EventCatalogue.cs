using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class containing all event references.
/// </summary>
public static class EventCatalogue
{
    #region InputEvents
    public delegate void SingleTouch();

    /// <summary>
    /// an event signaling that the screen had been touched with one finger.
    /// </summary>
    public static event SingleTouch SingleTouchEvent;

    /// <summary>
    /// invoke the event that signals the screen has been touched with one finger this frame.
    /// </summary
    public static void InvokeSingleTouchEvent()
    {
        SingleTouchEvent.Invoke();
    }
    #endregion

    #region GameStateEvents

    public delegate void GameStarted();

    /// <summary>
    /// an event signaling the game has started
    /// </summary>
    public static event GameStarted GameStartedEvent;

    /// <summary>
    /// invoke the event that signals the game has started
    /// </summary>
    public static void InvokeGameStartedEvent()
    {
        GameStartedEvent.Invoke();
    }

    public delegate void GamePaused();

    /// <summary>
    /// an event signaling the game has paused
    /// </summary>
    public static event GamePaused GamePausedEvent;

    /// <summary>
    /// invoke the event that signals the game has paused
    /// </summary>
    public static void InvokeGamePausedEvent()
    {
        GamePausedEvent.Invoke();
    }


    public delegate void GameResumed();
    /// <summary>
    /// an event signaling the game has resumed
    /// </summary>
    public static event GamePaused GameResumedEvent;
    /// <summary>
    /// invoke the event that signals the game has resumed
    /// </summary>
    public static void InvokeGameResumedEvent()
    {
        GameResumedEvent.Invoke();
    }


    public delegate void GameEnded();
    /// <summary>
    /// an event signaling the game has ended
    /// </summary>
    public static event GameEnded GameEndedEvent;
    /// <summary>
    /// invoke the event that signals the game has ended
    /// </summary>
    public static void InvokeGameEndedEvent()
    {
        GameEndedEvent.Invoke();
    }
    #endregion

    #region UiElementEvents
    public delegate void SetScore(int score);

    /// <summary>
    /// an event telling when the score gets updated.
    /// </summary>
    public static event SetScore UpdateScoreEvent;

    /// <summary>
    /// invokes updatescoreevent
    /// </summary>
    /// <param name="score"></param>
    public static void OnUpdateScoreEvent(int score)
    {
        UpdateScoreEvent?.Invoke(score);
    }

    public delegate void SetHighScore(int highscore);

    /// <summary>
    /// an event telling when the hisghscore needs to be saved.
    /// </summary>
    public static event SetHighScore SetHighScoreUiEvent;

    /// <summary>
    /// invokes sethighscoreevent
    /// </summary>
    /// <param name="highscore"></param>
    public static void OnSetHighScoreUiEvent(int highscore)
    {
        SetHighScoreUiEvent?.Invoke(highscore);
    }
    public delegate void SetTimer(int timer);

    /// <summary>
    /// an event telling when the timer gets updated.
    /// </summary>
    public static event SetTimer UpdateTimer;

    /// <summary>
    /// invokes updatetimer
    /// </summary>
    public static void OnUpdateTimer(int timer)
    {
        UpdateTimer?.Invoke(timer);
    }
    #endregion
}