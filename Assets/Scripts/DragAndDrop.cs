using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DragAndDrop : MonoBehaviour
{
    public GameObject SelectedPiece;
    int OIL = 1;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("puzzle"))
            {
                if (!hit.transform.GetComponent<PiecesScript>().InRightPosition)
                {
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
    // void OnApplicationFocus(bool onFocus)
    // {
    //     if (onFocus)
    //     {
    //         Cursor.lockState = CursorLockMode.Locked;
    //     }
    //     else
    //     {
    //         Debug.Log("lost focus");
    //     }
    // }
}
