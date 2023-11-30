using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance;
    public TMP_Text textLife;
    public TMP_Text textTimer;

    [SerializeField]
    private int maxLife;
    public static int totalLife = 0;
    public DateTime nextLifeTime;
    public DateTime lastAddedTime;
    private int restoreDuration = 100;
    private bool restoring = false;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // DontDestroyOnLoad(gameObject);
        // PlayerPrefs.DeleteAll();
        Load();
        StartCoroutine(RestoreRoutine());
    }

    public bool UseLife()
    {
        if (totalLife == 0) return true;
        totalLife--;
        UpdateLife();
        Save();
        if (!restoring)
        {
            if (totalLife + 1 == maxLife)
            {
                nextLifeTime = AddDuration(DateTime.Now, restoreDuration);
            }
            StartCoroutine(RestoreRoutine());
        }
        return false;
    }

    private IEnumerator RestoreRoutine()
    {
        UpdateTimer();
        UpdateLife();
        restoring = true;
        while (totalLife < maxLife)
        {
            DateTime currentTime = DateTime.Now;
            DateTime counter = nextLifeTime;
            bool isAdding = false;
            while (currentTime > counter)
            {
                if (totalLife < maxLife)
                {
                    isAdding = true;
                    AddLife();
                    DateTime timeToAdd = lastAddedTime > counter ? lastAddedTime : counter;
                    counter = AddDuration(timeToAdd, restoreDuration);
                }
                else break;
            }
            if (isAdding)
            {
                lastAddedTime = DateTime.Now;
                nextLifeTime = counter;
            }

            UpdateTimer();
            UpdateLife();
            Save();
            yield return null;
        }
        restoring = false;
    }
    public void AddLife()
    {
        if (totalLife<maxLife) totalLife++;
        UpdateTimer();
        UpdateLife();
        Save();
    }
    private void UpdateTimer()
    {
        if (totalLife >= maxLife)
        {
            textTimer.text = "full";
            return;
        }
        TimeSpan t = nextLifeTime - DateTime.Now;
        // string value = String.Format("{0:00}:{1:00}:{2:00}", (int)t.TotalHours, t.TotalMinutes, t.TotalSeconds);
        // string value = "t.ToString()";
        float hours = Mathf.FloorToInt((int)t.TotalHours);
        float minutes = Mathf.FloorToInt((int)t.TotalMinutes);
        float seconds = Mathf.FloorToInt((int)t.TotalSeconds % 60);
        // string value = t.TotalMinutes.ToString() + ":" + t.TotalSeconds.ToString();
        textTimer.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
    private void UpdateLife()
    {
        textLife.text = totalLife.ToString();
    }

    private DateTime AddDuration(DateTime time, int duration)
    {
        return time.AddSeconds(duration);
        // return time.AddMinutes(duration);

    }


    private void Load()
    {
        totalLife = PlayerPrefs.GetInt("totalLife");
        nextLifeTime = StringToDate(PlayerPrefs.GetString("nextLifeTime"));
        lastAddedTime = StringToDate(PlayerPrefs.GetString("lastAddedTime"));
    }

    private void Save()
    {
        PlayerPrefs.SetInt("totalLife", totalLife);
        PlayerPrefs.SetString("nextLifeTime", nextLifeTime.ToString());
        PlayerPrefs.SetString("lastAddedTime", lastAddedTime.ToString());
    }

    private DateTime StringToDate(string date)
    {
        if (String.IsNullOrEmpty(date))
        {
            return DateTime.Now;
        }
        return DateTime.Parse(date);
    }


}
