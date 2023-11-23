using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PiecesScript : MonoBehaviour
{
    public DragAndDrop dragAndDrop;
    public GameObject effectSound;

    public Vector3 RightPosition;
    public Vector3 BeforePosition;
    public bool InRightPosition;
    public bool Selected;
    public bool Inside;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {

        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(-1.49f, 0.399f), Random.Range(-0.913f, -0.941f));
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, RightPosition);
        if (distance < 0.05f)
        {
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    effectSound.GetComponent<EffectSound>().Right();
                    transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                    dragAndDrop.CountRightPiece++;
                    dragAndDrop.UpdateRightPiece();
                    if (dragAndDrop.CountRightPiece == dragAndDrop.TotalPiece)
                    {
                        dragAndDrop.Win();
                    }
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        Inside = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Inside = false;
    }
}
