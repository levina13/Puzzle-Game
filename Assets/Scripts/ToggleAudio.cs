using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField] private bool _toggleMusic, _toggleEffects;

    void Update()
    {
        if (_toggleMusic)
        {
            if (StaticVar.MusicPaused)
            {
                transform.Find("musicmute").gameObject.SetActive(true);
            }
            else
            {
                transform.Find("musicmute").gameObject.SetActive(false);
            }
        }
        else
        {
            if (StaticVar.EffectPaused)
            {
                transform.Find("effectmute").gameObject.SetActive(true);
            }
            else
            {
                transform.Find("effectmute").gameObject.SetActive(false);
            }
        }

    }
    public void Toggle()
    {
        if (_toggleMusic)
        {
            SoundManager.Instance.ToggleMusic();
        }
        if (_toggleEffects)
        {
            SoundManager.Instance.ToggleEffects();
        }

    }
}
