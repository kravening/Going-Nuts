using UnityEngine;
/// <summary>
/// This class starts the game
/// </summary>

//TODO Jeroen: deel functionaliteiten op.

public class GameStartManager : SingletonBase<GameStartManager>
//TODO: deel deze class op.
    {    
        /// <summary>
        /// gets the animator
        /// </summary>
        [SerializeField] public Animator treeFlipAnimator;

        private void Start()
        {
            EventCatalogue.GameEndedEvent += RestartGame;
        }

        private void OnDestroy()
        {
            EventCatalogue.GameEndedEvent -= RestartGame;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Nut"))
            {
                GameStart();
            }
        }

        private void RestartGame()
        {
            
        }

        private void GameStart()
        {
            GameTimeManager.instance.StartGame();
        }
    }
