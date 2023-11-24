using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StaticVar : MonoBehaviour
{
    public static int level = 0;
    public static bool IsPaused = false;
    // Update is called once per frame
    public static TextMeshProUGUI PauseResumeButtonText;
    public static bool MusicPaused = false;
    public static bool EffectPaused = false;

}
