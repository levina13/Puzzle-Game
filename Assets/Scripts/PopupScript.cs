using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupScript : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
    }

    // Update is called once per frame
    public void OpenPanel()
    {
        Panel.SetActive(true);
    }
    public void ClosePanel()
    {
        Panel.SetActive(false);
    }
}
