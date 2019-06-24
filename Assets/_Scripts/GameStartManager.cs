using UnityEngine;
/// <summary>
/// This class starts the game
/// </summary>

//TODO Jeroen: deel functionaliteiten op.

public class GameStartManager : SingletonBase<GameStartManager>
//TODO: deel deze class op.
    {
        /// <summary>
        /// get the props gameobjects to be used for setactive
        /// </summary>
        [SerializeField] private GameObject[] props;
      
        private void OnDestroy()
        {
            GameTimeManager.GameEndedEvent -= RestartGame;
        }

        private void Start()
        {
            GameTimeManager.GameEndedEvent += RestartGame;
        }

        #if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                      
                props[0]?.SetActive(false);
                GameStart();
            }
        }
        #endif

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Nut"))
            {
                GameStart();
            }
        }

        private void RestartGame()
        {
            props[0]?.SetActive(true);
        }

        private void GameStart()
        {
            props[0]?.SetActive(false);
            GameTimeManager.instance.StartGame();
        }
    }
