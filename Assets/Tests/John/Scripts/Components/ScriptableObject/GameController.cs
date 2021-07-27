using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace Components
{
    public class GameController : MonoBehaviour
    {
        // Игровые объекты, существующие на сцене, вставляем из прямо в инспекторе
        public GameObject player;
        public GameObject enemy;
        public GameObject blackHole;

        // Начальные позиции всех игровых объектов, можно играться, сколько угодно
        public Vector3 playerStartPosition;
        public Vector3 enemyStartPosition;
        public Vector3 blackHoleStartPosition;

        // ScriptableObject'ы игрока и противника, на которые подписан игровой цикл
        private ShipResources shipResources;

        // Объекты менюшек, которые мы будем скрывать/показывать
        public GameObject pauseMenu;
        public GameObject againMenu;

        // Объекты сцен, которые нам нужны, их можно хранить
        // в объем ScriptableObject, по которому затем просто
        // обращаться к ним, по идее
        [SerializeField]
        private Scene MenuScene;
        [SerializeField]
        private Scene GameScene;

        // Игровая камера на текущей сцене
        private GameObject camera;

        // Состояние игры (игра/пауза)
        private string gameState = "ready";

        void Start() // New Gamew
        {
            shipResources = new ShipResources();

            MenuScene = SceneManager.GetSceneByName("Menu Scene");
            GameScene = SceneManager.GetActiveScene();

            enemy = Instantiate(enemy, enemyStartPosition, Quaternion.identity);
            player = Instantiate(player, playerStartPosition, Quaternion.identity);

            player.name = "Player";
            enemy.name = "Enemy";

            ShipResources.OnShipDie += DeathHandler;            

            InitializeGame();
        }

        void InitializeGame()
        {
            pauseMenu.SetActive(false);
            againMenu.SetActive(false);

            ShipResources.SetRegisteredShip("player", 3);
            ShipResources.SetRegisteredShip("enemy", 3);

            ShipResources.healthLock = true;
            ShipResources.inputLock = true;

            StartCoroutine(StartGame());
        }

        IEnumerator StartGame()
        {
            Debug.Log("Start Game at 3");
            yield return new WaitForSeconds(1);   
            Debug.Log("Start Game at 2");
            yield return new WaitForSeconds(1);
            Debug.Log("Start Game at 1");
            yield return new WaitForSeconds(1);
            Debug.Log("Start Game!");

            gameState = "play";
            Time.timeScale = 1;

            ShipResources.healthLock = false;
            ShipResources.inputLock = false;
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(gameState == "ready")
                {
                    ShipResources.inputLock = true;

                    pauseMenu.SetActive(true);
                    gameState = "ready/pause";
                    // Покажи меню, останови игру
                    Debug.Log("Pause");
                    Time.timeScale = 0;
                }
                else if(gameState == "ready/pause")
                {
                    pauseMenu.SetActive(false);
                    gameState = "ready";
                    Debug.Log("ready");
                    Time.timeScale = 1;
                }
                else if(gameState == "pause")
                {
                    pauseMenu.SetActive(false);
                    gameState = "play";
                    // Убери меню, восстанови игру
                    Debug.Log("Continue");
                    ShipResources.inputLock = false;
                    Time.timeScale = 1;
                }
                else if(gameState == "play")
                {
                    pauseMenu.SetActive(true);
                    gameState = "pause";
                    // Покажи меню, останови игру
                    Debug.Log("Pause");
                    ShipResources.inputLock = true;

                    Time.timeScale = 0;
                }
            }
        }

        void healthLock(bool flag)
        {
            ShipResources.healthLock = flag;
        }

        void RepositionObjects()
        {
            healthLock(false);
            player.transform.position = playerStartPosition;
            enemy.transform.position = enemyStartPosition;
        }

        void DeathHandler(string name, int health)
        {
            healthLock(true);

            if(ShipResources.GetRegisteredShip("player") == 0)
            {
                GameOver("enemy");
            }
            else if(ShipResources.GetRegisteredShip("enemy") == 0)
            {
                GameOver("player");
            }
            else
            {
                // Подожди немного, а потом перезагрузи
                StartCoroutine(ReloadGame());
            }
        }

        IEnumerator ReloadGame()
        {
            Debug.Log("Reload game at 3");
            yield return new WaitForSeconds(1);
            Debug.Log("Reload game at 2");
            yield return new WaitForSeconds(1);
            Debug.Log("Reload game at 1");
            yield return new WaitForSeconds(1);
            RepositionObjects();
        }

        void GameOver(string winner)
        {
            Debug.Log("Winner is: " + winner);
            StartCoroutine(EndGame());
        }

        IEnumerator EndGame()
        {
            Debug.Log("Ending game at 3");
            yield return new WaitForSeconds(1);
            Debug.Log("Ending game at 2");
            yield return new WaitForSeconds(1);
            Debug.Log("Ending game at 1");
            yield return new WaitForSeconds(1);
            Debug.Log("End Game Event");

            // Здесь мы передаем AI'шнику управление игроком
            // в это время показываем менюшку
            ShipResources.inputLock = true;            

            againMenu.SetActive(true);
        }

        public void PlayAgainButtonEvent()
        {
            InitializeGame();
        }

        public void ContinueButtonEvent()
        {
            pauseMenu.SetActive(false);
            ShipResources.inputLock = false;
            Time.timeScale = 1;
        }

        public void BackToMainMenuButtonEvent()
        {
            StartCoroutine(LoadMenuScene());
        }

        IEnumerator LoadMenuScene()
        {
            // Потемнение экрана
            yield return new WaitForSeconds(1);

            AsyncOperation loadMenuScene = SceneManager.LoadSceneAsync("Menu Scene");

            while(!loadMenuScene.isDone)
            {
                yield return null;
            }
            
            AsyncOperation unloadGameScene = SceneManager.UnloadSceneAsync(GameScene);

            while(!unloadGameScene.isDone)
            {
                yield return null;
            }

            SceneManager.SetActiveScene(MenuScene);
        }
    }
}
