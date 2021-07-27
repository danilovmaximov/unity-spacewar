using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuController : MonoBehaviour
{
    // Объекты интерфейса - логотипы
    [SerializeField]
    private GameObject ExonervLogo;

    // Объекты интерфейса - групповые поля
    [SerializeField]
    private GameObject MenuPanel;
    [SerializeField]
    private GameObject OptionsPanel;

    // Объекты сцен - меню и игра
    [SerializeField]
    private Scene MenuScene;
    [SerializeField]
    private Scene GameScene;



    void Awake()
    {
        // Сохраняем референс на текущую сцену
        MenuScene = SceneManager.GetActiveScene();
        GameScene = SceneManager.GetSceneByName("Game Scene");

        // Запускаем корутину показа логотипов
        StartCoroutine(ShowLogo());
    }

    IEnumerator ShowLogo()
    {
        // Начинаем показывать анимацию логотипа
        ExonervLogo.SetActive(true);
        yield return new WaitForSeconds(2);

        // Немного ждем
        yield return new WaitForSeconds(1);

        // из темноты в темноту с наездом
        ExonervLogo.SetActive(false);
        yield return new WaitForSeconds(2);

        // Показываем бэкграунд и главную менюшку
        MenuPanel.SetActive(true);
    }

    public void PlayButtonEvent()
    {
        Debug.Log("Загрузка сцены с игрой");
        StartCoroutine(LoadGameScene());
    }

    IEnumerator LoadGameScene()
    {
        // Потемнение экрана
        // https://answers.unity.com/questions/1444269/enable-disable-cameras-on-the-scene.html
        yield return new WaitForSeconds(1);
        
        AsyncOperation loadGameScene = SceneManager.LoadSceneAsync("Game Scene", LoadSceneMode.Additive);

        while(!loadGameScene.isDone)
        {
            yield return null;
        }

        AsyncOperation unloadMenuScene = SceneManager.UnloadSceneAsync(MenuScene);

        while(!unloadMenuScene.isDone)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(GameScene);
    }

    public void OptionsButtonEvent()
    {
        MenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void BackToMainMenuButtonEvent()
    {
        OptionsPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void ExitButtonEvent()
    {
        Debug.Log("Выход из игры");
    }
}
