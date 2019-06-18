using UnityEngine;


/// <summary>
/// This singleton handles the highscore and current scoring data of the game.
/// </summary>

//TODO: zet save functionaliteiten in een nieuwe class.
//TODO: check benamingen.

public class Highscore : SingletonBase<Highscore>
{

    private int _currentScore;

    protected override void Awake()
    {
        base.Awake();

        _currentScore = 0;
        CheckKeys();
    }

    /// <summary>
    /// Check if Score and HighScore key exist in PlayerPrefs
    /// </summary>
    private void CheckKeys()
    {
        IntializeKey(StringBase.HIGH_SCORES);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// increments _currentScore
    /// </summary>
    /// <param name="incrementValue"></param>
    public void IncrementScore(int incrementValue)
    {
        
        _currentScore += incrementValue;
        UIController.instance.UpdateScoreUi(_currentScore);
    }
    
    /// <summary>
    /// decrements _currentScore
    /// </summary>
    /// <param name="decrementValue"></param>
    public void DecrementScore(int decrementValue)
    {
        _currentScore -= decrementValue;
        UIController.instance.UpdateScoreUi(_currentScore);
    }

    /// <summary>
    /// saves the currentscore to the device
    /// </summary>
    /// <param name="scoreToSave"></param>
    public void SaveScoreToDevice(int scoreToSave)
    {
        if (_currentScore > PlayerPrefs.GetInt(StringBase.SCORE))
        {
            PlayerPrefs.SetInt(StringBase.SCORE, scoreToSave);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// save the highscore to the device
    /// </summary>
    public void SaveHighScoreToDevice()
    {
        if (GetCurrentScore() > GetHighScore())
        {
            PlayerPrefs.SetInt(StringBase.HIGH_SCORES, GetCurrentScore());
            PlayerPrefs.Save();
        }

        _currentScore = 0;
    }

    /// <summary>
    /// returns the currentscore
    /// </summary>
    /// <returns></returns>
    private int GetCurrentScore()
    {
        return _currentScore;
    }

    /// <summary>
    /// return the highscore from the playerprefs
    /// </summary>
    /// <returns></returns>
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(StringBase.HIGH_SCORES); ;
    }

    /// <summary>
    /// Intitializes a new key with the given keyName if it doesn't already exist on the device.
    /// </summary>
    /// <param name="keyName"></param>
    private void IntializeKey(string keyName)
    {
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
        }
    }
}
