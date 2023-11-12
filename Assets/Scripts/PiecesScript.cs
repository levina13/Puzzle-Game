using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesScript : MonoBehaviour
{
    public Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {

        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(-1.49f, 0.399f), Random.Range(-0.913f, -1.041f));
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, RightPosition);
        if (distance < 0.05f)
        {
            if (!Selected)
            {
                transform.position = RightPosition;
                InRightPosition = true;
            }
        }
    }
}
