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
        GameTimeManager.GameEndedEvent += SaveHighScore;
    }

    private void OnDestroy()
    {
        GameTimeManager.GameEndedEvent -= SaveHighScore;
    }

    /// <summary>
    /// Increments _currentScore
    /// </summary>
    /// <param name="incrementValue"></param>
    public void IncrementScore(int incrementValue)
    {
        
        _currentScore += incrementValue;
        UIController.instance.UpdateScoreUi(_currentScore);
    }
    
    /// <summary>
    /// Decrements _currentScore
    /// </summary>
    /// <param name="decrementValue"></param>
    public void DecrementScore(int decrementValue)
    {
        _currentScore -= decrementValue;
        UIController.instance.UpdateScoreUi(_currentScore);
    }

    /// <summary>
    /// Saves the highscore
    /// </summary>
    public void SaveHighScore()
    {
        if (_currentScore > _keyHandler.GetKey(StaticVariables.HIGH_SCORE))
        {
            _keyHandler.SetKey(StaticVariables.HIGH_SCORE, _currentScore);
        }
        _currentScore = 0;
    }
}
