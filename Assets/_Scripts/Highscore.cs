/// <summary>
/// This singleton handles the highscore and current scoring data of the game.
/// </summary>

//TODO: zet save functionaliteiten in een nieuwe class.
//TODO: check benamingen.

public class Highscore : SingletonBase<Highscore>
{
    private int _currentScore;
    private KeyHandler _keyHandler;


    protected override void Awake()
    {
        base.Awake();
    
        _currentScore = 0;

        _keyHandler = new KeyHandler();

        EventCatalogue.GameEndedEvent += SaveHighScore;
    }

    private void OnDestroy()
    {
        EventCatalogue.GameEndedEvent -= SaveHighScore;
    }

    /// <summary>
    /// Increments _currentScore
    /// </summary>
    /// <param name="incrementValue"></param>
    public void IncrementScore(int incrementValue)
    {
        _currentScore += incrementValue;
        EventCatalogue.OnSetHighScoreUiEvent(_currentScore);
    }
    
    /// <summary>
    /// Decrements _currentScore
    /// </summary>
    /// <param name="decrementValue"></param>
    public void DecrementScore(int decrementValue)
    {
        _currentScore -= decrementValue;
       EventCatalogue.OnUpdateScoreEvent(_currentScore);
    }

    /// <summary>
    /// Saves the highscore
    /// </summary>
    public void SaveHighScore()
    {
        EventCatalogue.OnUpdateTimer(_currentScore);
        if (_currentScore > _keyHandler.GetKey(StaticVariables.HIGH_SCORE))
        {
            _keyHandler.SetKey(StaticVariables.HIGH_SCORE, _currentScore);
        }
        _currentScore = 0;
    }
}
