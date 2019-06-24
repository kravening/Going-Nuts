using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// This class starts the game
/// </summary>

//TODO Jeroen: deel functionaliteiten op.

public class GameStartManager : SingletonBase<GameStartManager>
//TODO: deel deze class op.
{

        [SerializeField ]private GameObject gameStartCharacter;
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

        private void RestartGame()
        {
            gameStartCharacter.SetActive(true);
        }

        private void GameStart()
        {
            gameStartCharacter.SetActive(false);
            GameTimeManager.instance.StartGame();
        }
}
