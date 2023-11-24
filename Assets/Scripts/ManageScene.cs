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
    public void Menu()
    {
        ChangeScene(0);
    }
    public void Map()
    {
        ChangeScene(1);
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
            SceneManager.LoadScene(level + 2);
            if (level > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", level);
            }
        }
    }
    public void NextLevel()
    {
        int level = StaticVar.level;
        Play(level + 1);
    }
    public void Restart()
    {
        Play(StaticVar.level);
    }

    public void Success()
    {
        ChangeScene(StaticVar.level + 17);
        effectSound.GetComponent<EffectSound>().Win();
    }
    public void Lose()
    {
        ChangeScene(2);
        effectSound.GetComponent<EffectSound>().Lose();
    }
}
