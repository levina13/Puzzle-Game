using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSound : MonoBehaviour
{
    [SerializeField] AudioClip _click, _win, _right, _lose;
    public void Click()
    {
        SoundManager.Instance.PlaySound(_click);
    }
    public void Win()
    {
        SoundManager.Instance.PlaySound(_win);
    }
    public void Right()
    {
        SoundManager.Instance.PlaySound(_right);
    }
    public void Lose()
    {
        SoundManager.Instance.PlaySound(_lose);

    }
}
