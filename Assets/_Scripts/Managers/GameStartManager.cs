using UnityEngine;

/// <summary>
/// This class starts the game
/// </summary>

public class GameStartManager : SingletonBase<GameStartManager>
{
    /// <summary>
    /// a reference to the object that needs to be disabled
    /// </summary>
    [SerializeField] private GameObject gameStartCharacter;

    private void Start()
    {
        EventCatalogue.GameEndedEvent += RestartGame;
    }

    private void OnDestroy()
    {
        EventCatalogue.GameEndedEvent -= RestartGame;
    }
    /// <summary>
    /// Als de 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nut"))
        {
            GameStart();
        }
    }

    /// <summary>
    /// enables the gamecharacter gameObject, allowing for the game to restart
    /// </summary>
    private void RestartGame()
    {
        gameStartCharacter.SetActive(true);
    }

    /// <summary>
    /// disaables the referenced character gameobject and calls the stargame function in the gametimemanager instance.
    /// </summary>
    private void GameStart()
    {
        gameStartCharacter.SetActive(false);
        GameTimeManager.instance.StartGame();
    }
}
