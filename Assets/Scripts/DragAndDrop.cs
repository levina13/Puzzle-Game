using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class DragAndDrop : MonoBehaviour
{
    public GameObject SelectedPiece;
    public GameObject PauseMenu;
    public Button PauseResumeButton;
    public ManageScene manageScene;
    public ProgressBar progressBar;
    public GameObject effectSound;
    int OIL = 1;
    public int TotalPiece;
    public int CountRightPiece;
    public TMP_Text WaktuSisa;
    public static float batasWaktu = 60f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        if (StaticVar.level >= 1 && StaticVar.level <= 10)
        {
            TotalPiece = 24;
            batasWaktu = (StaticVar.level > 5) ? 150f : 120f;
        }
        else if (StaticVar.level >= 11 && StaticVar.level <= 20)
        {
            TotalPiece = 48;
            batasWaktu = (StaticVar.level > 15) ? 210f : 180f;
        }
        else
        {
            TotalPiece = 80;
            batasWaktu = (StaticVar.level > 25) ? 300f : 240f;
        }
        progressBar.SetMaxProgress(TotalPiece);

        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (batasWaktu > 0)
        {
            DisplayTime(batasWaktu);
            // if (!StaticVar.IsPaused)
            // {
            PuzzleMove();
            // }
            batasWaktu -= Time.deltaTime;
        }
        else
        {
            Lose();
        }
    }

    public void Win()
    {
        manageScene.Success();
    }

    public void Lose()
    {
        manageScene.Lose();
    }
    public void PauseOrResume()
    {
        if (StaticVar.IsPaused)
        {
            ResumeGame();
        }
        else
        {
            // DragAndDrop.PauseGame();
            PauseGame();
        }
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        StaticVar.IsPaused = true;
    }
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        StaticVar.IsPaused = false;
    }

    public void UpdateRightPiece()
    {
        progressBar.SetProgress(CountRightPiece);
    }

    public void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        WaktuSisa.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void PuzzleMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("puzzle"))
            {
                effectSound.GetComponent<EffectSound>().Click();
                if (!hit.transform.GetComponent<PiecesScript>().InRightPosition)
                {
                    Debug.Log("not right");
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<PiecesScript>().BeforePosition = SelectedPiece.transform.position;
                    SelectedPiece.GetComponent<PiecesScript>().Selected = true;
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                }
            }

        }
        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                // if di luar jangkauan
                bool inside = SelectedPiece.GetComponent<PiecesScript>().Inside;
                if (!inside)
                {
                    SelectedPiece.transform.position = SelectedPiece.GetComponent<PiecesScript>().BeforePosition;
                }
                SelectedPiece.GetComponent<PiecesScript>().Selected = false;
                SelectedPiece = null;
            }
        }

    }

}
