using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject effectSound;
    public GameObject energyEmpty;

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
        bool empty = LifeManager.Instance.UseLife();
        if (!empty)
        {
            StaticVar.level = level;
            SceneManager.LoadScene(level + 2);

            return;
        }
        energyEmpty.SetActive(true);

    }
    public void NextLevel()
    {
        int level = StaticVar.level;
        Play(level + 1);
    }
    public void Restart()
    {
        Debug.Log("restart");
        Play(StaticVar.level);
    }
    public void PlayAgain()
    {
        Debug.Log("play again");
        Play(StaticVar.level - 1);
    }

    public void Success()
    {
        int nextLevel = StaticVar.level+1;
        if (nextLevel > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextLevel);
        }
        LifeManager.Instance.AddLife();
        ChangeScene(StaticVar.level + 17);
        effectSound.GetComponent<EffectSound>().Win();
    }
    public void Lose()
    {
        ChangeScene(2);
        effectSound.GetComponent<EffectSound>().Lose();
    }
}
