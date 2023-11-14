using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public static float batasWaktu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        batasWaktu -= Time.deltaTime;
        if (batasWaktu < 0f)
        {
            GameOver();
        }
        // If puzzle selesai
        // if ()
        // {
        //     YouWin();
        // }
    }
    void GameOver()
    {
        Debug.Log("matii");
    }
    void YouWin()
    {
        Debug.Log("menang");
    }
}
