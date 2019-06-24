using UnityEngine;

/// <summary>
/// This class starts the game
/// </summary>

public class GameStartManager : SingletonBase<GameStartManager>
{
        
        [SerializeField ]private GameObject gameStartCharacter;
        /// <summary>
        /// on start of the game subscribe restartGame method om het game ended event
        /// </summary>
        private void Start()
        {
            EventCatalogue.GameEndedEvent += OnRestartGame;
        }

        /// <summary>
        /// when script is destroyed Unsubcribes restartgame on GameendedEvent.
        /// </summary>
        private void OnDestroy()
        {
            EventCatalogue.GameEndedEvent -= OnRestartGame;
        }
        /// <summary>
        /// Checkt de collision als het de tag nut heeft start de game
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
        /// ALs de game restart zet het GamestartCharacter Niet actief
        /// </summary>
        private void OnRestartGame()
        {
            gameStartCharacter.SetActive(true);
        }
        /// <summary>
        /// Zorgt er voor dat de game start
        /// </summary>
        private void GameStart()
        {
            gameStartCharacter.SetActive(false);
            GameTimeManager.instance.StartGame();
        }
}
