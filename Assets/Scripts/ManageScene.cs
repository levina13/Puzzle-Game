using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject effectSound;
    public GameObject lifeManager;

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
        bool empty = lifeManager.GetComponent<LifeManager>().UseLife();
        if (!empty)
        {
            StaticVar.level = level;
            SceneManager.LoadScene(level + 3);
        }
    }
    public void NextLevel()
    {
        int level = StaticVar.level;
        Play(level + 4);
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
        effectSound.GetComponent<EffectSound>().Win();
    }
    public void Lose()
    {
        SceneManager.LoadScene(1);
        effectSound.GetComponent<EffectSound>().Lose();
    }
}
