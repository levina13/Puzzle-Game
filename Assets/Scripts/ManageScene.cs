using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    // Start is called before the first frame update

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Play(int level)
    {
        StaticVar.level = level;
        SceneManager.LoadScene(level + 3);
    }
    public void NextLevel()
    {
        int level = StaticVar.level;
        SceneManager.LoadScene(level + 4);
    }
    public void Restart()
    {
        Play(StaticVar.level);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Map()
    {
        SceneManager.LoadScene(2);
    }
    public void Success()
    {
        SceneManager.LoadScene(3);
    }
    public void Lose()
    {
        SceneManager.LoadScene(1);
    }
}
