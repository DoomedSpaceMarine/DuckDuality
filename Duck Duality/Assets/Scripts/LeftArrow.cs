using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArrow : MonoBehaviour
{
    MinigameManager mm;

    public int thisKeyNumber;

    // Start is called before the first frame update
    void Start()
    {
        mm = FindObjectOfType<MinigameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mm.arrowKeys[1].sprite = mm.highlightArrowKeys[1];
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            mm.arrowKeys[1].sprite = mm.normalArrowKeys[1];
            thisKeyNumber = 1;
            mm.ArrowKeyPressed(thisKeyNumber);

        }
    }
}
